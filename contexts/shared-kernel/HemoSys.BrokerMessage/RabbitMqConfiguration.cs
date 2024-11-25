using RabbitMQ.Client;

namespace HemoSys.BrokerMessage;

public class RabbitMqConfiguration
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Exchange { get; set; } = null!;
    public string ExchangeType { get; set; } = null!;
    public string Retry { get; set; } = null!;
    public IModel Channel { get; set; }

    public RabbitMqConfiguration()
    {
        var factory = new ConnectionFactory()
        {
            HostName = Host,
            Port = Port,
            UserName = Username,
            Password = Password
        };
        var connection = factory.CreateConnection();
        Channel = connection.CreateModel();
        Channel.ExchangeDeclare(Exchange, ExchangeType, true);
    }
}
