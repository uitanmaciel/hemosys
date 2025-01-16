namespace HemoSys.SchedulingService.State.Appointments.Repositories;

public sealed class AppointmentReadRepository(AppointmentMongoDbContext context) : IAppointmentReadRepository
{
    public async Task<Appointment> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = await context.Appointments
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public Task<IList<Appointment>> GetAllAsync(int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = context.Appointments
            .AsQueryable()
            .Skip(skip ?? 0)
            .Take(take ?? 10)
            .ToList();
        
        var appointments = AppointmentMapper.ToDomain(query);
        return Task.FromResult(appointments);
    }

    public async Task<IList<Appointment>> GetAppointmentsByDonorIdAsync(Guid donorId, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.Donor.Id == donorId)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByDonorNameAsync(string name, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.Donor.Name.Contains(name))
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByDonationCenterIdAsync(Guid donationCenterId, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.DonationCenter.DonationCenterId == donationCenterId)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByDonationCenterNameAsync(string name, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.DonationCenter.Name.Contains(name))
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByDateAsync(DateTime date, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.ScheduledDate == date)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.ScheduledDate >= startDate && x.ScheduledDate <= endDate)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByStatusAsync(string status, int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.StatusType == status)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }

    public async Task<IList<Appointment>> GetAppointmentsByBloodTypeAsync(string bloodType, int? skip, int? take,
        CancellationToken cancellationToken = default)
    {
        var query = await context.Appointments
            .Find(x => x.Donor.BloodType == bloodType)
            .ToListAsync(cancellationToken);

        var appointment = AppointmentMapper.ToDomain(query);
        return appointment;
    }
}