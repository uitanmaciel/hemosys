namespace HemoSys.SchedulingService.Application.Appointments.Events;

public class AppointmentDeletedEvent(Appointment appointment) : IRequest
{
    public const string EventName = "appointment-deleted";
    public Guid Id { get; set; } = appointment.Id;
}