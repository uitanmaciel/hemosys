using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public class AppointmentState
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId _id { get; set; }
    
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonElement("donor")]
    public DonorState Donor { get; set; } = null!;
    
    [BsonElement("location")]
    public LocationState Location { get; set; } = null!;
    
    [BsonElement("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [BsonElement("status")]
    public string Status { get; set; } = null!;
    
    [BsonElement("lastAppointmentDate")]
    public DateTime LastAppointmentDate { get; set; }
    
    [BsonElement("notes")]
    public string? Notes { get; set; }
}