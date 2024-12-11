using HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public record AppointmentCreated : Event, IRequest
{
    private string Donor { get; set; }
    private string? Location { get; set; }
    private DateTime ScheduledDate { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }

    public AppointmentCreated(Appointment appointment)
    {
        Donor = appointment.Donor.Name;
        Location = string.Concat(appointment.Location.Name,": ",appointment.Location.Address.ToString());
        ScheduledDate = appointment.ScheduledDate;
        StatusTypes = (AppointmentStatusTypes)appointment.StatusTypes;
    }
    
    public (string destination, string eventType, object message) ToMessage()
    {
        return (GetDestination(), GetEventType(EventType.Created), this);
    }
}