using HemoSys.SchedulingService.Application.Appointments.Commands.Models;
using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentUpdateCommand :
    Notifier,
    ICommandToDomain<AppointmentUpdateCommand, Appointment>,
    IRequest<bool>
{
    public Guid Id { get; set; }
    public DonationCenterCommand DonationCenter { get; set; } = null!;
    public DateTime ScheduleDate { get; set; }
    public AppointmentStatusTypes Status { get; set; }
    public DateTime LastDonation { get; set; }
    public IList<NoteCommand>? Notes { get; set; }
    
    public Appointment ToDomain(AppointmentUpdateCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                command.Id,
                null!,
                DonationCenter.ToDomain(command.DonationCenter),
                command.ScheduleDate,
                command.Status,
                command.LastDonation,
                new NoteCommand().ToDomain(Notes!));

    public IList<Appointment> ToDomain(IList<AppointmentUpdateCommand> commands)
        => commands.Select(ToDomain).ToList();
}