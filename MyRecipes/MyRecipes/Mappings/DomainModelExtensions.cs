using MyRecipes.Models;
using MyRecipes.ViewModels;
using System.Linq;

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
                ImageUrl = recipe.ImageUrl,
                Views = recipe.Views
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
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Directions = recipe.Directions,
                DateCreated = recipe.DateCreated,
                Ingredients = recipe.Ingredients,
                Views = recipe.Views,
                Comments = recipe.Comments.Select(x => x.ToCommentModel()).ToList()
            };
        }

        public static RecipeCommentModel ToCommentModel(this Comment comment)
        {
            return new RecipeCommentModel
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
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

        public static UserDetailsModel ToDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Address = user.Address,
                Email = user.Email,
                Username  = user.Username
            };
        }

        public static UserManageOverviewModel ToManageOverviewModel(this User user)
        {
            return new UserManageOverviewModel()
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }

        public static RecipeSidebarModel ToRecipeSidebarModel(this Recipe recipe)
        {
            return new RecipeSidebarModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Views = recipe.Views,
                DateCreated = recipe.DateCreated
            };
        }
    }
}
