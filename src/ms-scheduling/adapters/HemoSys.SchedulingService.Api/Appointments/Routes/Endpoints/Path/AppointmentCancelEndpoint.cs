using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Path;

public class AppointmentCancelEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("/cancel", async (IAppointmentCommandService service, AppointmentCancelRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentCancelAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error canceling appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentCancel")
        .WithSummary("Cancel an appointment")
        .WithDescription("Cancel an existing appointment for a donor")
        .WithOrder(3);
    }
}