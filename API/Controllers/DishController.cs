using DomainDrivenDesign.Application.Mediatr;
using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Domain.Events;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DishController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ICollection<DishViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetDishsQuery(),
                cancellationToken);
            return result;
        }

        [HttpGet("WithoutOnions")]
        public async Task<ICollection<DishViewModel>> GetDishsWithoutOnions(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetDishsWithoutOnionsQuery(),
                cancellationToken);
            return result;
        }

        [HttpPost]
        public async Task CreateDish(CreateDishViewModel dish, CancellationToken cancellationToken)
        {
            await _mediator.Send(
               new CreateDishComand
               {
                   Dish = dish
               },
               cancellationToken);
            await _mediator.Publish(new CreateDishEvent(), cancellationToken);

        }

        [HttpDelete("{id}")]
        public async Task DeleteDish(long id, CancellationToken cancellationToken)
        {
            await _mediator.Send(
                new DeleteDishComand
                {
                    Id = id
                },
                cancellationToken);
            await _mediator.Publish(new DeleteDishEvent(), cancellationToken);
        }
    }
}
