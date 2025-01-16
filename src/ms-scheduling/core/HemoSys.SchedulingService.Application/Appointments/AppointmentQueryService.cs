namespace HemoSys.SchedulingService.Application.Appointments;

public sealed class AppointmentQueryService(IAppointmentReadRepository repository) : IAppointmentQueryService
{
    public async Task<AppointmentQuery> GetAppointmentByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetByIdAsync(id, cancellationToken);
        if (query is null)
            return new AppointmentQuery();

        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAllAppointmentsAsync(int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAllAsync(skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDonorIdAsync(Guid donorId, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDonorIdAsync(donorId, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDonorNameAsync(string name, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDonorNameAsync(name, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDonationCenterIdAsync(Guid donationCenterId, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDonationCenterIdAsync(donationCenterId, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDonationCenterNameAsync(string name, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDonationCenterNameAsync(name, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDateAsync(DateTime date, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDateAsync(date, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByDateRangeAsync(startDate, endDate, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByStatusAsync(string status, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByStatusAsync(status, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }

    public async Task<IList<AppointmentQuery>> GetAppointmentsByBloodTypeAsync(string bloodType, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await repository.GetAppointmentsByBloodTypeAsync(bloodType, skip, take, cancellationToken);
        if(!query.Any())
            return [];
        
        var result = AppointmentQuery.ToQuery(query);
        return result;
    }
}