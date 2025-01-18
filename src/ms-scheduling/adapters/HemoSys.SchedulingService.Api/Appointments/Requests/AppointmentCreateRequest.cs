using HemoSys.SchedulingService.Api.Appointments.Requests.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Requests;

public class AppointmentCreateRequest :
    Notifier,
    IRequestToCommand<AppointmentCreateRequest, AppointmentCreateCommand>
{
    [JsonPropertyName("donor")]
    public DonorRequest? Donor { get; set; }
    
    [JsonPropertyName("donationCenter")]
    public DonationCenterRequest? DonationCenter { get; set; }
    
    [JsonPropertyName("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [JsonPropertyName("lastDonation")]
    public DateTime LastDonation { get; set; }
    
    [JsonPropertyName("notes")]
    public IList<NoteRequest>? Notes { get; set; }

    public AppointmentCreateCommand ToCommand(AppointmentCreateRequest? request)
    {
        Donor!.Attach(request.Donor);
        DonationCenter!.Attach(request.DonationCenter);
        ValidationFields();
        
        return HasNotifications 
            ? new AppointmentCreateCommand() 
            : new AppointmentCreateCommand()
            {
                Donor = Donor.ToCommand(request.Donor),
                DonationCenter = DonationCenter.ToCommand(request.DonationCenter),
                ScheduleDate = ScheduledDate,
                LastDonation = LastDonation,
                Notes = new NoteRequest().ToCommand(Notes!)
            };
    }

    public IList<AppointmentCreateCommand> ToCommand(IList<AppointmentCreateRequest> requests)
        => requests.Select(ToCommand).ToList();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<AppointmentCreateRequest>()
            .IsInTheFuture(nameof(ScheduledDate), ScheduledDate));
        
        if(Donor!.HasNotifications)
            AddNotification(Donor.Notifications);
        
        if(DonationCenter!.HasNotifications)
            AddNotification(DonationCenter.Notifications);
    }
}