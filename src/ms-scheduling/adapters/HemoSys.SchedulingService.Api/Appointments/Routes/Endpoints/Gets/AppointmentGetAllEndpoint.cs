using HemoSys.SchedulingService.Api.Appointments.Responses;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

public class AppointmentGetAllEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/get-all", async (IAppointmentQueryService service, int? skip, int? take) =>
        {
            var appointments = await service.GetAllAppointmentsAsync(skip, take, CancellationToken.None);
            var response = AppointmentResponse.ToResponse(appointments);
            
            return !response.Any()
                ? ResultPaged<AppointmentResponse>.Failure(ErrorType.NotFound)
                : ResultPaged<AppointmentResponse>.Success(SuccessType.Ok, response.Count, response);
        })
        .WithName("GetAllAppointments")
        .WithSummary("Get all appointments")
        .WithDescription("Get all appointments in the system")
        .WithOrder(8);
    }
}