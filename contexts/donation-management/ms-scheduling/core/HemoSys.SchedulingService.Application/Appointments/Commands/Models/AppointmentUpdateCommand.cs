namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public class AppointmentUpdateCommand :
    Notifier,
    ICommandToDomain<AppointmentUpdateCommand, Appointment>,
    IRequest<bool>
{
    private Guid Id { get; set; }
    private LocationCommand Location { get; set; } = null!;
    private DateTime ScheduledDate { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }
    private DateTime LastAppointment { get; set; }
    private string? Notes { get; set; } = null!;
    
    public AppointmentUpdateCommand() { }
    
    public AppointmentUpdateCommand(
        Guid id,
        LocationCommand location,
        DateTime scheduledDate,
        AppointmentStatusTypes statusTypes,
        DateTime lastAppointment,
        string? notes)
    {
        Id = id;
        Location = location;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        LastAppointment = lastAppointment;
        Notes = notes;
    }
    
    public Appointment ToDomain(AppointmentUpdateCommand? command)
    {
        if (command is null)
            return new Appointment();

        return new Appointment(
            command.Id,
            new Donor(),
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