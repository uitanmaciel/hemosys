using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace HemoSys.SharedKernel.Stream;

public class RabbitMqManager
{
    public IModel Channel { get; }
    public string Exchange { get; }
    
    public RabbitMqManager(IOptions<StreamConfiguration> options)
    {
        Exchange = options.Value.Exchange;
        var factory = new ConnectionFactory()
        {
            HostName = options.Value.Host,
            Port = options.Value.Port,
            UserName = options.Value.Username,
            Password = options.Value.Password
        };
        var connection = factory.CreateConnection();
        Channel = connection.CreateModel();
        Channel.ExchangeDeclare(Exchange, options.Value.ExchangeType, true);
    }
}