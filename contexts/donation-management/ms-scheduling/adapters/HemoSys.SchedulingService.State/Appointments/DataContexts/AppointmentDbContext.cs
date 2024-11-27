using HemoSys.SchedulingService.State.Appointments.Repositories.Models;
using HemoSystem.SchedulingService.State.Appointments.DataContexts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HemoSys.SchedulingService.State.Appointments.DataContexts;

public sealed class AppointmentDbContext : IMongoContext
{
    private readonly IMongoDatabase _database;
    
    public AppointmentDbContext(IOptions<MongoConfiguration> options)
    {
        var client = new MongoClient(options.Value.GetConnectionString());
        _database = client.GetDatabase(options.Value.Database);
    }

    public IMongoCollection<AppointmentState> Appointments => _database.GetCollection<AppointmentState>("Appointments");
}