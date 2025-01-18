using HemoSys.SchedulingService.Application.Appointments.Queries.Models;

namespace HemoSys.SchedulingService.Api.Appointments.Responses;

public record NoteResponse
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = null!;
    
    public static NoteResponse ToResponse(NoteQuery? noteQuery)
        => noteQuery is null
            ? new NoteResponse()
            : new NoteResponse
            {
                Content = noteQuery.Content!
            };
    
    public static IList<NoteResponse> ToResponse(IList<NoteQuery> noteQueries)
        => noteQueries.Select(ToResponse).ToList();
}