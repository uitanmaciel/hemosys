namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;

public interface IAppointmentReadRepository : IReadRepository<Appointment>
{
    Task<IList<Appointment>> GetAppointmentsByDonorIdAsync(Guid donorId, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByDonorNameAsync(string name, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByDonationCenterIdAsync(Guid donationCenterId, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByDonationCenterNameAsync(string name, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByDateAsync(DateTime date, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByStatusAsync(string status, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<Appointment>> GetAppointmentsByBloodTypeAsync(string bloodType, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
}