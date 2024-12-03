namespace HemoSys.SchedulingService.Application.Appointments.Commands.Models;

public record AppointmentCompleteCommand(Guid AppointmentId) : IRequest;