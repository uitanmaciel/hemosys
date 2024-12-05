namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentCreated : IRequest
{
    private const string Destination = "schedulingevents";
    private string EventType => string.Concat("appointment.", StatusTypes.ToString().ToLower());
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
        return (Destination, EventType, this);
    }
}