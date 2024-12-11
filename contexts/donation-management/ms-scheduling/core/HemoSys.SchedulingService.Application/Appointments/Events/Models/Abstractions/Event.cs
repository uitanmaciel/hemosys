namespace HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

public abstract record Event
{
    private const string Destination = "schedulingevents";

    public string GetDestination() => Destination;
    public string GetEventType(EventType eventType) => string.Concat("appointment.",eventType.ToString().ToLower());
}