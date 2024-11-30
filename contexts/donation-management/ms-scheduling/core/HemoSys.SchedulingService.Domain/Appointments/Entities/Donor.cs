namespace HemoSys.SchedulingService.Domain.Appointments.Entities;

public sealed class Donor : Entity
{
    public string Name { get; private set; } = null!;
    public string? BloodType { get; private set; }
    public double Weight { get; private set; }
    public string Gender { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    
    public Donor() { }

    public Donor(Guid id, string name, string? bloodType, double weight, string gender, DateTime birthDate) : base(id)
    {
        Name = name;
        BloodType = bloodType;
        Weight = weight;
        Gender = gender;
        BirthDate = birthDate;
        Validations();
    }
    
    private int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        if (BirthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    private void Validations()
    {
        AddNotifications(new ValidationRules<Donor>()
            .IsNotNullOrEmpty(nameof(Name), Name)
            .IsGreaterThan(nameof(Weight), Weight, 50)
            .IsGreaterThan("Age", CalculateAge(), 18)
        );
    }
}