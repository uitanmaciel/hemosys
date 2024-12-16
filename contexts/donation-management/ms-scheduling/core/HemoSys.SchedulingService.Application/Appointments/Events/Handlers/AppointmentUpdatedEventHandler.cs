using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public class AppointmentUpdatedEventHandler(IProducer producer) : IRequestHandler<AppointmentUpdated>
{
    public async Task Handle(AppointmentUpdated request, CancellationToken cancellationToken)
    {
        const string destination = "schedulingevents";
        const string eventName = "AppointmentUpdated";
        
        await producer.PublishAsync(
            destination: destination, 
            eventName: eventName, 
            message: request);
    }
}