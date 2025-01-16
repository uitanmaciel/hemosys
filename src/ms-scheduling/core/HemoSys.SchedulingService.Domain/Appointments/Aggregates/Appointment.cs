using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Domain.Appointments.Aggregates;

public class Appointment() : AggregateRoot
{
    public Donor Donor { get; private set; } = null!;
    public DonationCenter DonationCenter { get; private set; } = null!;
    public DateTime ScheduledDate { get; private set; }
    public AppointmentStatusTypes StatusTypes { get; private set; }
    public DateTime LastDonation { get; private set; }
    public IList<Note>? Notes { get; private set; }

    public Appointment(
        Guid id,
        Donor donor,
        DonationCenter donationCenter,
        DateTime scheduledDate,
        AppointmentStatusTypes statusTypes,
        DateTime lastDonation,
        IList<Note>? notes = null) : this()
    {
        Id = id;
        Donor = donor;
        DonationCenter = donationCenter;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        LastDonation = lastDonation;
        Notes = notes;
    }
    
    #region Domain Rules
    
    public virtual void ApplyRulesToCreate()
    {   
        Donor.Attach(Donor);
        ValidationsToCreate();
        if(HasNotifications) return;
        
        Id = Guid.CreateVersion7();
        StatusTypes = AppointmentStatusTypes.Scheduled;
    }
    
    public virtual void ApplyRulesToUpdate()
    {
        ValidationsToUpdate();
        if(HasNotifications) return;
    }
    
    public virtual void ApplyRulesToDelete()
    {
        ValidationsToDelete();
        if(HasNotifications) return;
    }
    
    public virtual void ApplyRulesToComplete()
    {
        ValidationToComplete();
        if(HasNotifications) return;
        
        StatusTypes = AppointmentStatusTypes.Completed;
    }
    
    public virtual void ApplyRulesToCancel()
    {
        ValidationsToCancel();
        if(HasNotifications) return;
        
        StatusTypes = AppointmentStatusTypes.Canceled;
    }
    
    public virtual void ApplyRulesToConfirm()
    {
        ValidationToConfirm();
        if(HasNotifications) return;
        
        StatusTypes = AppointmentStatusTypes.Confirmed;
    }
    
    public virtual void ApplyRulesToReschedule()
    {
        ValidationToReschedule();
        if(HasNotifications) return;
    }
    
    private int CalculateDaysSinceLastDonation()
    {
        var days = (ScheduledDate - LastDonation).Days;
        return days;
    }
    #endregion
    #region Validations
    
    private void ValidationsToCreate()
    {
        if (ScheduledDate < DateTime.Now)
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
        
        if(Donor.HasNotifications)
            GetDonorNotifications();
        
        if(DonationCenter.HasNotifications)
            GetDonationCenterNotifications();
    }

    private void ValidationsToUpdate()
    {
        if(StatusTypes is 
           AppointmentStatusTypes.Completed or
           AppointmentStatusTypes.Canceled)
            AddNotification(
                key: "Status", 
                message: "The appointment is already completed.");
    }
    
    
    private void ValidationsToDelete()
    {
        if(StatusTypes is AppointmentStatusTypes.Completed)
            AddNotification(
                key: "Status", 
                message: "The appointment is already canceled.");
    }

    private void ValidationToComplete()
    {
        if(StatusTypes is AppointmentStatusTypes.Canceled)
            AddNotification(
                key: "Status", 
                message: "The appointment is already completed.");
    }

    private void ValidationsToCancel()
    {
        if(StatusTypes is AppointmentStatusTypes.Completed)
            AddNotification(
                key: "Status", 
                message: "The appointment is already canceled.");
    }

    private void ValidationToConfirm()
    {
        if(StatusTypes is AppointmentStatusTypes.Canceled or AppointmentStatusTypes.Completed)
            AddNotification(
                key: "Status", 
                message: "The appointment cannot be confirmed because it is either cancelled or completed.");
    }

    private void ValidationToReschedule()
    {
        if(StatusTypes is 
           AppointmentStatusTypes.Canceled or 
           AppointmentStatusTypes.Completed or
           AppointmentStatusTypes.Confirmed)
            AddNotification(
                key: "Status", 
                message: "The appointment cannot be reschedule because it is either cancelled or completed or confirmed.");
    }
    
    private void GetDonorNotifications()
        => AddNotification(Donor.Notifications);
    
    private void GetDonationCenterNotifications()
        => AddNotification(DonationCenter.Notifications);
    #endregion
}