namespace HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    
    public Location() { }
    
    public Location(string name, Address address)
    {
        Name = name;
        Address = address;
    }
}