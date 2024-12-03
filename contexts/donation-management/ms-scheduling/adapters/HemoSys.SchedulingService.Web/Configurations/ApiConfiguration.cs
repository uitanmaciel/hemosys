using HemoSys.SchedulingService.Application.Appointments;
using HemoSys.SchedulingService.Application.Appointments.Commands.Interfaces;
using HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;
using HemoSys.SchedulingService.State.Appointments.DataContexts;
using HemoSys.SchedulingService.State.Appointments.Repositories;
using HemoSys.SharedKernel.Messaging;
using HemoSys.SharedKernel.Stream;
using Scalar.AspNetCore;

namespace HemoSys.SchedulingService.Web.Configurations;

public static class ApiConfiguration
{
    public static string ConnectionString { get; set; } = string.Empty;
    public static string CorsPolicyName { get; set; } = string.Empty;
    
    public static void ConfigureApi(this WebApplicationBuilder builder)
    {
        AddDataContexts(builder);
        AddStream(builder);
        AddServicesAssembly(builder);
        AddDocumentation(builder);
        builder.Services.AddHttpClient();
        builder.Services.AddControllers();
    }
    
    private static void AddDocumentation(this WebApplicationBuilder builder)
    {
        /*builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x => { x.CustomOperationIds(n => n.GroupName); });*/
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApi();
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            });
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
    
    private static void AddServicesAssembly(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
        builder.Services.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();
        builder.Services.AddMediatR(m => 
            m.RegisterServicesFromAssemblies(
                AppDomain.CurrentDomain.GetAssemblies()));
    }
    
    private static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("Mongo"));
        builder.Services.AddScoped<AppointmentDbContext>();
    }
    
    private static void AddStream(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("Stream"));
        builder.Services.AddSingleton<RabbitMqManager>();
        builder.Services.AddScoped<IProducer, RabbitMqProducer>();
        builder.Services.AddScoped<IConsumer, RabbitMqConsumer>();
    }
}