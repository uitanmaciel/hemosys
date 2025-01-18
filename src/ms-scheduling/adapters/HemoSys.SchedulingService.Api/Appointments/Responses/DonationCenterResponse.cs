using HemoSys.SchedulingService.Application.Appointments.Queries.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Responses;

public class DonationCenterResponse
{
    [JsonPropertyName("donationCenterId")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    public static DonationCenterResponse ToResponse(DonationCenterQuery? donationCenterQuery)
        => donationCenterQuery is null
            ? new DonationCenterResponse()
            : new DonationCenterResponse
            {
                Id = donationCenterQuery.Id,
                Name = donationCenterQuery.Name!
            };
    
    public static List<DonationCenterResponse> ToResponse(List<DonationCenterQuery> donationCenterQueries)
        => donationCenterQueries.Select(ToResponse).ToList();
}