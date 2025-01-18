namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentDeleteRequest :
    Notifier,
    IRequestToCommand<AppointmentDeleteRequest, AppointmentDeleteCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentDeleteCommand ToCommand(AppointmentDeleteRequest? request)
    {
        ValidationFields();
        return HasNotifications
            ? new AppointmentDeleteCommand()
            : new AppointmentDeleteCommand()
            {
                Id = Id,
                Status = request!.StatusTypes
            };
    }

    public IList<AppointmentDeleteCommand> ToCommand(IList<AppointmentDeleteRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentDeleteRequest>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(StatusTypes), StatusTypes));
    }
}