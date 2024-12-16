namespace HemoSys.SchedulingService.Application.Appointments.Commands.Interfaces;

public interface IAppointmentCommandService
{
    Task<bool> CreateAppointmentAsync(AppointmentCreateCommand command, CancellationToken cancellationToken);
    Task<bool> UpdateAppointmentAsync(AppointmentUpdateCommand command, CancellationToken cancellationToken);
    Task<bool> DeleteAppointmentAsync(AppointmentDeleteCommand command, CancellationToken cancellationToken);
    Task<bool> CancelAppointmentAsync(AppointmentCancelCommand command, CancellationToken cancellationToken);
    Task<bool> CompleteAppointmentAsync(AppointmentCompleteCommand command, CancellationToken cancellationToken);
}