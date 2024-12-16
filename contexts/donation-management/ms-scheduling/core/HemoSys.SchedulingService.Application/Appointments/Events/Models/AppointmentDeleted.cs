namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentDeleted(Appointment appointment) : IRequest
{
    public Guid Id { get; set; } = appointment.Id;
    public string StatusTypes { get; set; } = AppointmentStatusTypes.Deleted.ToString();
}