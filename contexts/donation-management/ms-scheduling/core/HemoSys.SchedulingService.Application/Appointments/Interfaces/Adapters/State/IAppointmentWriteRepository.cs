namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;

public interface IAppointmentWriteRepository : IWriteRepository<Appointment>
{
    Task CancelAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
    Task CompleteAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken);
}