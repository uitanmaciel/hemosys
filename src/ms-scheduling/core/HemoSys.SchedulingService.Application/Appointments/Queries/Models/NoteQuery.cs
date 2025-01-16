namespace HemoSys.SchedulingService.Application.Appointments.Queries.Models;

public record NoteQuery
{
    public string? Content { get; init; }
    
    public static NoteQuery ToQuery(Note? query)
        => query is null
        ? new NoteQuery()
        : new NoteQuery
        {
            Content = query.Content
        };
    
    public static IList<NoteQuery> ToQuery(IList<Note> queries)
        => queries.Select(ToQuery).ToList();
}