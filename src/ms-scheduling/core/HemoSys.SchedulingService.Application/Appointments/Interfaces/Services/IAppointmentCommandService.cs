namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Services;

public interface IAppointmentCommandService
{
    Task<bool> AppointmentCreateAsync(AppointmentCreateCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentUpdateAsync(AppointmentUpdateCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentDeleteAsync(AppointmentDeleteCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentCancelAsync(AppointmentCancelCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentConfirmAsync(AppointmentConfirmCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentCompleteAsync(AppointmentCompleteCommand command, CancellationToken cancellationToken = default);
    Task<bool> AppointmentRescheduleAsync(AppointmentRescheduleCommand command, CancellationToken cancellationToken = default);
}