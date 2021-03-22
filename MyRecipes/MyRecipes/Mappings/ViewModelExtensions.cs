using MyRecipes.Models;
using MyRecipes.ViewModels;

namespace MyRecipes.Mappings
{
    public static class ViewModelExtensions
    {
        public static Recipe ToModel(this RecipeCreateModel viewModel)
        {
            return new Recipe
            {
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                Directions = viewModel.Directions,
                Ingredients = viewModel.Ingredients
            };
        }

        public static Recipe ToModel(this RecipeUpdateModel viewModel)
        {
            return new Recipe
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                Directions = viewModel.Directions,
                Ingredients = viewModel.Ingredients
            };
        }
    }
}
