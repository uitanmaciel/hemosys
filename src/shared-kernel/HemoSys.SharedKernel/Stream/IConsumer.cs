namespace HemoSys.SharedKernel.Stream;

public interface IConsumer
{
    Task SubscribeAsync<T>(string queue, string eventName, Func<T, Task> payload);
}