using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HemoSys.SharedKernel.Stream;

public class RabbitMqConsumer(RabbitMqManager configuration) : IConsumer
{
    public Task SubscribeAsync<T>(string queue, string eventName, Func<T, Task> payload)
    {
        var consumer = new EventingBasicConsumer(configuration.Channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = System.Text.Json.JsonSerializer.Deserialize<T>(body);
            await payload(message!);
        };
        
        configuration.Channel.BasicConsume(
            queue: queue, 
            autoAck: false, 
            consumer: consumer);
        
        return Task.CompletedTask;
    }
}