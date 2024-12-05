using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Domain.Appointments.Aggregates;

public sealed class Appointment : AggregateRoot
{
    public Donor Donor { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public DateTime ScheduledDate { get; private set; }
    public AppointmentStatusTypes StatusTypes { get; private set; }
    public DateTime LastAppointment { get; private set; }
    public string? Notes { get; private set; }
    
    public Appointment() { }
    
    public Appointment(
        Guid id, 
        Donor donor, 
        Location location, 
        DateTime scheduledDate, 
        AppointmentStatusTypes statusTypes,
        DateTime lastAppointment,
        string? notes) : base(id)
    {
        Donor = donor;
        Location = location;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        LastAppointment = lastAppointment;
        Notes = notes;
    }
    
    public void ApplyRulesToCreateAppointment()
    {
        ValidationsForCreateAppointment();
        if(HasNotifications) return;
        Id = Guid.CreateVersion7(DateTimeOffset.UtcNow);
        StatusTypes = AppointmentStatusTypes.Scheduled;
        LastAppointment = ScheduledDate;
    }
    
    public void ApplyRulesToUpdateAppointment()
    {
        ValidationsForUpdateAppointment();
        if(HasNotifications) return;
    }
    
    public void Complete() => StatusTypes = AppointmentStatusTypes.Completed;
    
    public void Cancel() => StatusTypes = AppointmentStatusTypes.Canceled;

    public int CalculateDaysSinceLastDonation()
    {
        var days = (ScheduledDate - LastAppointment).Days;
        return days;
    }

    private void ValidationsForCreateAppointment()
    {
        if(ScheduledDate < DateTime.Now)
            AddNotification("ScheduledDate", "The scheduled date must be greater than the current date.");
        
        switch (Donor.Gender)
        {
            case "Female" when CalculateDaysSinceLastDonation() < 90:
                AddNotification("Donor", "Womens can only donate every 90 days.");
                break;
            case "Male" when CalculateDaysSinceLastDonation() < 60:
                AddNotification("Donor","Mens can only donate every 60 days.");
                break;
        }
        
        ValidationsInherit();
    }

    private void ValidationsForUpdateAppointment()
    {
        AddNotifications(new ValidationRules<Appointment>()
            .IsGuidNotEmpty(nameof(Id), Id)
        );
        
        if(StatusTypes == AppointmentStatusTypes.Completed)
            AddNotification("Status", "The appointment is already completed.");
        
        ValidationsInherit();
    }

    private void ValidationsInherit()
    {
        AddNotifications(Donor.Notifications);
        AddNotifications(Location.Notifications);
    }
}