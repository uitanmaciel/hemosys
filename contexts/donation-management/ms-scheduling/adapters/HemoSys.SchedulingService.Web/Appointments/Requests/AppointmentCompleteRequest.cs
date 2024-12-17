namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentCompleteRequest :
    Notifier,
    IRequestToCommand<AppointmentCompleteRequest, AppointmentCompleteCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentCompleteCommand ToCommand(AppointmentCompleteRequest? request)
    {
        ValidateFields(request!);
        if(HasNotifications)
            return new AppointmentCompleteCommand();
        
        return new AppointmentCompleteCommand(
            id: request!.Id, 
            statusTypes: Enum.Parse<AppointmentStatusTypes>(request.StatusTypes));
    }

    public IList<AppointmentCompleteCommand> ToCommand(IList<AppointmentCompleteRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
    
    private void ValidateFields(AppointmentCompleteRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentCancelRequest>()
            .IsGuidNotEmpty(nameof(Id), request.Id)
        );
    }
}