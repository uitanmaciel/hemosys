namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentConfirmRequest :
    Notifier,
    IRequestToCommand<AppointmentConfirmRequest, AppointmentConfirmCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentConfirmCommand ToCommand(AppointmentConfirmRequest? request)
    {
        ValidationFields();
        return HasNotifications
            ? new AppointmentConfirmCommand()
            : new AppointmentConfirmCommand()
            {
                Id = Id,
                Status = request!.StatusTypes
            };
    }

    public IList<AppointmentConfirmCommand> ToCommand(IList<AppointmentConfirmRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentConfirmRequest>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(StatusTypes), StatusTypes));
    }
}