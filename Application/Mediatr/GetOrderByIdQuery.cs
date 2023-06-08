using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class GetOrderByIdQuery : IRequest<OrderViewModel>
    {
        public long Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetAll()
                .Include(x=>x.Table)
                .Include(x => x.Items).ThenInclude(x=>x.Dish)
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
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
