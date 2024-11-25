namespace HemoSys.SchedulingService.Application.Appointments.Events.Models.Abstractions;

public abstract record AppointmentEvent
{
    public Guid Id { get; set; }
    public DonorEvent Donor { get; set; } = null!;
    public LocationEvent Location { get; set; } = null!;
    public DateTime ScheduledDate { get; set; }
    public string Status { get; set; } = null!;
    public string Notes { get; set; } = null!;
}