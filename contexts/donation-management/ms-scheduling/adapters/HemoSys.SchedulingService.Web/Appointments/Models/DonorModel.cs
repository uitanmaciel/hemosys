using System.Globalization;

namespace HemoSys.SchedulingService.Web.Appointments.Models;

public class DonorModel : Notifier
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("bloodType")]
    public string? BloodType { get; set; }
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; } = null!;
    
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    public static DonorModel ToModel(DonorCommand? command)
    {
        if (command is null)
            return new DonorModel();

        return new DonorModel
        {
            Id = command.Id,
            Name = command.Name,
            BloodType = command.BloodType,
            Weight = command.Weight,
            Gender = command.Gender,
            BirthDate = command.BirthDate
        };
    }
    
    public static IList<DonorModel> ToModel(IList<DonorCommand> commands)
    {
        return commands.Select(ToModel).ToList();
    }

    public DonorCommand ToCommand(DonorModel? model)
    {
        ValidateFields(model);
        if (HasNotifications)
            return new DonorCommand();

        return new DonorCommand
        {
            Id = model!.Id,
            Name = model.Name,
            BloodType = model.BloodType,
            Weight = model.Weight,
            Gender = model.Gender,
            BirthDate = model.BirthDate
        };
    }
    
    public IList<DonorCommand> ToCommand(IList<DonorModel> models)
    {
        return models.Select(ToCommand).ToList();
    }

    private void ValidateFields(DonorModel? model)
    {
        if(string.IsNullOrEmpty(model?.Name))
            AddNotification(Error.IsNotNullOrEmpty(nameof(Name)));
        
        if(model?.Weight <= 0)
            AddNotification(Error.IsGreaterThan(nameof(Weight), 0));
        
        if(string.IsNullOrEmpty(model?.BirthDate.ToString(CultureInfo.InvariantCulture)))
            AddNotification(Error.IsNotNullOrEmpty(nameof(BirthDate)));
        
        model!.AddNotifications(Notifications);
    }
}