namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentCancelCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCancelCommand, bool>
{
    public async Task<bool> Handle(AppointmentCancelCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToCancel();
        
        if(appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }
        
        var appointmentDelete = await repository.CancelAppointmentAsync(appointment.Id, cancellationToken);
        if(!appointmentDelete)
        {
            request.AddNotification("Appointment Cancel", "Error on cancel appointment.");
            return false;
        }
        
        var appointmentCanceled = new AppointmentCanceled(appointment);
        await mediator.Send(appointmentCanceled, cancellationToken);
        
        return true;
    }
}