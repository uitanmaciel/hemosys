namespace HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

public class Note() : ValueObject
{
    public string? Content { get; private set; }
    public Note(string? content) : this() => Content = content;
}