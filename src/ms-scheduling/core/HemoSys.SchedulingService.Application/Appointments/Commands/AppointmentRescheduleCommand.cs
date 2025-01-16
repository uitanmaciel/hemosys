using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentRescheduleCommand :
    Notifier,
    ICommandToDomain<AppointmentRescheduleCommand, Appointment>,
    IRequest<bool>
{
    public Guid Id { get; set; }
    public DateTime NewDate { get; set; }
    
    public Appointment ToDomain(AppointmentRescheduleCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                command.Id,
                new Donor(),
                new DonationCenter(),
                command.NewDate,
                AppointmentStatusTypes.None,
                default);

    public IList<Appointment> ToDomain(IList<AppointmentRescheduleCommand> commands)
        => commands.Select(ToDomain).ToList();
}