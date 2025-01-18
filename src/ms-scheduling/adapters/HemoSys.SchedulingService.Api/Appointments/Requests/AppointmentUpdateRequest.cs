using HemoSys.SchedulingService.Api.Appointments.Requests.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentUpdateRequest :
    Notifier,
    IRequestToCommand<AppointmentUpdateRequest, AppointmentUpdateCommand>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("donationCenter")]
    public DonationCenterRequest? DonationCenter { get; set; }
    
    [JsonPropertyName("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [JsonPropertyName("notes")]
    public IList<NoteRequest>? Notes { get; set; }
    
    public AppointmentUpdateCommand ToCommand(AppointmentUpdateRequest? request)
    {
        ValidateFields(request!);
        return HasNotifications
            ? new AppointmentUpdateCommand()
            : new AppointmentUpdateCommand()
            {
                Id = Id,
                DonationCenter = DonationCenter!.ToCommand(request!.DonationCenter),
                ScheduleDate = ScheduledDate,
                Notes = new NoteRequest().ToCommand(Notes!)
            };
    }

    public IList<AppointmentUpdateCommand> ToCommand(IList<AppointmentUpdateRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidateFields(AppointmentUpdateRequest request)
    {
        AddNotifications(new ValidationRules<AppointmentUpdateRequest>()
            .IsGuidNotEmpty(nameof(Id), request.Id)
        );
    }
}