using HemoSys.SchedulingService.Api.Appointments.Routes.Endpoints.Gets;

namespace HemoSys.SchedulingService.Api.Appointments.Routes.Groups;

public static class RoutesResponsesGroup
{
    public static void MapResponsesEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetAllEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByIdEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByBloodTypeEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDateEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDateRangeEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDonationCenterIdEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDonationCenterNameEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDonorIdEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByDonorNameEndpoint>();
        
        endpoints.MapGroup("api/v1/appointments")
            .WithTags("Appointments")
            .MapEndpoint<AppointmentGetByStatusTypeEndpoint>();
    }
}