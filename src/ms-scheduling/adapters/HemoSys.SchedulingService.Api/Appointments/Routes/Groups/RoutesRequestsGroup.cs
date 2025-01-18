using HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Creates;
using HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Deletes;
using HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Path;
using HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Updates;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Groups;

public static class RoutesRequestsGroup
{
    public static void MapRequestsEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentCreateEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentUpdateEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentCancelEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentCompleteEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentConfirmEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentRescheduleEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentDeleteEndpoint>();
    }
}