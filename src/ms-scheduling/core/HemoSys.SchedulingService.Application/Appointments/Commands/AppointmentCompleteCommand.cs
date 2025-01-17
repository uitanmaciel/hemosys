using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentCompleteCommand :
    Notifier,
    ICommandToDomain<AppointmentCompleteCommand, Appointment>,
    IRequest<bool>
{
    public Guid Id { get; set; }
    public string Status { get; set; } = string.Empty;
    
    public Appointment ToDomain(AppointmentCompleteCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                command.Id,
                new Donor(),
                new DonationCenter(),
                default,
                Enum.Parse<AppointmentStatusTypes>(command.Status),
                default);

    public IList<Appointment> ToDomain(IList<AppointmentCompleteCommand> commands)
        => commands.Select(ToDomain).ToList();
}