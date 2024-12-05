using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public class AppointmentUpdatedEventHandler(IProducer producer) : IRequestHandler<AppointmentUpdated>
{
    public async Task Handle(AppointmentUpdated request, CancellationToken cancellationToken)
    {
        var @event = request.ToMessage();
        await producer.PublishAsync(
            destination: @event.destination, 
            eventName: @event.eventType, 
            message: @event.message);
    }
}