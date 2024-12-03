namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentCreated : IRequest
{
    public string Donor { get; set; } 
    public string? Location { get; set; } 
    public DateTime ScheduledDate { get; set; }
    public AppointmentStatusTypes StatusTypes { get; set; }
    private string Destination => string.Concat("appointment.", StatusTypes.ToString().ToLower());
    private string EventType => string.Concat("appointment.", StatusTypes.ToString().ToLower());
    
    public AppointmentCreated(Appointment appointment)
    {
        Donor = appointment.Donor.Name;
        Location = string.Concat(appointment.Location.Name,": ",appointment.Location.Address.ToString());
        ScheduledDate = appointment.ScheduledDate;
        StatusTypes = (AppointmentStatusTypes)appointment.StatusTypes;
    }
    
    public (string destination, string eventType, AppointmentCreated message) ToMessage()
    {
        return (Destination, EventType, this);
    }
}