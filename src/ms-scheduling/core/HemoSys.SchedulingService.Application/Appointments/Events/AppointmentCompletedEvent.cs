namespace HemoSys.SchedulingService.Application.Appointments.Events;

public class AppointmentCompletedEvent(Appointment appointment) : IRequest
{
    public const string EventName = "appointment-completed";
    public Guid Id { get; set; } = appointment.Id;
}