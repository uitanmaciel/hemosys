using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDonationCenterIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-donation-center-id/{donationCenterId:guid}", async (IAppointmentQueryService service, Guid donationCenterId, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDonationCenterIdAsync(donationCenterId, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDonationCenterId")
        .WithSummary("Get appointments by donation center id")
        .WithDescription("Get appointments by donation center id")
        .WithOrder(13);
    }
}