namespace HemoSys.SchedulingService.Api.Appointments.Requests.Models;

public record NoteRequest : IRequestToCommand<NoteRequest, NoteCommand>
{
    [JsonPropertyName("content")]
    public string? Content { get; init; }
    
    public NoteCommand ToCommand(NoteRequest? request)
        => request is null
            ? new NoteCommand()
            : new NoteCommand()
            {
                Content = request.Content
            };

    public IList<NoteCommand> ToCommand(IList<NoteRequest> requests)
        => requests.Select(ToCommand).ToList();
}