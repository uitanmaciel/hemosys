using HemoSys.SchedulingService.Api.Appointments.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Deletes;

public class AppointmentDeleteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/delete", async (IAppointmentCommandService service, [FromBody] AppointmentDeleteRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentDeleteAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error deleting appointment")
                : Result.Success(SuccessType.Ok);
        })
        .WithName("AppointmentDelete")
        .WithSummary("Delete an appointment")
        .WithDescription("Delete an existing appointment for a donor")
        .WithOrder(7);
    }
}