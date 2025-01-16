namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record DonorState
{
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; } = null!;
    
    [BsonElement("bloodType")]
    public string? BloodType { get; set; }
    
    [BsonElement("weight")]
    public double Weight { get; set; }
    
    [BsonElement("gender")]
    public string Gender { get; set; } = null!;
    
    [BsonElement("birthDate")]
    public DateTime BirthDate { get; set; }
}