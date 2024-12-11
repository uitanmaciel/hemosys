namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public class AppointmentDeleteEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapDelete("/", async (IAppointmentCommandService service, AppointmentDeleteRequest request) =>
            {
                var command = request.ToCommand(request);
            
                if (request.HasNotifications)
                    return Result.Failure(request.Notifications
                        .Select(x => x.Message)
                        .ToList());
            
                var result = await service.DeleteAppointmentAsync(command, default);
            
                return !result 
                    ? Result.Failure("Failed to delete appointment") 
                    : Result.Success(SuccessType.Ok);
            }).WithName("Appointment: Delete")
            .WithSummary("Delete a appointment")
            .WithDescription("Delete a appointment in the system.")
            .WithOrder(3);
    }
}