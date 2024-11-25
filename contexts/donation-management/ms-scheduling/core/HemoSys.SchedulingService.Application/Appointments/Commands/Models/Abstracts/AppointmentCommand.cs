using HemoSys.SchedulingService.Application.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models.Abstracts;

public abstract class AppointmentCommand : Notifier
{
    public Guid Id { get; set; }
    public DonorCommand Donor { get; set; } = null!;
    public LocationCommand Location { get; set; } = null!;
    public DateTime ScheduledDate { get; set; }
    public AppointmentStatusTypes StatusTypes { get; set; }
    public string Notes { get; set; } = null!;
    public IList<AppointmentCommand> AppointmentCommands { get; set; } = null!;
    
    public AppointmentCommand() { }
    
    public AppointmentCommand(
        Guid id,
        DonorCommand donor,
        LocationCommand location,
        DateTime scheduledDate,
        AppointmentStatusTypes statusTypes,
        string notes,
        IList<AppointmentCommand> appointmentCommands)
    {
        Id = id;
        Donor = donor;
        Location = location;
        ScheduledDate = scheduledDate;
        StatusTypes = statusTypes;
        Notes = notes;
        AppointmentCommands = appointmentCommands;
    }
}