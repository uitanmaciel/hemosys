using System.Globalization;

namespace HemoSys.SchedulingService.Web.Appointments.Requests;

public sealed class AppointmentCreateRequest : 
    Notifier, 
    IRequestToCommand<AppointmentCreateRequest, AppointmentCreateCommand>
{
    [JsonPropertyName("donor")]
    public DonorModel? Donor { get; set; }
    
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
    
    public AppointmentCreateCommand ToCommand(AppointmentCreateRequest? request)
    {
        ValidateFields(request!);
        if(HasNotifications)
            return new AppointmentCreateCommand();

        return new AppointmentCreateCommand(
            request!.Donor!.ToCommand(request.Donor),
            request!.Location!.ToCommand(request.Location),
            request.ScheduledDate,
            AppointmentStatusTypes.New,
            request.LastAppointmentDate,
            request.Notes
        );
    }

    public IList<AppointmentCreateCommand> ToCommand(IList<AppointmentCreateRequest> requests)
    {
        return requests.Select(ToCommand).ToList();
    }
    
    private void ValidateFields(AppointmentCreateRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentCreateRequest>()
            .IsInTheFuture(nameof(ScheduledDate), request.ScheduledDate)
            .IsNotNullOrEmpty(nameof(LastAppointmentDate), request.LastAppointmentDate.ToString(CultureInfo.InvariantCulture))
        );
    }
}