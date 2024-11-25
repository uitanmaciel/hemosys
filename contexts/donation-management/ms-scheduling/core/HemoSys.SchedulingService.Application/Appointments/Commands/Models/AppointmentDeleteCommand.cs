namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record AppointmentDeleteCommand(Guid AppointmentId) : IRequest;