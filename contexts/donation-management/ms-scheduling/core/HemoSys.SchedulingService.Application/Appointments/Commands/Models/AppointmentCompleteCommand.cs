namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public class AppointmentCompleteCommand() : 
    Notifier,
    ICommandToDomain<AppointmentCompleteCommand, Appointment>,
    IRequest<bool>
{
    private Guid Id { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }

    public AppointmentCompleteCommand(Guid id, AppointmentStatusTypes statusTypes) : this()
    {
        Id = id;
        StatusTypes = statusTypes;
    }
    
    public Appointment ToDomain(AppointmentCompleteCommand? command)
    {
        if(command is null)
            return new Appointment();
        
        return new Appointment(
            command.Id,
            new Donor(),
            new Location(),
            default,
            (Domain.Appointments.Enums.AppointmentStatusTypes)command.StatusTypes,
            default,
            string.Empty);
    }

    public IList<Appointment> ToDomain(IList<AppointmentCompleteCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}