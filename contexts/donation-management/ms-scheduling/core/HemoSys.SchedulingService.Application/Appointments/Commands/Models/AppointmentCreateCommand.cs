namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public sealed class AppointmentCreateCommand :
    Notifier,
    ICommandToDomain<AppointmentCreateCommand, Appointment>,
    IRequest<bool>
{
    private DonorCommand? Donor { get; set; }
    private LocationCommand Location { get; set; } = null!;
    private DateTime ScheduledDate { get; set; }
    private AppointmentStatusTypes StatusTypes { get; set; }
    private DateTime LastAppointment { get; set; }
    private string? Notes { get; set; } = null!;
    
    public AppointmentCreateCommand() { }
    
    public AppointmentCreateCommand(
        DonorCommand donor,
        LocationCommand location,
        DateTime scheduledDate,
        AppointmentStatusTypes statusTypes,
        DateTime lastAppointment,
        string? notes)
    {
        Donor = donor;
        Location = location;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        LastAppointment = lastAppointment;
        Notes = notes;
    }

    public Appointment ToDomain(AppointmentCreateCommand? command)
    {
        if (command is null)
            return new Appointment();

        return new Appointment(
            Guid.Empty,
            Donor!.ToDomain(command.Donor),
            Location.ToDomain(command.Location),
            command.ScheduledDate,
            (Domain.Appointments.Enums.AppointmentStatusTypes)command.StatusTypes,
            command.LastAppointment,
            command.Notes);
    }

    public IList<Appointment> ToDomain(IList<AppointmentCreateCommand> commands)
    {
        return commands.Select(ToDomain).ToList();
    }
}