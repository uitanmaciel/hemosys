namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentUpdateRequest :
    Notifier,
    IRequestToCommand<AppointmentUpdateRequest, AppointmentUpdateCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("location")]
    public LocationModel? Location { get; set; }
    
    [JsonPropertyName("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [JsonPropertyName("statusTypes")]
    public string StatusTypes { get; set; } = null!;

    [JsonPropertyName("lastAppointmentDate")]
    public DateTime LastAppointmentDate { get; set; }
    
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
    
    public AppointmentUpdateCommand ToCommand(AppointmentUpdateRequest? request)
    {
        ValidateFields(request!);
        if (HasNotifications)
            return new AppointmentUpdateCommand();

        return new AppointmentUpdateCommand(
            request!.Id,
            request!.Location!.ToCommand(request.Location),
            request.ScheduledDate,
            Enum.Parse<AppointmentStatusTypes>(request.StatusTypes),
            request.LastAppointmentDate,
            request.Notes
        );
    }

    public IList<AppointmentUpdateCommand> ToCommand(IList<AppointmentUpdateRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
    
    private void ValidateFields(AppointmentUpdateRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentUpdateRequest>()
            .IsGuidNotEmpty(nameof(Id), request.Id)
        );
    }
}