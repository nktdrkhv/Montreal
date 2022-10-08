namespace Montreal.Bot.Poc.Interfaces;

public interface IReceiverService
{
    Task ReceiveAsync(CancellationToken stoppingToken);
}
