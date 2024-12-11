using HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public record AppointmentDeleted : Event, IRequest
{
    private Guid Id { get; set; }
    
    public AppointmentDeleted(Guid id)
    {
        Id = id;
    }
    
    public (string destination, string eventType, object message) ToMessage()
    {
        return (GetDestination(), GetEventType(EventType.Deleted), this);
    }
}