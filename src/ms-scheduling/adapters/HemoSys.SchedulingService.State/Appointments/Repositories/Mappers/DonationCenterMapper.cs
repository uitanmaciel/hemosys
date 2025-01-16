namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public record DonationCenterMapper
{
    public static DonationCenterState ToState(DonationCenter? donationCenter)
        => donationCenter is null
        ? new DonationCenterState()
        : new DonationCenterState
        {
            DonationCenterId = donationCenter!.Id,
            Name = donationCenter.Name
        };
    
    public static IList<DonationCenterState> ToState(IList<DonationCenter> donationCenters)
        => donationCenters.Select(ToState).ToList();

    public static DonationCenter ToDomain(DonationCenterState? donationCenterState)
        => donationCenterState is null
            ? new DonationCenter()
            : new DonationCenter(
                donationCenterState!.DonationCenterId,
                donationCenterState.Name);
    
    public static IList<DonationCenter> ToDomain(IList<DonationCenterState> donationCenterStates)
        => donationCenterStates.Select(ToDomain).ToList();
}