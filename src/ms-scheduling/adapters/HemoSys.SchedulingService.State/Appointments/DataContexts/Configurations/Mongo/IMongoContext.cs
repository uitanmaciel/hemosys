namespace HemoSys.SchedulingService.State.Appointments.DataContexts.Configurations.Mongo;

public interface IMongoContext
{
    IMongoCollection<AppointmentState> Appointments { get; }
}