namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentUpdateCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentUpdateCommand, bool>
{
    public async Task<bool> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToUpdateAppointment();

        if(appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }
        
        var appointmentUpdate = await repository.UpdateAsync(appointment, cancellationToken);
        if(!appointmentUpdate)
        {
            request.AddNotification("Appointment Update", "Error on update appointment.");
            return false;
        }
        
        var appointmentUpdated = new AppointmentUpdated(appointment);
        await mediator.Send(appointmentUpdated, cancellationToken);
        return true;
    }
}