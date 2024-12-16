namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentCancelRequest :
    Notifier,
    IRequestToCommand<AppointmentCancelRequest, AppointmentCancelCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentCancelCommand ToCommand(AppointmentCancelRequest? request)
    {
        ValidateFields(request!);
        if(HasNotifications)
            return new AppointmentCancelCommand();
        
        return new AppointmentCancelCommand(
            id: request!.Id, 
            statusTypes: Enum.Parse<AppointmentStatusTypes>(request.StatusTypes));
    }

    public IList<AppointmentCancelCommand> ToCommand(IList<AppointmentCancelRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
    
    private void ValidateFields(AppointmentCancelRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentCancelRequest>()
            .IsGuidNotEmpty(nameof(Id), request.Id)
        );
    }
}