namespace HemoSys.SharedKernel.Stream;

public interface IProducer
{
    Task PublishAsync(string queue, string? eventName, object message);
}