using HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public record AppointmentUpdated : Event, IRequest
{
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
        return (GetDestination(), GetEventType(EventType.Updated), this);
    }
}