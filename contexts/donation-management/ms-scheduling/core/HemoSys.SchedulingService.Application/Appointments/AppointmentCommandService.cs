using HemoSys.SchedulingService.Application.Appointments.Commands.Interfaces;

namespace HemoSys.SchedulingService.Application.Appointments;

public class AppointmentCommandService(ISender mediator) : IAppointmentCommandService
{
    public async Task<bool> CreateAppointmentAsync(AppointmentCreateCommand command, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }

    public async Task<bool> UpdateAppointmentAsync(AppointmentUpdateCommand command, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }

    public Task<bool> DeleteAppointmentAsync(AppointmentDeleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CancelAppointmentAsync(AppointmentCancelCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CompleteAppointmentAsync(AppointmentCompleteCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}