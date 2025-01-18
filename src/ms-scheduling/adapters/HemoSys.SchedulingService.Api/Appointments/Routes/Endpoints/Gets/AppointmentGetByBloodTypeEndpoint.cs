using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByBloodTypeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-blood-type/{bloodType}", async (IAppointmentQueryService service, string bloodType, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByBloodTypeAsync(bloodType, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByBloodType")
        .WithSummary("Get appointments by blood type")
        .WithDescription("Get appointments by blood type")
        .WithOrder(10);
    }
}