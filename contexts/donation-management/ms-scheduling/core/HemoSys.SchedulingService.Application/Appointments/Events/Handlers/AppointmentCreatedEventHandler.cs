using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCreatedEventHandler(IProducer producer) : IRequestHandler<AppointmentCreated>
{
    public async Task Handle(AppointmentCreated request, CancellationToken cancellationToken)
    {
        const string destination = "schedulingevents";
        const string eventName = "AppointmentCreated";
        
        await producer.PublishAsync(
            destination: destination, 
            eventName: eventName, 
            message: request);
    }
}