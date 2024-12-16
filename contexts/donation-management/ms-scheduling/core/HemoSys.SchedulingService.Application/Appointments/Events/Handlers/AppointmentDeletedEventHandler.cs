using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public class AppointmentDeletedEventHandler(IProducer producer) : IRequestHandler<AppointmentDeleted>
{
    public async Task Handle(AppointmentDeleted request, CancellationToken cancellationToken)
    {
        const string destination = "schedulingevents";
        const string eventName = "AppointmentDeleted";
        
        await producer.PublishAsync(
            destination: destination, 
            eventName: eventName, 
            message: request);
    }
}