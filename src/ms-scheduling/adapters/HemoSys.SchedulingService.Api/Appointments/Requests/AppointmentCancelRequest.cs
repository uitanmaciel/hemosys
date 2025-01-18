namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentCancelRequest :
    Notifier,
    IRequestToCommand<AppointmentCancelRequest, AppointmentCancelCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentCancelCommand ToCommand(AppointmentCancelRequest? request)
    {
        ValidationFields();
        return HasNotifications
            ? new AppointmentCancelCommand()
            : new AppointmentCancelCommand()
            {
                Id = Id,
                Status = request!.StatusTypes
            };
    }

    public IList<AppointmentCancelCommand> ToCommand(IList<AppointmentCancelRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentCancelRequest>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(StatusTypes), StatusTypes));
    }
}