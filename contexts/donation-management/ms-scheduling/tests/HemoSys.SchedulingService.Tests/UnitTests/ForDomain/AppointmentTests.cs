using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.Tests.UnitTests.ForDomain;

public class AppointmentTests
{
    [Fact]
    public void CalculateDaysSinceLastDonation_ShouldReturnCorrectDays_WhenCompletedAppointmentsExist()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor();
        var appointment = AppointmentTestFactory.CreateAppointment(donor: donor);
        
        // Add completed appointments
        var completedAppointment = AppointmentTestFactory.CreateAppointment(
            donor: donor, appointmentDate: DateTime.Now.AddDays(-100), status: AppointmentStatusTypes.Completed);
        appointment.Appointments.Add(completedAppointment);
        
        // Act
        var daysSinceLastDonation = appointment.CalculateDaysSinceLastDonation();
        
        // Assert
        Assert.Equal(104, daysSinceLastDonation);
    }

    [Fact]
    public void Validations_ShouldAddNotification_WhenScheduledDateIsInThePast()
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor();
        var appointment = AppointmentTestFactory.CreateAppointment(donor: donor, appointmentDate: DateTime.Now.AddDays(-1));
        
        // Act
        appointment.ApplyRuleToSchedule();
        
        // Assert
        Assert.True(appointment.HasNotifications);
    }
    
    [Theory]
    [InlineData("Male", 39)]
    [InlineData("Female", 79)]
    public void Validations_ShouldAddNotification_WhenDonationIntervalIsNotMet(string gender, int daysSinceLastDonation)
    {
        // Arrange
        var donor = AppointmentTestFactory.CreateDonor(gender: gender);
        var appointment = AppointmentTestFactory.CreateAppointment(donor: donor);

        var lastAppointment = AppointmentTestFactory.CreateAppointment(
            donor: donor,
            appointmentDate: DateTime.Now.AddDays(-daysSinceLastDonation),
            status: AppointmentStatusTypes.Completed);

        appointment.Appointments.Add(lastAppointment);

        // Act
        appointment.ApplyRuleToSchedule();

        // Assert
        Assert.True(appointment.HasNotifications);
    }
}