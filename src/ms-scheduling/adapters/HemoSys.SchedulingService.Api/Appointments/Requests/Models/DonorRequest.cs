namespace HemoSys.SchedulingService.Api.Appointments.Requests.Models;

public class DonorRequest : 
    Notifier,
    IRequestToCommand<DonorRequest, DonorCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("email")]
    public string? BloodType { get; set; }
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; } = string.Empty;
    
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }
    
    public void Attach(DonorRequest request)
    {
        Id = request.Id;
        Name = request.Name;
        BloodType = request.BloodType;
        Weight = request.Weight;
        Gender = request.Gender;
        BirthDate = request.BirthDate;
    }
    
    public DonorCommand ToCommand(DonorRequest? request)
    {
        Attach(request!);
        ValidationFields();

        return HasNotifications 
            ? new DonorCommand() 
            : new DonorCommand(
                request!.Id,
                request.Name,
                request.BloodType,
                request.Weight,
                request.Gender,
                request.BirthDate);
    }

    public IList<DonorCommand> ToCommand(IList<DonorRequest> requests)
        => requests.Select(ToCommand).ToList();

    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<DonorRequest>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(Name), Name)
            .IsNotNullOrEmpty(nameof(Gender), Gender));
    }
}