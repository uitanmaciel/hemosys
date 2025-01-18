using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Updates;

public class AppointmentUpdateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/update", async (IAppointmentCommandService service, AppointmentUpdateRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentUpdateAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error updating appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentUpdate")
        .WithSummary("Update an appointment")
        .WithDescription("Update an existing appointment for a donor")
        .WithOrder(2);
    }
}