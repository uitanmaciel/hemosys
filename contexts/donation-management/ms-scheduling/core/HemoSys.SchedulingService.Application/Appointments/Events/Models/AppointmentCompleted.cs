namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentCompleted(Appointment appointment) : IRequest
{
    public Guid Id { get; set; } = appointment.Id;
    public string StatusTypes { get; set; } = AppointmentStatusTypes.Completed.ToString();
}