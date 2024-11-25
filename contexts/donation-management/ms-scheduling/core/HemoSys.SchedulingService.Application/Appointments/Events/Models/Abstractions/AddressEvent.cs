namespace HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

public record AddressEvent
{
    public string Street { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}