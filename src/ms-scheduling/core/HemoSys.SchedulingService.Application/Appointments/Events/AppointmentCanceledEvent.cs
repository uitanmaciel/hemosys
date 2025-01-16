namespace HemoSys.SchedulingService.Application.Appointments.Events;

public class AppointmentCanceledEvent(Appointment appointment) : IRequest
{
    public const string EventName = "appointment-canceled";
    public Guid Id { get; set; } = appointment.Id;
    public string Status { get; set; } = appointment.StatusTypes.ToString();
}