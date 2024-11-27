using HemoSys.SchedulingService.State.Appointments.Repositories.Models;
using MongoDB.Driver;

namespace HemoSys.SchedulingService.State.Appointments.DataContexts;

public interface IMongoContext
{
    IMongoCollection<AppointmentState> Appointments { get; }
}