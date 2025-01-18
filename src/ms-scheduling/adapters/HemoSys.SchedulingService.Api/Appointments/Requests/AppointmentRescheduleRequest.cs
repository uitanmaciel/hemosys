namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentRescheduleRequest :
    Notifier,
    IRequestToCommand<AppointmentRescheduleRequest, AppointmentRescheduleCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("newDate")]
    public DateTime NewDate { get; set; }
    
    public AppointmentRescheduleCommand ToCommand(AppointmentRescheduleRequest? request)
    {
        ValidationFields();
        return HasNotifications
            ? new AppointmentRescheduleCommand()
            : new AppointmentRescheduleCommand()
            {
                Id = Id,
                NewDate = NewDate
            };
    }

    public IList<AppointmentRescheduleCommand> ToCommand(IList<AppointmentRescheduleRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentCompleteRequest>()
            .IsGuidNotEmpty(nameof(Id), Id));
    }
}