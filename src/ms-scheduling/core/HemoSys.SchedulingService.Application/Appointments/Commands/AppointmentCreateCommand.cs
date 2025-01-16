using HemoSys.SchedulingService.Application.Appointments.Commands.Models;
using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentCreateCommand :
    Notifier,
    ICommandToDomain<AppointmentCreateCommand, Appointment>,
    IRequest<bool>
{
    public DonorCommand Donor { get; set; } = null!;
    public DonationCenterCommand DonationCenter { get; set; } = null!;
    public DateTime ScheduleDate { get; set; }
    public DateTime LastDonation { get; set; }
    public IList<NoteCommand>? Notes { get; set; }
    
    public Appointment ToDomain(AppointmentCreateCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                Guid.Empty,
                Donor.ToDomain(command.Donor),
                DonationCenter.ToDomain(command.DonationCenter),
                command.ScheduleDate,
                AppointmentStatusTypes.Scheduled,
                command.LastDonation,
                new NoteCommand().ToDomain(Notes!));

    public IList<Appointment> ToDomain(IList<AppointmentCreateCommand> commands)
        => commands.Select(ToDomain).ToList();
}