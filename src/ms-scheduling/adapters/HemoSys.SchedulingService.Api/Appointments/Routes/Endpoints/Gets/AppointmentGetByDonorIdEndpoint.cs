using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDonorIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-donor-id/{donorId:guid}", async (IAppointmentQueryService service, Guid donorId, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDonorIdAsync(donorId, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDonorId")
        .WithSummary("Get appointments by donor id")
        .WithDescription("Get appointments by donor id")
        .WithOrder(15);
    }
}