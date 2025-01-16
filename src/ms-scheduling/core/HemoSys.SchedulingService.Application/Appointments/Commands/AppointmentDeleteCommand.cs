using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentDeleteCommand :
    Notifier,
    ICommandToDomain<AppointmentDeleteCommand, Appointment>,
    IRequest<bool>
{
    public Guid Id { get; set; }
    public AppointmentStatusTypes Status { get; set; }
    
    public Appointment ToDomain(AppointmentDeleteCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                command.Id,
                new Donor(),
                new DonationCenter(),
                default,
                command.Status,
                default);

    public IList<Appointment> ToDomain(IList<AppointmentDeleteCommand> commands)
        => commands.Select(ToDomain).ToList();
}