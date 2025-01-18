using HemoSys.SchedulingService.Application.Appointments;
using HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;
using HemoSys.SchedulingService.Application.Appointments.Interfaces.Services;
using HemoSys.SchedulingService.State.Appointments.DataContexts;
using HemoSys.SchedulingService.State.Appointments.DataContexts.Configurations.Mongo;
using HemoSys.SchedulingService.State.Appointments.Repositories;
using HemoSys.SharedKernel.Stream;
using Scalar.AspNetCore;

namespace HemoSys.SchedulingService.Api.Configurations;

public static class ApiConfiguration
{
    public static void ConfigureApi(this WebApplicationBuilder builder)
    {
        AddDataContexts(builder);
        AddStream(builder);
        AddServicesAssembly(builder);
        AddDocumentation(builder);
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
    }
    
    public static void ChoseEnvironment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.Theme = ScalarTheme.Mars;
            options.Title = "HemoSys Scheduling Service";
        });
    }
    
    private static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi();
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            });
    }
    
    private static void AddServicesAssembly(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
        builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();
        builder.Services.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();
        builder.Services.AddScoped<IAppointmentReadRepository, AppointmentReadRepository>();
        builder.Services.AddMediatR(m => 
            m.RegisterServicesFromAssemblies(
                AppDomain.CurrentDomain.GetAssemblies()));
    }
    
    private static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("Mongo"));
        builder.Services.AddScoped<AppointmentMongoDbContext>();
    }
    
    private static void AddStream(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<StreamConfiguration>(builder.Configuration.GetSection("Stream"));
        builder.Services.AddSingleton<RabbitMqManager>();
        builder.Services.AddScoped<IProducer, RabbitMqProducer>();
        builder.Services.AddScoped<IConsumer, RabbitMqConsumer>();
    }
}