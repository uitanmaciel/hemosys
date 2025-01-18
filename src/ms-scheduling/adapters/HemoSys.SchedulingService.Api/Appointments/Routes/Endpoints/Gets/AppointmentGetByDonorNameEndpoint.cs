using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDonorNameEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-donor-name/{name}", async (IAppointmentQueryService service, string name, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDonorNameAsync(name, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDonorName")
        .WithSummary("Get appointments by donor name")
        .WithDescription("Get appointments by donor name")
        .WithOrder(16);
    }
}