using HemoSys.SchedulingService.Application.Appointments.Interfaces.Adapters.State;
using HemoSys.SchedulingService.Domain.Appointments.Aggregates;
using HemoSys.SchedulingService.Domain.Appointments.Enums;
using HemoSys.SchedulingService.State.Appointments.DataContexts;
using HemoSys.SchedulingService.State.Appointments.Repositories.Mappers;
using MongoDB.Driver;

namespace HemoSys.SchedulingService.State.Appointments.Repositories;

public sealed class AppointmentWriteRepository(AppointmentDbContext context) : IAppointmentWriteRepository
{
    public async Task<bool> AddAsync(Appointment entity, CancellationToken cancellationToken)
    {
        try
        {
            var objectState = new AppointmentMapper().ToState(entity);
            await context.Appointments.InsertOneAsync(objectState, null, cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Appointment entity, CancellationToken cancellationToken)
    {
        var objectState = new AppointmentMapper().ToState(entity);
        objectState._id = context.Appointments
            .Find(x => x.Id == objectState.Id)
            .FirstOrDefault(cancellationToken: cancellationToken)._id;
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, objectState.Id);
        return await context.Appointments
            .ReplaceOneAsync(filter, objectState, new ReplaceOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, id);
        return await context.Appointments
            .DeleteOneAsync(filter, cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> CancelAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, appointmentId);
        var update = Builders<AppointmentState>.Update.Set(x => x.Status, AppointmentStatusTypes.Canceled.ToString());
        return await context.Appointments
            .UpdateOneAsync(filter, update, new UpdateOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> CompleteAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, appointmentId);
        var update = Builders<AppointmentState>.Update.Set(x => x.Status, AppointmentStatusTypes.Completed.ToString());
        return await context.Appointments
            .UpdateOneAsync(filter, update, new UpdateOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }
}