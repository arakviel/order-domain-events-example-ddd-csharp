using Microsoft.Extensions.DependencyInjection;
using OrderDomainEventExample.OrderDomain;
using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.OrderDomain.Handlers;
using OrderDomainEventExample.Services;
using OrderDomainEventExample.Utils.EventDispatcher;
using OrderDomainEventExample.Utils.EventHandler;

var services = new ServiceCollection();
services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();

services.AddSingleton<IEmailService, EmailService>();
services.AddSingleton<ITelegramService, TelegramService>();

services.AddSingleton<IDomainEventHandler<OrderCreatedEvent>, SendOrderConfirmationEmailHandler>();
services.AddSingleton<IDomainEventHandler<OrderCreatedEvent>, SendOrderConfirmationTelegramHandler>();
var serviceProvider = services.BuildServiceProvider();

var dispatcher = serviceProvider.GetRequiredService<IDomainEventDispatcher>();
var orderService = new OrderService(dispatcher);

await orderService.CreateOrderAsync(Guid.NewGuid(), new List<OrderItem>
{
    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 2, Price = 100 },
    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 1, Price = 50 }
});
