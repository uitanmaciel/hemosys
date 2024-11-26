namespace HemoSys.SchedulingService.Tests.UnitTests.ForDomain;

public class DonorTests
{
    [Fact]
    public void CalculateAge_ShouldReturnCorrectAge()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor(age: 25);

        // Act
        var age = donor.GetType().GetMethod(
                "CalculateAge", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance)!
            .Invoke(donor, null);

        // Assert
        Assert.Equal(25, age);
    }
    
    [Fact]
    public void Validations_ShouldAddNotification_WhenNameIsNullOrEmpty()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor();

        // Act
        var notifications = donor.Notifications;

        // Assert
        Assert.NotEmpty(notifications);
    }
    
    [Fact]
    public void Validations_ShouldAddNotification_WhenWeightIsLessThan50()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor(
            id: Guid.CreateVersion7(DateTimeOffset.UtcNow), 
            name: "John Doe", 
            gender: "Male");

        // Act
        var notifications = donor.Notifications;

        // Assert
        Assert.NotEmpty(notifications);
    }
    
    [Fact]
    public void Validations_ShouldAddNotification_WhenAgeIsLessThan18()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor(age: 17);

        // Act
        var notifications = donor.Notifications;

        // Assert
        Assert.NotEmpty(notifications);
    }

}