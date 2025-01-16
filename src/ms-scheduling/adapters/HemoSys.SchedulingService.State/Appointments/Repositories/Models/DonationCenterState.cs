namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record DonationCenterState
{
    [BsonElement("donationCenterId")]
    [BsonRepresentation(BsonType.String)]
    public Guid DonationCenterId { get; set; }
    
    [BsonElement("name")]
    public string Name { get;  set; } = null!;
}