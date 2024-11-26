using HemoSys.SchedulingService.Domain.Appointments.Aggregates;
using HemoSys.SchedulingService.Domain.Appointments.Entities;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.Domain.Appointments.ValueObjects;

namespace HemoSys.SchedulingService.Tests.UnitTests.ForDomain;

public static class AppointmentTestFactory
{
    public static Donor CreateDonor(
        Guid? id = null, 
        string? name = null, 
        string? gender = "Male", 
        int age = 30)
    {
        return new Donor(
            id ?? Guid.CreateVersion7(DateTimeOffset.UtcNow),
            name!,
            "O+",
            49,
            gender!,
            DateTime.Now.AddYears(-age));
    }

    public static Address CreateAddress()
    {
        return new Address(
            "1234 Main St",
            "Apt 101",
            "Anytown",
            "WA",
            "98001",
            "USA");
    }
    
    public static Location CreateLocation()
    {
        return new Location("Clinic A", CreateAddress());
    }
    
    public static Appointment CreateAppointment(
        Guid? id = null, 
        Donor? donor = null, 
        Location? location = null, 
        DateTime? appointmentDate = null, 
        AppointmentStatusTypes status = AppointmentStatusTypes.Confirmed,
        string? notes = null)
    {
        return new Appointment(
            id ?? Guid.CreateVersion7(),
            donor ?? CreateDonor(),
            location ?? CreateLocation(),
            appointmentDate ?? DateTime.Now.AddDays(5),
            status,
            notes);
    }
}