using HemoSys.SchedulingService.Application.Appointments.Queries.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Responses;

public record DonorResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("bloodType")]
    public string? BloodType { get; set; }
    
    [JsonPropertyName("weight")]
    public double Weight { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; } = null!;
    
    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    public static DonorResponse ToResponse(DonorQuery? donorQuery)
        => donorQuery is null
            ? new DonorResponse()
            : new DonorResponse
            {
                Id = donorQuery.Id,
                Name = donorQuery.Name!,
                BloodType = donorQuery.BloodType,
                Weight = donorQuery.Weight,
                Gender = donorQuery.Gender,
                BirthDate = donorQuery.BirthDate
            };
    
    public static List<DonorResponse> ToResponse(List<DonorQuery> donorQueries)
        => donorQueries.Select(ToResponse).ToList();
}