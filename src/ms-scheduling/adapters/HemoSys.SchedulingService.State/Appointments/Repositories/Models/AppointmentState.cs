namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record AppointmentState
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId _Id { get; set; }
    
    [BsonElement("id")]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    [BsonElement("donor")]
    public DonorState Donor { get; set; } = null!;
    
    [BsonElement("donationCenter")]
    public DonationCenterState DonationCenter { get; set; } = null!;
    
    [BsonElement("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [BsonElement("statusType")]
    public string StatusType { get; set; } = null!;
    
    [BsonElement("lastDonation")]
    public DateTime LastDonation { get; set; }
    
    [BsonElement("notes")]
    public IList<NoteState>? Notes { get; set; }
}