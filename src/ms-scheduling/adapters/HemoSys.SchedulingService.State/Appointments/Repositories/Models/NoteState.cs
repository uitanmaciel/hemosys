namespace HemoSys.SchedulingService.State.Appointments.Repositories.Models;

public record NoteState
{
    [BsonElement("content")]
    public string Content { get; init; } = string.Empty;
}