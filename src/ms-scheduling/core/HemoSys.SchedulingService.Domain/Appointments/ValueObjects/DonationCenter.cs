namespace HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

public class DonationCenter() : ValueObject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    
    public DonationCenter(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
    
    public void NewDonationCenter() => ValidationFields();
    
    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<DonationCenter>()
            .IsGuidNotEmpty(nameof(Id), Id)
            .IsNotNullOrEmpty(nameof(Name), Name)
            .IsLengthLowerThan(nameof(Name), Name, 3)
        );
    }
}