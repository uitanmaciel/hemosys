using HemoSys.SchedulingService.Web.Appointments.Routes.Groups;
using HemoSys.SchedulingService.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
    app.ChoseEnvironment();

app.MapEndpoints();
app.UseHttpsRedirection();
app.Run();
