namespace OrderDomainEventExample.Utils.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}