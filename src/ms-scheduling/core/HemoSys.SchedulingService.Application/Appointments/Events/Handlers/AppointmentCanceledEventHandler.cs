namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCanceledEventHandler(IProducer producer) : 
    EventBase,
    IRequestHandler<AppointmentCanceledEvent>
{
    public async Task Handle(AppointmentCanceledEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            queue: Queue, 
            eventName: AppointmentCanceledEvent.EventName, 
            message: request);
    }
}