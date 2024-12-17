namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public abstract class AppointmentCompleteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (IAppointmentCommandService service, AppointmentCompleteRequest request) =>
        {
            var command = request.ToCommand(request);
            
            if(request.HasNotifications)
                return Result.Failure(request.Notifications
                    .Select(x => x.Message)
                    .ToList());
            
            var result = await service.CompleteAppointmentAsync(command, CancellationToken.None);
            
            return !result
                ? Result.Failure("Failed to complete appointment")
                : Result.Success(SuccessType.Ok);
        }).WithName("Appointment: Complete")
            .WithSummary("Complete a appointment")
            .WithDescription("Complete a appointment in the system.")
            .WithOrder(5);
    }
}