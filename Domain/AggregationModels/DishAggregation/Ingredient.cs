using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;

namespace DomainDrivenDesign.Domain.AggregationModels.DishAggregation
{
    public class Ingredient //ValueObject
    {
        public Ingredient()
        {
        }

        public Ingredient(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public long Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public virtual Dish Dish { get; }
        public long DishId { get; }
    }
}
