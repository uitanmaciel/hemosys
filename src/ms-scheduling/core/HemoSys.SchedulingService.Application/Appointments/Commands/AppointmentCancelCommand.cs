using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.Application.Appointments.Commands;

public class AppointmentCancelCommand :
    Notifier,
    ICommandToDomain<AppointmentCancelCommand, Appointment>,
    IRequest<bool>
{
    public Guid Id { get; set; }
    public string Status { get; set; } = string.Empty;
    
    public Appointment ToDomain(AppointmentCancelCommand? command)
        => command is null
            ? new Appointment()
            : new Appointment(
                command.Id,
                new Donor(),
                new DonationCenter(),
                default,
                Enum.Parse<AppointmentStatusTypes>(command.Status),
                default);

    public IList<Appointment> ToDomain(IList<AppointmentCancelCommand> commands)
        => commands.Select(ToDomain).ToList();
}