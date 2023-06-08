using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;

namespace DomainDrivenDesign.ViewModels
{
    public class DishViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set;  }
        public IReadOnlyList<IngredientViewModel> Ingredients { get; set; }
    }
}
