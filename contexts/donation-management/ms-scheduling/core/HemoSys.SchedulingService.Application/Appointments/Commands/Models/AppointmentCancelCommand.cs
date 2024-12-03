namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record AppointmentCancelCommand(Guid AppointmentId) : IRequest;