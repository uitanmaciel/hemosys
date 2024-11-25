namespace HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

public record DonorEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? BloodType { get; set; }
    public double Weight { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = null!;

    public DonorEvent ToEvent(Donor donor)
    {
        return new DonorEvent
        {
            Id = donor.Id,
            BloodType = donor.BloodType,
            Weight = donor.Weight,
            BirthDate = donor.BirthDate,
            Gender = donor.Gender
        };
    }
}