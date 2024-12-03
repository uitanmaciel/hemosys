using MongoDB.Bson.Serialization.Attributes;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record AddressState
{
    [BsonElement("street")]
    public string Street { get; set; } = null!;
    
    [BsonElement("number")]
    public string Number { get; set; } = null!;
    
    [BsonElement("neighborhood")]
    public string Neighborhood { get; set; } = null!;
    
    [BsonElement("city")]
    public string City { get; set; } = null!;
    
    [BsonElement("state")]
    public string State { get; set; } = null!;
    
    [BsonElement("zipCode")]
    public string ZipCode { get; set; } = null!;
}