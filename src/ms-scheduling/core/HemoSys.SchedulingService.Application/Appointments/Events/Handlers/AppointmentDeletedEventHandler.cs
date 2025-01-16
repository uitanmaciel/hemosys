namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentDeletedEventHandler(IProducer producer) : 
    EventBase,
    IRequestHandler<AppointmentDeletedEvent>
{
    public async Task Handle(AppointmentDeletedEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            queue: Queue, 
            eventName: AppointmentDeletedEvent.EventName, 
            message: request);
    }
}