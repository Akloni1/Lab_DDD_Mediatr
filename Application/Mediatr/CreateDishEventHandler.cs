using DomainDrivenDesign.Domain.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class CreateDishEventHandler : INotificationHandler<CreateDishEvent>
    {
        public Task Handle(CreateDishEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Произошло событие добавления нового блюда");
            return Task.CompletedTask;
        }
    }
}
