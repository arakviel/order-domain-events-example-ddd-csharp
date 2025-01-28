using Microsoft.Extensions.DependencyInjection;
using OrderDomainEventExample.Utils.EventHandler;
using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.Utils.EventDispatcher;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task DispatchAsync(IDomainEvent domainEvent)
    {
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        // Type ( IDomainEventHandler<OrderCreatedEvent> )
        var handlers = _serviceProvider.GetServices(handlerType);

        foreach (var handler in handlers)
        {
            var handleMethod = handlerType.GetMethod("HandleAsync");
            if (handleMethod != null)
            {
                await (Task)handleMethod.Invoke(handler, new[] { domainEvent });
            }
        }
    }
}
