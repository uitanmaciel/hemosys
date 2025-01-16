namespace HemoSys.SchedulingService.Application.Appointments.Events;

public class AppointmentRescheduledEvent(Appointment appointment) : IRequest
{
    public const string EventName = "appointment-rescheduled";
    public Guid Id { get; set; } = appointment.Id;
    public DateTime RescheduledDate { get; set; } = appointment.ScheduledDate;
}