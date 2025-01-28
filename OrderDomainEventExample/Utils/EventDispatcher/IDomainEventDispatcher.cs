using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.Utils.EventDispatcher;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent domainEvent);
}
