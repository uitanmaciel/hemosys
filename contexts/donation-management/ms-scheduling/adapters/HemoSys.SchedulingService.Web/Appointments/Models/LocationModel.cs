namespace HemoSys.SchedulingService.Web.Appointments.Models;

public class LocationModel  : Notifier
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("address")]
    public AddressModel Address { get; set; } = null!;
    
    public static LocationModel ToModel(LocationCommand? command)
    {
        if (command is null)
            return new LocationModel();

        return new LocationModel
        {
            Name = command.Name,
            Address = AddressModel.ToModel(command.Address)
        };
    }
    
    public static IList<LocationModel> ToModel(IList<LocationCommand> commands)
    {
        return commands.Select(ToModel).ToList();
    }
    
    public LocationCommand ToCommand(LocationModel? model)
    {
        ValidateFields(model);
        if(HasNotifications)
            return new LocationCommand();

        return new LocationCommand
        {
            Name = model!.Name,
            Address = new AddressModel().ToCommand(model.Address)
        };
    }
    
    public IList<LocationCommand> ToCommand(IList<LocationModel> models)
    {
        return models.Select(ToCommand).ToList();
    }

    private void ValidateFields(LocationModel? model)
    {
        if(model is null)
            AddNotification("LocationModel", "LocationModel is null");
        
        if(string.IsNullOrEmpty(model!.Name))
            AddNotification(Error.IsNullOrEmpty(nameof(Name)));
        
        if(model!.Name.Length < 5)
            AddNotification(Error.IsLowerThan(nameof(Name), 5));
        
        model.AddNotifications(Notifications);
    }
}