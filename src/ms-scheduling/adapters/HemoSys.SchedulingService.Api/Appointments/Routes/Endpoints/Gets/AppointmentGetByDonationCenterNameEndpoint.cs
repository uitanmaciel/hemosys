using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDonationCenterNameEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-donation-center-name/{donationCenterName}", async (IAppointmentQueryService service, string donationCenterName, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDonationCenterNameAsync(donationCenterName, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDonationCenterName")
        .WithSummary("Get appointments by donation center name")
        .WithDescription("Get appointments by donation center name")
        .WithOrder(14);
    }
}