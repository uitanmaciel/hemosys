namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public class AppointmentDeleteCommand :
    Notifier,
    ICommandToDomain<AppointmentDeleteCommand, Appointment>,
    IRequest<bool>
{
    private Guid Id { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }
    
    public AppointmentDeleteCommand() { }
    
    public AppointmentDeleteCommand(Guid id, AppointmentStatusTypes statusTypes)
    {
        Id = id;
        StatusTypes = statusTypes;
    }
    
    public Appointment ToDomain(AppointmentDeleteCommand? command)
    {
        if (command is null)
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

    public IList<Appointment> ToDomain(IList<AppointmentDeleteCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}