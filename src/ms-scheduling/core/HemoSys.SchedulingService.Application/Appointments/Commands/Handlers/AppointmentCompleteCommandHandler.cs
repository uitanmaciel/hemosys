namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentCompleteCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCompleteCommand, bool>
{
    public async Task<bool> Handle(AppointmentCompleteCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToComplete();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentCompleted = await repository.CompleteAppointmentAsync(appointment.Id, cancellationToken);
        if (!appointmentCompleted)
        {
            request.AddNotification("Appointment", "Error on complete appointment.");
            return false;
        }

        var appointmentCompletedEvent = new AppointmentCompletedEvent(appointment);
        await mediator.Send(appointmentCompletedEvent, cancellationToken);
        return true;
    }
}