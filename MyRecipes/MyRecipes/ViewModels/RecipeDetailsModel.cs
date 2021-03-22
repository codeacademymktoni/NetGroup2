using System;

namespace MyRecipes.ViewModels
{
    public class RecipeDetailsModel
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Ingredients { get; set; }

        public string Directions { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
