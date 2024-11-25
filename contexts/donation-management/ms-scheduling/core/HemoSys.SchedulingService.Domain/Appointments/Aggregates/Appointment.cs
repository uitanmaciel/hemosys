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
    public string? Notes { get; private set; }
    public IList<Appointment> Appointments { get; private set; } = [];
    
    public Appointment() { }
    
    public Appointment(Guid id, Donor donor, Location location, DateTime scheduledDate, AppointmentStatusTypes statusTypes, string? notes) : base(id)
    {
        Donor = donor;
        Location = location;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        Notes = notes;
    }
    
    public void AddAppointments() => Appointments.Add(this);
    
    public void ApplyRuleToSchedule()
    {
        Validations();
        if(HasNotifications) return;
        Id = Guid.CreateVersion7(DateTimeOffset.UtcNow);
        StatusTypes = AppointmentStatusTypes.Scheduled;
    }
    
    public void Complete() => StatusTypes = AppointmentStatusTypes.Completed;
    
    public void Cancel() => StatusTypes = AppointmentStatusTypes.Canceled;
    
    private int CalculateDaysSinceLastDonation()
    {
        var lastDonation = Appointments
            .Where(a => a.Donor.Id == Donor.Id)
            .Where(a => a.StatusTypes == AppointmentStatusTypes.Completed)
            .OrderByDescending(a => a.ScheduledDate)
            .FirstOrDefault();
        
        return lastDonation is null ? 0 : (ScheduledDate - lastDonation.ScheduledDate).Days;
    }

    private void Validations()
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
        
        AddNotifications(Donor.Notifications);
    }
}