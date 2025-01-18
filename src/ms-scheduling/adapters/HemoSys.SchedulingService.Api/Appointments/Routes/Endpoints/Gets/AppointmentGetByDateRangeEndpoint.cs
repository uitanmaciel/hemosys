using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetByDateRangeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-by-date-range/{startDate:datetime}&{endDate:datetime}", 
                async (IAppointmentQueryService service, DateTime startDate, DateTime endDate, int? skip, int? take) =>
        {
            var appointments = await service.GetAppointmentsByDateRangeAsync(startDate, endDate, skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAppointmentsByDateRange")
        .WithSummary("Get appointments by date range")
        .WithDescription("Get appointments by date range")
        .WithOrder(12);
    }
}