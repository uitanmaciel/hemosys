using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Path;

public class AppointmentCompleteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("/complete", async (IAppointmentCommandService service, AppointmentCompleteRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentCompleteAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error completing appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentComplete")
        .WithSummary("Complete an appointment")
        .WithDescription("Complete an existing appointment for a donor")
        .WithOrder(4);
    }
}