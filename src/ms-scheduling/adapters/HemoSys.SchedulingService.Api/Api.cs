using HemoSys.SchedulingService.Api.Appointments.Routes.Groups;
using HemoSys.SchedulingService.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.ConfigureApi();
var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.ChoseEnvironment();

app.MapRequestsEndpoints();
app.MapResponsesEndpoints();
app.UseHttpsRedirection();
app.Run();