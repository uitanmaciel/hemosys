namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentRescheduleCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentRescheduleCommand, bool>
{
    public async Task<bool> Handle(AppointmentRescheduleCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToReschedule();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentRescheduled = await repository.RescheduleAppointmentAsync(appointment.Id, appointment.ScheduledDate, cancellationToken);
        if (!appointmentRescheduled)
        {
            request.AddNotification("Appointment", "Error on reschedule appointment.");
            return false;
        }

        var appointmentRescheduledEvent = new AppointmentRescheduledEvent(appointment);
        await mediator.Send(appointmentRescheduledEvent, cancellationToken);
        return true;
    }
}