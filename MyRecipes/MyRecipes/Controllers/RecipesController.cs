using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        public List<Recipe> Recipes { get; set; }

        public RecipesController()
        {
            var recipe1 = new Recipe()
            {
                Id = 1,
                Title = "Good Old Fashioned Pancakes",
                Description = "This is a great recipe that I found in my Grandma's recipe book. Judging from the weathered look of this recipe card, this was a family favorite.",
                Ingredients = "1 ½ cups all-purpose flour, 3 ½ teaspoons baking powder, 1 teaspoon salt",
                Directions = "In a large bowl, sift together the flour, baking powder, salt and sugar. Make a well in the center and pour in the milk, egg and melted butter; mix until smooth.Heat a lightly oiled griddle or frying pan over medium-high heat. Pour or scoop the batter onto the griddle, using approximately 1/4 cup for each pancake. Brown on both sides and serve hot.",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F3540097.jpg&w=595&h=791&c=sc&poi=face&q=85"
            };

            var recipe2 = new Recipe()
            {
                Id = 2,
                Title = "Corned Beef Irish Feast",
                Description = "The complete Irish meal, great for St. Patrick's Day, but awesome all year 'round!",
                Ingredients = "1 (3 pound) corned beef brisket with spice packet",
                Directions = "Rinse brisket thoroughly in cool water and place into a large Dutch oven. Generously coat beef with brown sugar on all sides. Pour Irish stout beer around roast, followed by beef stock. Liquid should cover brisket by about 1 inch; add another beer if more liquid is needed.",
                ImageUrl = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F4487181.jpg&w=596&h=399&c=sc&poi=face&q=85"
            };

            Recipes = new List<Recipe> { recipe1, recipe2 };
        }

        public IActionResult Overview()
        {
            return View(Recipes);
        }

        public IActionResult Details(int id)
        {
            var recipe = Recipes.FirstOrDefault(x => x.Id == id);

            if (recipe == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(recipe);
        }
    }
}
