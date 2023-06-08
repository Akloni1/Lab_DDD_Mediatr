using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class CreateOrderComand : IRequest<OrderViewModel>
    {
        public CreateOrderViewModel Order { get; set; }
    }

    public class CreateOrderComandHandler : IRequestHandler<CreateOrderComand, OrderViewModel>
    {
        private readonly IRepository<Order> _repository;
        
        private readonly IRepository<Table> _repositoryTable;
        private readonly IRepository<Dish> _repositoryDish;

        public CreateOrderComandHandler(IRepository<Order> repository,
            IRepository<Table> repositoryTable,
            IRepository<Dish> repositoryDish
            )
        {
            _repository = repository;
            _repositoryTable = repositoryTable;
            _repositoryDish = repositoryDish;
        }

        public async Task<OrderViewModel> Handle(CreateOrderComand request, CancellationToken cancellationToken)
        {
            var orderItems = new List<OrderItem>();
            decimal TotalPrice = 0;
            foreach (var item in request.Order.Items)
            {
                var dish = await _repositoryDish.GetAll()
                    .Where(x => x.Id == item.DishId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (dish is null)
                {
                    Console.WriteLine($"Блюдо по id {item} не найден");
                }
                else
                {
                    var orderItem = new OrderItem(dish, item.Quantity);
                    orderItems.Add(orderItem);
                    TotalPrice += orderItem.Dish.Price * orderItem.Quantity;
                }

            }
            var table = await _repositoryTable.GetAll()
                .Where(x => x.Id == request.Order.TableId)
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new Exception("Заказ не имеет стола");

            var model = new Order(table, orderItems, TotalPrice);
            var res = await _repository.Add(model, cancellationToken);




            TableViewModel tableView = new TableViewModel()
            {
                Id = res.Table.Id,
                Capacity = res.Table.Capacity,
                Number = res.Table.Number,
                IsAvailable = res.Table.IsAvailable,
            };

            List<OrderItemViewModel> orderItemsViewModel = new List<OrderItemViewModel>();
            foreach (var item in res.Items)
            {
                orderItemsViewModel.Add(
                    new OrderItemViewModel()
                    {
                        Id = item.Id,
                        Quantity = item.Quantity,
                        Dish = new DishViewModel()
                        {
                            Id = item.Dish.Id,
                            Name = item.Dish.Name,
                            Price = item.Dish.Price
                        }

                    }
                    );
            }

            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Id = res.Id,
                TotalPrice = res.TotalPrice,
                Table = tableView,
                Items = orderItemsViewModel
            };

            return orderViewModel;
        }
    }
}
