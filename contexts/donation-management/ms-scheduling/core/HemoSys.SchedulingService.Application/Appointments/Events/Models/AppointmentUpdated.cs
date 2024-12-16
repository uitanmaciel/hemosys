namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentUpdated(Appointment appointment) : IRequest
{
    public Guid Id { get; set; } = appointment.Id;
    public string? Location { get; set; } = appointment.Location.Address.ToString();
    public DateTime ScheduledDate { get; set; } = appointment.ScheduledDate;
    public AppointmentStatusTypes StatusTypes { get; set; } = (AppointmentStatusTypes)appointment.StatusTypes;
}