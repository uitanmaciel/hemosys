namespace HemoSys.SchedulingService.Application.Appointments.Interfaces.Services;

public interface IAppointmentQueryService
{
    Task<AppointmentQuery> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAllAppointmentsAsync(int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDonorIdAsync(Guid donorId, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDonorNameAsync(string name, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDonationCenterIdAsync(Guid donationCenterId, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDonationCenterNameAsync(string name, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDateAsync(DateTime date, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByStatusAsync(string status, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
    Task<IList<AppointmentQuery>> GetAppointmentsByBloodTypeAsync(string bloodType, int? skip = 0, int? take = 10, CancellationToken cancellationToken = default);
}