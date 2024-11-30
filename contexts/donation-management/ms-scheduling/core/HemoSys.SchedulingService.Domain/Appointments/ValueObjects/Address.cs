namespace HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

public sealed class Address : ValueObject
{
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string Neighborhood { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string ZipCode { get; private set; } = null!;
    
    public Address() { }
    
    public Address(string street, string number, string neighborhood, string city, string state, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return string.Join(", ", Street, Number, Neighborhood, City, State, ZipCode);
    }
}