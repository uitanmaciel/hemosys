using HemoSys.SchedulingService.Web.Appointments.Routes.Endpoints;

namespace HemoSys.SchedulingService.Web.Appointments.Routes.Groups;

public static class RoutesGroups
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/health", async () => await Task.FromResult("OK"));
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentCreateEndpoint>();
    }
    
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}