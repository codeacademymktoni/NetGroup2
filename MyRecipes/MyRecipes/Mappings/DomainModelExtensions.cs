using MyRecipes.Models;
using MyRecipes.ViewModels;

namespace MyRecipes.Mappings
{
    public static class DomainModelExtensions
    {
        public static RecipeOverviewModel ToOverviewModel(this Recipe recipe)
        {
            return new RecipeOverviewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl
            };
        }

        public static RecipeManageOverviewModel ToManageOverviewModel(this Recipe recipe)
        {
            return new RecipeManageOverviewModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
            };
        }

        public static RecipeDetailsModel ToDetailsModel(this Recipe recipe)
        {
            return new RecipeDetailsModel()
            {
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Directions = recipe.Directions,
                DateCreated = recipe.DateCreated,
                Ingredients = recipe.Ingredients
            };
        }

        public static RecipeUpdateModel ToUpdateModel(this Recipe recipe)
        {
            return new RecipeUpdateModel()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Directions = recipe.Directions,
                Ingredients = recipe.Ingredients
            };
        }
    }
}
