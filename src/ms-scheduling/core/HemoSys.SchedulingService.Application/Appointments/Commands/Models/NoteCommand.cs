using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record NoteCommand : ICommandToDomain<NoteCommand, Note>
{
    public string? Content { get; set; }
    
    public Note ToDomain(NoteCommand? command)
        => command is null
        ? new Note()
        : new Note(command.Content!);

    public IList<Note> ToDomain(IList<NoteCommand> commands)
        => commands.Select(ToDomain).ToList();
}