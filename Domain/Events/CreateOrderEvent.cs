using DomainDrivenDesign.ViewModels;
using MediatR;

namespace DomainDrivenDesign.Domain.Events
{
    public class CreateOrderEvent : INotification
    {
        public OrderViewModel Order;
        public CreateOrderEvent(OrderViewModel order)
        {
            Order = order;
        }
    }
}
