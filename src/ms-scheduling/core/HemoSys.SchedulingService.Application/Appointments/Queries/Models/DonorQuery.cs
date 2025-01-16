namespace HemoSys.SchedulingService.Application.Appointments.Queries.Models;

public record DonorQuery
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? BloodType { get; init; }
    public double Weight { get; init; }
    public string Gender { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }

    public static DonorQuery ToQuery(Donor? query)
        => query is null
            ? new DonorQuery()
            : new DonorQuery
            {
                Id = query.Id,
                Name = query.Name,
                BloodType = query.BloodType,
                Weight = query.Weight,
                Gender = query.Gender,
                BirthDate = query.BirthDate
            };
    
    public static IList<DonorQuery> ToQuery(IList<Donor> queries)
        => queries.Select(ToQuery).ToList();
}