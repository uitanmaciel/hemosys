using HemoSys.SchedulingService.Application.Appointments.Events.Models;
using HemoSys.SharedKernel.Stream;

namespace HemoSys.SchedulingService.Application.Appointments.Events.Handlers;

public sealed class AppointmentCreatedEventHandler(IProducer producer) : IRequestHandler<AppointmentCreatedEvent>
{
    public async Task Handle(AppointmentCreatedEvent request, CancellationToken cancellationToken)
    {
        await producer.PublishAsync(
            AppointmentEventTypes.Scheduled.ToString(), 
            AppointmentEventTypes.Scheduled.ToString(), 
            request);
    }
}