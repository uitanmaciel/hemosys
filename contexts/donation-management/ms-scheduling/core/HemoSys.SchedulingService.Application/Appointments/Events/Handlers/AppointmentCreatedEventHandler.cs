using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCreatedEventHandler(IProducer producer) : IRequestHandler<AppointmentCreated>
{
    public async Task Handle(AppointmentCreated request, CancellationToken cancellationToken)
    {
        var @event = request.ToMessage();
        await producer.PublishAsync(
            destination: @event.destination, 
            eventName: @event.eventType, 
            message: @event.message);
    }
}