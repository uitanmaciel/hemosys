namespace HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

public class AppointmentCreateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (IAppointmentCommandService service, AppointmentCreateRequest request) =>
        {
            var command = request.ToCommand(request);
            
            if (request.HasNotifications)
                return Result.Failure(request.Notifications
                    .Select(x => x.Message)
                    .ToList());
            
            var result = await service.CreateAppointmentAsync(command, default);
            
            return !result 
                ? Result.Failure("Failed to create appointment") 
                : Result.Success(SuccessType.Created);
        }).WithName("Appointment: Create")
        .WithSummary("Creates a new appointment")
        .WithDescription("Creates a new appointment in the system.")
        .WithOrder(1);
    }
}