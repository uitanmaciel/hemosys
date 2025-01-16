namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCompletedEventHandler(IProducer producer) : 
    EventBase,
    IRequestHandler<AppointmentCompletedEvent>
{
    public async Task Handle(AppointmentCompletedEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            queue: Queue, 
            eventName: AppointmentCompletedEvent.EventName, 
            message: request);
    }
}