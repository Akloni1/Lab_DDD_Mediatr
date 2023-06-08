using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;
using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Domain.AggregationModels.DishAggregation
{
    public class Dish //AggregationRoot
    {
        public Dish()
        {
        }

        public Dish(string name, decimal price, IReadOnlyList<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
        public long Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public IReadOnlyList<Ingredient> Ingredients { get; }
        public IReadOnlyList<OrderItem> Items { get; }
    }
}
