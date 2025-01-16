namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public record NoteMapper
{
    public static NoteState ToState(Note? domain)
        => domain is null
        ? new NoteState()
        : new NoteState
        {
            Content = domain.Content!
        };
    
    public static IList<NoteState> ToState(IList<Note> domains)
        => domains.Select(ToState).ToList();

    public static Note ToDomain(NoteState? state)
        => state is null
            ? new Note()
            : new Note(state.Content!);
    
    public static IList<Note> ToDomain(IList<NoteState> states)
        => states.Select(ToDomain).ToList();
}