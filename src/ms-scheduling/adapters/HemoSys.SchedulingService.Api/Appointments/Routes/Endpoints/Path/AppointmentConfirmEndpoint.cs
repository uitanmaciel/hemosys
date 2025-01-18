using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Path;

public class AppointmentConfirmEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPatch("/confirm", async (IAppointmentCommandService service, AppointmentConfirmRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentConfirmAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error confirming appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentConfirm")
        .WithSummary("Confirm an appointment")
        .WithDescription("Confirm an existing appointment for a donor")
        .WithOrder(5);
    }
}