namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;

public interface IAppointmentWriteRepository : IWriteRepository<Appointment>
{
    Task<bool> CancelAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task<bool> CompleteAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
}