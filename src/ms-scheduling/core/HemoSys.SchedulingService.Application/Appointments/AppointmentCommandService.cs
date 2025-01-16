namespace HemoSys.SchedulingService.Application.Appointments;

public sealed class AppointmentCommandService(ISender mediator) : IAppointmentCommandService
{
    public async Task<bool> AppointmentCreateAsync(AppointmentCreateCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentUpdateAsync(AppointmentUpdateCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentDeleteAsync(AppointmentDeleteCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentCancelAsync(AppointmentCancelCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentConfirmAsync(AppointmentConfirmCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentCompleteAsync(AppointmentCompleteCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);

    public async Task<bool> AppointmentRescheduleAsync(AppointmentRescheduleCommand command, CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}