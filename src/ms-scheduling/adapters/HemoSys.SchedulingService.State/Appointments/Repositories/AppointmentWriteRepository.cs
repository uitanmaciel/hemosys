using HemoSys.SchedulingService.Domain.Appointments.Enums;

namespace HemoSys.SchedulingService.State.Appointments.Repositories;

public sealed class AppointmentWriteRepository(AppointmentMongoDbContext context) : IAppointmentWriteRepository
{
    public async Task<bool> AddAsync(Appointment entity, CancellationToken cancellationToken)
    {
        try
        {
            var objectState = AppointmentMapper.ToState(entity);
            await context.Appointments.InsertOneAsync(objectState, cancellationToken: cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Appointment entity, CancellationToken cancellationToken)
    {
        var objectState = AppointmentMapper.ToState(entity);
        objectState._Id = context.Appointments
            .Find(x => x.Id == objectState.Id)
            .FirstOrDefault(cancellationToken)._Id;
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, objectState.Id);
        return await context.Appointments
            .ReplaceOneAsync(filter, objectState, cancellationToken: cancellationToken)
            .ContinueWith(x => x.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, id);
        return await context.Appointments
            .DeleteOneAsync(filter, cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> ConfirmAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CancelAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, appointmentId);
        var update = Builders<AppointmentState>.Update.Set(x => x.StatusType, AppointmentStatusTypes.Canceled.ToString());
        return await context.Appointments
            .UpdateOneAsync(filter, update, new UpdateOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> CompleteAppointmentAsync(Guid appointmentId, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, appointmentId);
        var update = Builders<AppointmentState>.Update.Set(x => x.StatusType, AppointmentStatusTypes.Completed.ToString());
        return await context.Appointments
            .UpdateOneAsync(filter, update, new UpdateOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }

    public async Task<bool> RescheduleAppointmentAsync(Guid appointmentId, DateTime newDate, CancellationToken cancellationToken)
    {
        var filter = Builders<AppointmentState>.Filter.Eq(x => x.Id, appointmentId);
        var update = Builders<AppointmentState>.Update.Set(x => x.ScheduledDate, newDate);
        return await context.Appointments
            .UpdateOneAsync(filter, update, new UpdateOptions(), cancellationToken)
            .ContinueWith(task => task.Result.IsAcknowledged, cancellationToken);
    }
}
