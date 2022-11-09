using Hangfire;

namespace Montreal.Bot.Poc.Infrastructure;

public class ContainerJobActivator : JobActivator
{
    private IServiceProvider _container;
    public ContainerJobActivator(IServiceProvider serviceProvider) => _container = serviceProvider;
    public override object ActivateJob(Type type) => _container!.GetService(type);
}