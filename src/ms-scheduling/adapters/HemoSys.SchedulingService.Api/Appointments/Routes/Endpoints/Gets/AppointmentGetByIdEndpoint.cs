using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/{id:guid}", async (IAppointmentQueryService service, Guid id) =>
        {
            var appointment = await service.GetAppointmentByIdAsync(id, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointment);

            return response is null
                ? Result<AppointmentResponse>.Failure(ErrorType.NotFound)
                : Result<AppointmentResponse>.Success(SuccessType.Ok, response);
        })
        .WithName("GetAppointmentById")
        .WithSummary("Get appointment by id")
        .WithDescription("Get an appointment by its id")
        .WithOrder(9);
    }
}