namespace HemoSys.SharedKernel.Stream;

public interface IProducer
{
    Task PublishAsync(string destination, string eventName, object message);
}