using System;

namespace OrderDomainEventExample.OrderDomain;

public record OrderItem
{
    public Guid ProductId { get; init; }
    public uint Quantity { get; init; }
    public decimal Price { get; init; }
}