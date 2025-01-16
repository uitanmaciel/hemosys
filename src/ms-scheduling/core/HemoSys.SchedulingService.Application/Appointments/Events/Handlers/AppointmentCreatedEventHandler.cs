namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCreatedEventHandler(IProducer producer) : 
    EventBase,
    IRequestHandler<AppointmentCreatedEvent>
{
    public async Task Handle(AppointmentCreatedEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            queue: Queue, 
            eventName: AppointmentCreatedEvent.EventName, 
            message: request);
    }
}