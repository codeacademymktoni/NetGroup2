using System.Collections.Generic;

namespace MyRecipes.Models
{
    public class RecipeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
