using HemoSys.SchedulingService.Domain.Appointments.Aggregates;
using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public sealed class AppointmentMapper : IConvertToState<AppointmentState, Appointment>
{
    public Guid Id { get; set; }
    public DonorState Donor { get; set; } = null!;
    public LocationState Location { get; set; } = null!;
    public DateTime ScheduledDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
    
    public AppointmentState ToState(Appointment? domain)
    {
        return domain is null
            ? new AppointmentState()
            : new AppointmentState
            {
                Id = domain.Id,
                Donor = new DonorMapper().ToState(domain.Donor),
                Location = new LocationMapper().ToState(domain.Location),
                ScheduledDate = domain.ScheduledDate,
                Status = domain.StatusTypes.ToString(),
                Notes = domain.Notes
            };
    }

    public Appointment ToDomain(AppointmentState? state)
    {
        return state is null
            ? new Appointment()
            : new Appointment(
                state.Id, 
                new DonorMapper().ToDomain(state.Donor),
                new LocationMapper().ToDomain(state.Location),
                state.ScheduledDate,
                Enum.Parse<AppointmentStatusTypes>(state.Status),
                state.Notes);

    }

    public IList<AppointmentState> ToState(IList<Appointment> domains)
    {
        return domains.Select(ToState).ToList();
    }

    public IList<Appointment> ToDomain(IList<AppointmentState> states)
    {
        return states.Select(ToDomain).ToList();
    }
}