namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentCancelCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCancelCommand, bool>
{
    public async Task<bool> Handle(AppointmentCancelCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToCancel();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentCanceled = await repository.CancelAppointmentAsync(appointment.Id, cancellationToken);
        if (!appointmentCanceled)
        {
            request.AddNotification("Appointment", "Error on cancel appointment.");
            return false;
        }

        var appointmentCanceledEvent = new AppointmentCanceledEvent(appointment);
        await mediator.Send(appointmentCanceledEvent, cancellationToken);
        return true;
    }
}