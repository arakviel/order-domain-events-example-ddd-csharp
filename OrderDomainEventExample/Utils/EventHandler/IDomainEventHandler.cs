using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.Utils.EventHandler;

public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent domainEvent);
}
