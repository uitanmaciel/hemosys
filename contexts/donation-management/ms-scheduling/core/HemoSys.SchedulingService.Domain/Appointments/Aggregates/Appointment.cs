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
        Donor.Attach();
        ValidationsForCreateAppointment();
        if(HasNotifications) return;
        Id = Guid.CreateVersion7(DateTimeOffset.UtcNow);
        StatusTypes = AppointmentStatusTypes.Scheduled;
        LastAppointment = ScheduledDate;
    }
    
    public void ApplyRulesToUpdateAppointment()
    {
        Donor.Attach();
        ValidationsForUpdateAppointment();
        if(HasNotifications) return;
    }

    public void ApplyRulesToDeleteAppointment()
    {
        ValidationsForDeleteAppointment();
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
            AddNotification(
                key: "ScheduledDate", 
                message: "The scheduled date must be greater than the current date.");
        
        switch (Donor.Gender)
        {
            case "Female" when CalculateDaysSinceLastDonation() < 90:
                AddNotification(
                    key: "Donor", 
                    message: "Womens can only donate every 90 days.");
                break;
            case "Male" when CalculateDaysSinceLastDonation() < 60:
                AddNotification(
                    key: "Donor",
                    message: "Mens can only donate every 60 days.");
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
            AddNotification(
                key: "Status", 
                message: "The appointment is already completed.");
        
        ValidationsInherit();
    }
    
    private void ValidationsForDeleteAppointment()
    {
        if(StatusTypes is AppointmentStatusTypes.Canceled or AppointmentStatusTypes.Completed)
            AddNotification(
                key: "Status", 
                message: "The appointment is already canceled.");
    }

    private void ValidationsInherit()
    {
        Donor.Attach();
        AddNotifications(Donor.Notifications);
        AddNotifications(Location.Notifications);
    }
}