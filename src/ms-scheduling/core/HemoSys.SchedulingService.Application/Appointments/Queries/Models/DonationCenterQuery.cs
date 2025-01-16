namespace HemoSys.SchedulingService.Application.Appointments.Queries.Models;

public record DonationCenterQuery
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    
    public static DonationCenterQuery ToQuery(DonationCenter? donationCenter)
        => donationCenter is null
            ? new DonationCenterQuery()
            : new DonationCenterQuery
            {
                Id = donationCenter.Id,
                Name = donationCenter.Name
            };
    
    public static IList<DonationCenterQuery> ToQuery(IList<DonationCenter> donationCenters)
        => donationCenters.Select(ToQuery).ToList();
}