using HemoSys.SchedulingService.Domain.Appointments.Entities;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public record DonorMapper
{
    public static DonorState ToState(Donor? donor)
        => donor is null
        ? new DonorState()
        : new DonorState
        {
            Id = donor!.Id,
            Name = donor.Name,
            BloodType = donor.BloodType,
            Weight = donor.Weight,
            Gender = donor.Gender,
            BirthDate = donor.BirthDate
        };
    
    public static IList<DonorState> ToState(IList<Donor> donors)
        => donors.Select(ToState).ToList();

    public static Donor ToDomain(DonorState? donorState)
        => donorState is null
            ? new Donor()
            : new Donor(
                donorState!.Id,
                donorState.Name,
                donorState.BloodType!,
                donorState.Weight,
                donorState.Gender,
                donorState.BirthDate);
    
    public static IList<Donor> ToDomain(IList<DonorState> donorStates)
        => donorStates.Select(ToDomain).ToList();
}