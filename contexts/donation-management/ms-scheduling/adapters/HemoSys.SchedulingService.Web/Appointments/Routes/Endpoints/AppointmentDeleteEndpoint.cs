using Microsoft.AspNetCore.Mvc;

namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public abstract class AppointmentDeleteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/", async (IAppointmentCommandService service, [FromBody] AppointmentDeleteRequest request) =>
        {
            var command = request.ToCommand(request);
                    
            if (request.HasNotifications)
                return Result.Failure(request.Notifications
                    .Select(x => x.Message)
                    .ToList());
                    
            var result = await service.DeleteAppointmentAsync(command, CancellationToken.None);
                    
            return !result 
                ? Result.Failure("Failed to delete appointment") 
                : Result.Success(SuccessType.Ok);
        }).WithName("Appointment: Delete")
        .WithSummary("Delete a appointment")
        .WithDescription("Delete a appointment in the system.")
        .WithOrder(3);
    }
}