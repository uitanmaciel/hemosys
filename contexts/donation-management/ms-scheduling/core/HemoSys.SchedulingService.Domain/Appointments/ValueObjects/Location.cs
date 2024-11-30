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
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<Location>()
            .IsNotNullOrEmpty(nameof(Name), Name)
            .IsLengthLowerThan(nameof(Name), Name, 3)
        );
        
        AddNotifications(Address.Notifications);
    }
}