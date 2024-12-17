namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentCompleteCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCompleteCommand, bool>
{
    public async Task<bool> Handle(AppointmentCompleteCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToComplete();
        
        if(appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }
        
        var appointmentComplete = await repository.CompleteAppointmentAsync(appointment.Id, cancellationToken);
        if (!appointmentComplete)
        {
            request.AddNotification("Appointment Complete", "Error on complete appointment.");
            return false;
        }
        
        var appointmentCompleted = new AppointmentCompleted(appointment);
        await mediator.Send(appointmentCompleted, cancellationToken);
        
        return true;
    }
}