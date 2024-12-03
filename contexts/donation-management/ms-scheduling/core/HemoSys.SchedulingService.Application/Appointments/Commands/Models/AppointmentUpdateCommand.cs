namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public class AppointmentUpdateCommand :
    AppointmentCommand,
    ICommandToDomain<AppointmentUpdateCommand, Appointment>,
    IRequest<bool>
{
    public Appointment ToDomain(AppointmentUpdateCommand? command)
    {
        if (command is null)
            return new Appointment();

        return new Appointment(
            command.Id,
            Donor.ToDomain(command.Donor),
            Location.ToDomain(command.Location),
            command.ScheduledDate,
            (Domain.Appointments.Enums.AppointmentStatusTypes)command.StatusTypes,
            command.LastAppointment,
            command.Notes);
    }

    public IList<Appointment> ToDomain(IList<AppointmentUpdateCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}