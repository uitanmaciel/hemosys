namespace HemoSys.SchedulingService.Application.Appointments.Queries.Models;

public record AppointmentQuery
{
    public Guid Id { get; init; }
    public DonorQuery Donor { get; init; } = null!;
    public DonationCenterQuery DonationCenter { get; init; } = null!;
    public DateTime ScheduledDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime LastDonation { get; init; }
    public IList<NoteQuery>? Notes { get; init; }
    
    public static AppointmentQuery ToQuery(Appointment? appointment)
        => appointment is null
            ? new AppointmentQuery()
            : new AppointmentQuery
            {
                Id = appointment.Id,
                Donor = DonorQuery.ToQuery(appointment.Donor),
                DonationCenter = DonationCenterQuery.ToQuery(appointment.DonationCenter),
                ScheduledDate = appointment.ScheduledDate,
                Status = appointment.StatusTypes.ToString(),
                LastDonation = appointment.LastDonation,
                Notes = NoteQuery.ToQuery(appointment.Notes!)
            };
    
    public static IList<AppointmentQuery> ToQuery(IList<Appointment> appointments)
        => appointments.Select(ToQuery).ToList();
}