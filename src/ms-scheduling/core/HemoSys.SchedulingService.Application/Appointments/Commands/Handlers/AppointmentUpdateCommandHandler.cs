namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentUpdateCommandHandler(IAppointmentWriteRepository repository) :
    IRequestHandler<AppointmentUpdateCommand, bool>
{
    public async Task<bool> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToUpdate();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentUpdated = await repository.UpdateAsync(appointment, cancellationToken);
        if (appointmentUpdated) return true;
        
        request.AddNotification("Appointment", "Error on update appointment.");
        return false;
    }
}