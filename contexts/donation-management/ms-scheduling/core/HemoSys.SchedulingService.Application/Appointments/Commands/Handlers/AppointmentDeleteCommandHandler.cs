namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentDeleteCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentDeleteCommand, bool>
{
    public async Task<bool> Handle(AppointmentDeleteCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToDeleteAppointment();
        
        var appointmentDelete = await repository.DeleteAsync(appointment.Id, cancellationToken);
        if(!appointmentDelete)
        {
            request.AddNotification("Appointment Delete", "Error on delete appointment.");
            return false;
        }
        
        var appointmentDeleted = new AppointmentDeleted(appointment.Id);
        await mediator.Send(appointmentDeleted, cancellationToken);
        
        return true;
    }
}