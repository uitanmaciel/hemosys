using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByStatusTypeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-status-type/{statusType}", async (IAppointmentQueryService service, string statusType, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByStatusAsync(statusType, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByStatusType")
        .WithSummary("Get appointments by status type")
        .WithDescription("Get appointments by status type")
        .WithOrder(17);
    }
}