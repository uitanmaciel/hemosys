using HemoSys.SchedulingService.Application.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentCreatedEvent : IRequest
{
    public string Donor { get; init; } = string.Empty;
    public string? Location { get; init; } = string.Empty;
    public DateTime ScheduledDate { get; init; }
    public AppointmentStatusTypes StatusTypes { get; init; }
    
    public AppointmentCreatedEvent ToEvent(Appointment appointment)
    {
        return new AppointmentCreatedEvent
        {
            Donor = appointment.Donor.Name,
            Location = appointment.Location.ToString(),
            ScheduledDate = appointment.ScheduledDate,
            StatusTypes = (AppointmentStatusTypes)appointment.StatusTypes
        };
    }
}