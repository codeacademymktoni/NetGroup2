
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50,MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Directions { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated{ get; set; }

        public DateTime? DateModified { get; set; }

        public int Views { get; set; }

        public List<Comment> Comments{ get; set; }

        public List<RecipeLike> RecipeLikes { get; set; }

        public int RecipeTypeId { get; set; }
        public RecipeType RecipeType { get; set; }
    }
}
