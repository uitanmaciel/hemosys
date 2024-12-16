using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public class AppointmentCancelEventHanlder(IProducer producer) : IRequestHandler<AppointmentCanceled>
{
    public async Task Handle(AppointmentCanceled request, CancellationToken cancellationToken)
    {
        const string destination = "schedulingevents";
        const string eventName = "AppointmentCanceled";
        
        await producer.PublishAsync(
            destination: destination, 
            eventName: eventName, 
            message: request);
    }
}