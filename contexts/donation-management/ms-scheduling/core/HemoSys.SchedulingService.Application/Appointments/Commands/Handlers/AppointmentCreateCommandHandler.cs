namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentCreateCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCreateCommand, bool>
{
    public async Task<bool> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRulesToCreateAppointment();

        var appointmentCreate = await repository.AddAsync(appointment, cancellationToken);
        if(!appointmentCreate)
        {
            request.AddNotification("Appointment Create", "Error on create appointment.");
            return false;
        }

        var appointmentCreated = new AppointmentCreated(appointment);
        await mediator.Send(appointmentCreated, cancellationToken);
        
        return true;
    }
}