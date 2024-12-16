namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public abstract class AppointmentCancelEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (IAppointmentCommandService service, AppointmentCancelRequest request) =>
        {
            var command = request.ToCommand(request);
            
            if(request.HasNotifications)
                return Result.Failure(request.Notifications
                    .Select(x => x.Message)
                    .ToList());
            
            var result = await service.CancelAppointmentAsync(command, CancellationToken.None);
            
            return !result
                ? Result.Failure("Failed to cancel appointment")
                : Result.Success(SuccessType.Ok);
        }).WithName("Appointment: Cancel")
            .WithSummary("Cancel a appointment")
            .WithDescription("Cancel a appointment in the system.")
            .WithOrder(4);
    }
}