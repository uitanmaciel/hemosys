namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public abstract class AppointmentUpdateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/", async (IAppointmentCommandService service, AppointmentUpdateRequest request) =>
            {
                var command = request.ToCommand(request);
            
                if (request.HasNotifications)
                    return Result.Failure(request.Notifications
                        .Select(x => x.Message)
                        .ToList());
            
                var result = await service.UpdateAppointmentAsync(command, CancellationToken.None);
            
                return !result 
                    ? Result.Failure("Failed to update appointment") 
                    : Result.Success(SuccessType.Ok);
            }).WithName("Appointment: Update")
            .WithSummary("Updates a appointment")
            .WithDescription("Updates a appointment in the system.")
            .WithOrder(2);
    }
}