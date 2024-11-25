using HemoSys.SchedulingService.Application.Appointments.Events.Models;

namespace HemoSys.SchedulingService.Application.Appointments.Commands.Handlers;

public class AppointmentCreateCommandHandler(IAppointmentWriteRepository repository, ISender mediator) :
    IRequestHandler<AppointmentCreateCommand, bool>
{
    public async Task<bool> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var appointment = request.ToDomain(request);
        appointment.ApplyRuleToSchedule();

        var appointmentCreate = await repository.AddAsync(appointment, cancellationToken);
        if(!appointmentCreate)
        {
            request.AddNotification("Appointment Create", "Error on create appointment.");
            return false;
        }

        var appointmentCreatedEvent = new AppointmentCreatedEvent().ToEvent(appointment);
        await mediator.Send(appointmentCreatedEvent, cancellationToken);
        
        return true;
    }
}