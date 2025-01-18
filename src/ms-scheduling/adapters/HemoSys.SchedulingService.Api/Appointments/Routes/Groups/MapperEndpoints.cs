namespace HemoSys.SchedulingService.Api.Appointments.Routes.Groups;

public static class MapperEndpoints
{
    public static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}