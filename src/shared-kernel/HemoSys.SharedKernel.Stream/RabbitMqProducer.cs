using System.Text;
using RabbitMQ.Client;

namespace HemoSys.SharedKernel.Stream;

public class RabbitMqProducer(RabbitMqManager configuration) : IProducer
{
    public Task PublishAsync(string queue, string? eventName, object message)
    {
        var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(message));
        configuration.Channel.BasicPublish(
            exchange: configuration.Exchange, 
            routingKey: queue, 
            basicProperties: null, 
            body: body);
        
        return Task.CompletedTask;
    }
}