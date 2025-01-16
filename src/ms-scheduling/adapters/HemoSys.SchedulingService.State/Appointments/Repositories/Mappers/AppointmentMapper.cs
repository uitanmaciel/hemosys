using HemoSys.SchedulingService.Domain.Appointments.Aggregates;
using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;

public record AppointmentMapper
{
    public static AppointmentState ToState(Appointment? appointment)
        => appointment is null
        ? new AppointmentState()
        : new AppointmentState
        {
            Id = appointment!.Id,
            Donor = DonorMapper.ToState(appointment.Donor),
            DonationCenter = DonationCenterMapper.ToState(appointment.DonationCenter),
            ScheduledDate = appointment.ScheduledDate,
            StatusType = appointment.StatusTypes.ToString(),
            LastDonation = appointment.LastDonation,
            Notes = NoteMapper.ToState(appointment.Notes!)
        };
    
    public static IList<AppointmentState> ToState(IList<Appointment> appointments)
        => appointments.Select(ToState).ToList();

    public static Appointment ToDomain(AppointmentState? appointmentState)
        => appointmentState is null
            ? new Appointment()
            : new Appointment(
                appointmentState!.Id,
                DonorMapper.ToDomain(appointmentState.Donor),
                DonationCenterMapper.ToDomain(appointmentState.DonationCenter),
                appointmentState.ScheduledDate,
                Enum.Parse<AppointmentStatusTypes>(appointmentState.StatusType),
                appointmentState.LastDonation,
                NoteMapper.ToDomain(appointmentState.Notes!));
    
    public static IList<Appointment> ToDomain(IList<AppointmentState> appointmentStates)
        => appointmentStates.Select(ToDomain).ToList();
}