using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public sealed class AppointmentCreateCommand : 
    AppointmentCommand,
    ICommandToDomain<AppointmentCreateCommand, Appointment>,
    IRequest<bool>
{
    public AppointmentCreateCommand() { }
    
    public Appointment ToDomain(AppointmentCreateCommand? command)
    {
        if (command is null)
            return new Appointment();

        return new Appointment(
            Guid.Empty,
            Donor.ToDomain(command.Donor),
            Location.ToDomain(command.Location),
            command.ScheduledDate,
            (AppointmentStatusTypes)command.StatusTypes,
            command.Notes);
    }

    public IList<Appointment> ToDomain(IList<AppointmentCreateCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}