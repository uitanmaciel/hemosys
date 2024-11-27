using MongoDB.Bson.Serialization.Attributes;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record LocationState
{
    [BsonElement("name")]
    public string Name { get;  set; } = null!;
    
    [BsonElement("address")]
    public AddressState Address { get; set; } = null!;
}