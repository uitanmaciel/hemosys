using HemoSys.SchedulingService.State.Appointments.DataContexts.Configurations.Mongo;
using Microsoft.Extensions.Options;

namespace HemoSys.SchedulingService.State.Appointments.DataContexts;

public class AppointmentMongoDbContext : IMongoContext
{
    private readonly IMongoDatabase _database;

    public AppointmentMongoDbContext(IOptions<MongoConfiguration> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.Database);
    }
    public IMongoCollection<AppointmentState> Appointments => _database.GetCollection<AppointmentState>("Appointments");
}