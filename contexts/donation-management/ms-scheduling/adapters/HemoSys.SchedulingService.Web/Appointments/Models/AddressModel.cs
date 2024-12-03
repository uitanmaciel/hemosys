namespace HemoSys.SchedulingService.Web.Appointments.Models;

public class AddressModel : Notifier
{
    [JsonPropertyName("street")]
    public string Street { get; set; } = null!;
    
    [JsonPropertyName("number")]
    public string Number { get; set; } = null!;
    
    [JsonPropertyName("neighborhood")]
    public string Neighborhood { get; set; } = null!;
    
    [JsonPropertyName("city")]
    public string City { get; set; } = null!;
    
    [JsonPropertyName("state")]
    public string State { get; set; } = null!;
    
    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; } = null!;
    
    public static AddressModel ToModel(AddressCommand? address)
    {
        if (address is null)
            return new AddressModel();

        return new AddressModel
        {
            Street = address.Street,
            Number = address.Number,
            Neighborhood = address.Neighborhood,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode
        };
    }
    
    public static IList<AddressModel> ToModel(IList<AddressCommand> addresses)
    {
        return addresses.Select(ToModel).ToList();
    }
    
    public  AddressCommand ToCommand(AddressModel? address)
    {
        ValidateFields(address);
        if(HasNotifications)
            return new AddressCommand();

        return new AddressCommand
        {
            Street = address!.Street,
            Number = address.Number,
            Neighborhood = address.Neighborhood,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode
        };
    }
    
    public IList<AddressCommand> ToCommand(IList<AddressModel> addresses)
    {
        return addresses.Select(ToCommand).ToList();
    }
    
    public override string ToString()
    {
        return string.Join(", ", Street, Number, Neighborhood, City, State, ZipCode);
    }

    private void ValidateFields(AddressModel? address)
    {
        if (string.IsNullOrEmpty(address!.Street))
            AddNotification(Error.IsNotNullOrEmpty(nameof(Street)));
        
        if(address.Street.Length < 5)
            AddNotification(Error.IsLowerThan(nameof(Street), 5));
        
        if (string.IsNullOrEmpty(address.Neighborhood))
            AddNotification(Error.IsNotNullOrEmpty(nameof(Neighborhood)));
        
        if(address.Neighborhood.Length < 3)
            AddNotification(Error.IsLowerThan(nameof(Neighborhood), 3));
        
        address.AddNotifications(Notifications);
    }
}