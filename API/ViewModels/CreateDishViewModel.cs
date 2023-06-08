using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;

namespace DomainDrivenDesign.ViewModels
{
    public class CreateDishViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IReadOnlyList<IngredientViewModel> Ingredients { get; set; }
    }
}
