namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;

public interface IAppointmentWriteRepository : IWriteRepository<Appointment>
{
    Task<bool> ConfirmAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<bool> CancelAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<bool> CompleteAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<bool> RescheduleAppointmentAsync(Guid appointmentId, DateTime newDate, CancellationToken cancellationToken);
}