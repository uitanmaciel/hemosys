namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public class AppointmentCancelCommand() :
    Notifier,
    ICommandToDomain<AppointmentCancelCommand, Appointment>,
    IRequest<bool>
{
    private Guid Id { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }

    public AppointmentCancelCommand(Guid id, AppointmentStatusTypes statusTypes) : this()
    {
        Id = id;
        StatusTypes = statusTypes;
    }
    
    public Appointment ToDomain(AppointmentCancelCommand? command)
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

    public IList<Appointment> ToDomain(IList<AppointmentCancelCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}