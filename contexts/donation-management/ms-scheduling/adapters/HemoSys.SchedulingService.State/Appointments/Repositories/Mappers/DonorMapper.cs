using HemoSys.SchedulingService.Domain.Appointments.Entities;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public sealed class DonorMapper : IConvertToState<DonorState, Donor>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? BloodType { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    
    public DonorState ToState(Donor? domain)
    {
        return domain is null
            ? new DonorState()
            : new DonorState
            {
                Id = domain.Id,
                Name = domain.Name,
                BloodType = domain.BloodType,
                Weight = domain.Weight,
                Gender = domain.Gender,
                BirthDate = domain.BirthDate
            };
    }

    public Donor ToDomain(DonorState? state)
    {
        return state is null
            ? new Donor()
            : new Donor(
                state.Id, 
                state.Name, 
                state.BloodType, 
                state.Weight,
                state.Gender,
                state.BirthDate);
    }

    public IList<DonorState> ToState(IList<Donor> domains)
    {
        return domains.Select(ToState).ToList();
    }

    public IList<Donor> ToDomain(IList<DonorState> states)
    {
        return states.Select(ToDomain).ToList();
    }
}