using System.ComponentModel.DataAnnotations;

namespace MyRecipes.ViewModels
{
    public class RecipeCreateModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Directions { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
