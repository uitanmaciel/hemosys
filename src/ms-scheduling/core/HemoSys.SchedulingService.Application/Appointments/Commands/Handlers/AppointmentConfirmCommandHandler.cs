namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentConfirmCommandHandler(IAppointmentWriteRepository repository) :
    IRequestHandler<AppointmentConfirmCommand, bool>
{
    public async Task<bool> Handle(AppointmentConfirmCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToConfirm();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentConfirmed = await repository.ConfirmAppointmentAsync(appointment.Id, cancellationToken);
        if (appointmentConfirmed) return true;
        
        request.AddNotification("Appointment", "Error on confirm appointment.");
        return false;
    }
}