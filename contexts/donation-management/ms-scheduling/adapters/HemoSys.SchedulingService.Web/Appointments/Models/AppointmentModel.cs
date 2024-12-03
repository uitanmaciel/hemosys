using System.Globalization;

namespace HemoSys.SchedulingService.Web.Appointments.Models;

public abstract class AppointmentModel : Notifier
{
    [JsonPropertyName("donor")]
    public DonorModel? Donor { get; set; }
    
    [JsonPropertyName("location")]
    public LocationModel? Location { get; set; }
    
    [JsonPropertyName("scheduledDate")]
    public DateTime ScheduledDate { get; set; }
    
    [JsonPropertyName("lastAppointmentDate")]
    public DateTime LastAppointmentDate { get; set; }
    
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
    
    protected AppointmentModel() { }

    protected AppointmentModel(
        DonorModel? donor, 
        LocationModel? location, 
        DateTime scheduledDate,
        DateTime lastAppointmentDate,
        string? notes)
    {
        Donor = donor;
        Location = location;
        ScheduledDate = scheduledDate;
        LastAppointmentDate = lastAppointmentDate;
        Notes = notes;
        
        ValidateFields();
    }
    
    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<AppointmentModel>()
            .IsInTheFuture(nameof(ScheduledDate), ScheduledDate)
            .IsNotNullOrEmpty(nameof(LastAppointmentDate), LastAppointmentDate.ToString(CultureInfo.InvariantCulture))
        );
    }
}