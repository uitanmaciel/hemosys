using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public class AppointmentCompletedEventHandler(IProducer producer) : IRequestHandler<AppointmentCompleted>
{
    public async Task Handle(AppointmentCompleted request, CancellationToken cancellationToken)
    {
        const string destination = "schedulingevents";
        const string eventName = "AppointmentCompleted";
        
        await producer.PublishAsync(
            destination: destination, 
            eventName: eventName, 
            message: request);
    }
}