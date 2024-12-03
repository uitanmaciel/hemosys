using DevSource.Stack.Notifications;
using DevSource.Stack.Notifications.Validations;

namespace HemoSys.SchedulingService.State.Appointments.DataContexts;

public class MongoConfiguration : Notifier
{
    public string Database { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; } 
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    
    public string GetConnectionString()
    {
        ValidateFields();
        return $"mongodb://{Host}:{Port}/";
    }

    private void ValidateFields()
    {
        PublishExceptions(new ValidationRulesException<MongoConfiguration>()
            .IsNullOrEmpty(nameof(Username), Username)
            .IsNullOrEmpty(nameof(Password), Password)
        );
    }
}