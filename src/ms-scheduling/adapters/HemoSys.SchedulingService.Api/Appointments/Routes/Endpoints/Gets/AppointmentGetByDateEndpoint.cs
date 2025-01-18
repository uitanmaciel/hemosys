using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDateEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-date/{date:datetime}", async (IAppointmentQueryService service, DateTime date, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDateAsync(date, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDate")
        .WithSummary("Get appointments by date")
        .WithDescription("Get appointments by date")
        .WithOrder(11);
    }
}