using HemoSys.SchedulingService.Application.Appointments.Queries.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Responses;

public class AppointmentResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("donor")]
    public DonorResponse? Donor { get; set; }
    
    [JsonPropertyName("donationCenter")]
    public DonationCenterResponse? DonationCenter { get; set; }
    
    [JsonPropertyName("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;
    
    [JsonPropertyName("lastDonation")]
    public DateTime? LastDonation { get; set; }
    
    [JsonPropertyName("notes")]
    public IList<NoteResponse>? Notes { get; set; }
    
    public static AppointmentResponse ToResponse(AppointmentQuery? appointmentQuery)
        => appointmentQuery is null
            ? new AppointmentResponse()
            : new AppointmentResponse
            {
                Id = appointmentQuery.Id,
                Donor = DonorResponse.ToResponse(appointmentQuery.Donor),
                DonationCenter = DonationCenterResponse.ToResponse(appointmentQuery.DonationCenter),
                ScheduledDate = appointmentQuery.ScheduledDate,
                Status = appointmentQuery.Status,
                LastDonation = appointmentQuery.LastDonation,
                Notes = NoteResponse.ToResponse(appointmentQuery.Notes!)
            };
    
    public static IList<AppointmentResponse> ToResponse(IList<AppointmentQuery>? appointmentQueries)
        => appointmentQueries is null
            ? new List<AppointmentResponse>()
            : appointmentQueries.Select(ToResponse).ToList();
}