namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentDeleteRequest : 
    Notifier,
    IRequestToCommand<AppointmentDeleteRequest, AppointmentDeleteCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;
    
    public AppointmentDeleteCommand ToCommand(AppointmentDeleteRequest? request)
    {
        ValidateFields(request!);
        if(HasNotifications)
            return new AppointmentDeleteCommand();

        return new AppointmentDeleteCommand(
            request!.Id,
            Enum.Parse<AppointmentStatusTypes>(request.StatusTypes)
        );
    }

    public IList<AppointmentDeleteCommand> ToCommand(IList<AppointmentDeleteRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
    
    private void ValidateFields(AppointmentDeleteRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentDeleteRequest>()
            .IsGuidNotEmpty(nameof(Id), request.Id)
        );
    }
}