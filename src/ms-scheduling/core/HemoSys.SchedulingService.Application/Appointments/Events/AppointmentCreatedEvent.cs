namespace HemoSys.SchedulingService.Application.Appointments.Events;

public class AppointmentCreatedEvent(Appointment appointment) : IRequest
{
    public const string EventName = "appointment-created";
    public Guid Id { get; set; } = appointment.Id;
    public Guid Donor { get; set; } = appointment.Donor.Id;
    public string BloodType { get; set; } = appointment.Donor.BloodType!;
    public Guid DonationCenter { get; set; } = appointment.DonationCenter.Id;
    public DateTime ScheduleDate { get; set; } = appointment.ScheduledDate;
    public string Status { get; set; } = appointment.StatusTypes.ToString();
}