using DomainDrivenDesign.Domain.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class CreateOrderEventHandler : INotificationHandler<CreateOrderEvent>
    {
        public Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Произошло событие создание нового заказа на сумму: {notification.Order.TotalPrice} р");
            return Task.CompletedTask;
        }
    }
}
