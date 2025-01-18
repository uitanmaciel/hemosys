namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentCompleteRequest :
    Notifier,
    IRequestToCommand<AppointmentCompleteRequest, AppointmentCompleteCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentCompleteCommand ToCommand(AppointmentCompleteRequest? request)
    {
        ValidationFields();
        return HasNotifications
            ? new AppointmentCompleteCommand()
            : new AppointmentCompleteCommand()
            {
                Id = Id,
                Status = request!.StatusTypes
            };
    }

    public IList<AppointmentCompleteCommand> ToCommand(IList<AppointmentCompleteRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentCompleteRequest>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(StatusTypes), StatusTypes));
    }
}