namespace HemoSys.SharedKernel.Stream;

public record StreamConfiguration
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Exchange { get; set; } = null!;
    public string ExchangeType { get; set; } = null!;
    public string Retry { get; set; } = null!;
}