namespace HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

public record LocationEvent
{
    public string Name { get; private set; } = null!;
    public AddressEvent Address { get; private set; } = null!;
}