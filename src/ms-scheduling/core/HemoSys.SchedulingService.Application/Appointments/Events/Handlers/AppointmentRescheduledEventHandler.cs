namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentRescheduledEventHandler(IProducer producer) : 
    EventBase,
    IRequestHandler<AppointmentRescheduledEvent>
{
    public async Task Handle(AppointmentRescheduledEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            queue: Queue, 
            eventName: AppointmentRescheduledEvent.EventName, 
            message: request);
    }
}