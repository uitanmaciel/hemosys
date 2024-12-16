namespace HemoSys.SchedulingService.Application.Appointments.Events.Models;

public class AppointmentCreated(Appointment appointment) : IRequest
{
    public Guid Id { get; set; } = appointment.Id;
    public string Donor { get; set; } = appointment.Donor.Name;
    public string BloodType { get; set; } = appointment.Donor.BloodType!;
    public string? Location { get; set; } = appointment.Location.Address.ToString();
    public DateTime ScheduledDate { get; set; } = appointment.ScheduledDate;
    public AppointmentStatusTypes StatusTypes { get; set; } = (AppointmentStatusTypes)appointment.StatusTypes;
}