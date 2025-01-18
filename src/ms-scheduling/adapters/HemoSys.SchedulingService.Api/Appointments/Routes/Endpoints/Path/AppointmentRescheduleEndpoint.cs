using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Path;

public class AppointmentRescheduleEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("/reschedule", async (IAppointmentCommandService service, AppointmentRescheduleRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentRescheduleAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error rescheduling appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentReschedule")
        .WithSummary("Reschedule an appointment")
        .WithDescription("Reschedule an existing appointment for a donor")
        .WithOrder(6);
    }
}