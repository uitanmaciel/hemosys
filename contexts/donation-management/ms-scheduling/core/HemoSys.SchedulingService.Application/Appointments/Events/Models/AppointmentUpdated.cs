namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentUpdated : IRequest
{
    private const string Destination = "schedulingevents";
    private string EventType => string.Concat("appointment.", StatusTypes.ToString().ToLower());
    private Guid Id { get; set; }
    private string? Location { get; set; } 
    private DateTime ScheduledDate { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }
    
    public AppointmentUpdated(Appointment appointment)
    {
        Id = appointment.Id;
        Location = string.Concat(appointment.Location.Name,": ",appointment.Location.Address.ToString());
        ScheduledDate = appointment.ScheduledDate;
        StatusTypes = (AppointmentStatusTypes)appointment.StatusTypes;
    }
    
    public (string destination, string eventType, object message) ToMessage()
    {
        return (Destination, EventType, this);
    }
}