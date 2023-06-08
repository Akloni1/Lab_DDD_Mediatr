using DomainDrivenDesign.Application.Mediatr;
using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;
using DomainDrivenDesign.Domain.Events;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<OrderViewModel> GetById(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetOrderByIdQuery() 
                { 
                    Id = id
                },
                cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task<OrderViewModel> CreateOrder(CreateOrderViewModel order, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new CreateOrderComand
                {
                   Order = order
                },
                cancellationToken);
            await _mediator.Publish(new CreateOrderEvent(result), cancellationToken);
            return result;
        }
    }
}
