using HemoSys.SchedulingService.Api.Appointments.Requests;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Creates;

public class AppointmentCreateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async (IAppointmentCommandService service, AppointmentCreateRequest request) =>
        {
            var command = request.ToCommand(request);
            if(request.HasNotifications)
                return Result
                    .Failure(ErrorType.BadRequest, request.Notifications
                    .Select(e => e.Message.ToString()).ToList());
            
            var result = await service.AppointmentCreateAsync(command, CancellationToken.None);
            return !result
                ? Result.Failure("Error creating appointment")
                : Result.Success(SuccessType.Created);
        })
        .WithName("AppointmentCreate")
        .WithSummary("Create a new appointment")
        .WithDescription("Create a new appointment for a donor")
        .WithOrder(1);
    }
}