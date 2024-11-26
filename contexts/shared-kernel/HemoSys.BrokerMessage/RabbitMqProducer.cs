﻿using System.Text;
using HemoSys.SharedKernel.Stream;
using RabbitMQ.Client;

namespace HemoSys.BrokerMessage;

public class RabbitMqProducer(RabbitMqConfiguration configuration) : IProducer
{
    public Task PublishAsync(string destination, string eventName, object message)
    {
        var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(message));
        configuration.Channel.BasicPublish(
            exchange: configuration.Exchange, 
            routingKey: destination, 
            basicProperties: null, 
            body: body);
        
        return Task.CompletedTask;
    }
}