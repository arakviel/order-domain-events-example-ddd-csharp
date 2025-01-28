using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Services;
using OrderDomainEventExample.Utils.EventHandler;

namespace OrderDomainEventExample.OrderDomain.Handlers;

public class SendOrderConfirmationEmailHandler : IDomainEventHandler<OrderCreatedEvent>
{
    private readonly IEmailService _emailService;

    public SendOrderConfirmationEmailHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task HandleAsync(OrderCreatedEvent domainEvent)
    {
        var subject = "Ваше замовлення підтверджено!";
        var message = $"Дякуємо за замовлення! Номер замовлення: {domainEvent.OrderId}.";
        await _emailService.SendEmailAsync(domainEvent.CustomerId, subject, message);
    }
}