namespace HemoSys.SchedulingService.Api.Appointments.Requests.Models;

public class DonationCenterRequest :
    Notifier,
    IRequestToCommand<DonationCenterRequest, DonationCenterCommand>
{
    [JsonPropertyName("donationCenterId")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    public void Attach(DonationCenterRequest request)
    {
        Id = request.Id;
        Name = request.Name;
    }
    
    public DonationCenterCommand ToCommand(DonationCenterRequest? request)
    {
        Attach(request!);
        ValidationFields();

        return HasNotifications 
            ? new DonationCenterCommand() 
            : new DonationCenterCommand(request!.Id, request.Name);
    }

    public IList<DonationCenterCommand> ToCommand(IList<DonationCenterRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<DonationCenterRequest>()
            .IsGuidNotEmpty(nameof(Id), Id));
    }
}