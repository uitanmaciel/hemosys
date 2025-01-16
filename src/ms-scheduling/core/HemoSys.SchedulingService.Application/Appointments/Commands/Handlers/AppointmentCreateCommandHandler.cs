namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public sealed class AppointmentCreateCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCreateCommand, bool>
{
    public async Task<bool> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToCreate();

        if (appointment.HasNotifications)
        {
            request.AddNotifications(appointment.Notifications);
            return false;
        }
        
        var appointmentSaved = await repository.AddAsync(appointment, cancellationToken);
        if(!appointmentSaved)
        {
            request.AddNotification("Appointment", "Error on create appointment.");
            return false;
        }
        
        var appointmentCreatedEvent = new AppointmentCreatedEvent(appointment);
        await mediator.Send(appointmentCreatedEvent, cancellationToken);
        return true;
    }
}