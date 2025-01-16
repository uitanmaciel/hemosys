namespace HemoSys.SchedulingService.State.Appointments.DataContexts.Configurations.Mongo;

public record MongoConfiguration(
    string? Database,
    string Host,
    int Port,
    string? Username,
    string? Password,
    string ConnectionString);