namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentDeleteCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentDeleteCommand, bool>
{
    public async Task<bool> Handle(AppointmentDeleteCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToDelete();
        
        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }

        var appointmentDeleted = await repository.DeleteAsync(appointment.Id, cancellationToken);
        if (!appointmentDeleted)
        {
            request.AddNotification("Appointment", "Error on delete appointment.");
            return false;
        }

        var appointmentDeletedEvent = new AppointmentDeletedEvent(appointment);
        await mediator.Send(appointmentDeletedEvent, cancellationToken);
        return true;
    }
}