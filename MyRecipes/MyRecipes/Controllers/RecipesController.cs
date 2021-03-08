using Microsoft.AspNetCore.Mvc;
using MyRecipes.Models;
using System;
using System.Collections.Generic;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.CurrentDate = DateTime.Now;

            //var a = 2;
            //var b = 3;
            //var sum = a + b;

            //ViewData["varA"] = a;
            //ViewData["varB"] = b;
            //ViewData["sum"] = sum;

            var recipe1 = new Recipe()
            {
                Id = 1,
                Title = "test recipe",
                Description = "some desc",
                Ingredients = "one, two, three",
                Directions = "some directions",
                ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg?webp=true&quality=90&resize=620%2C563"
            };

            var recipe2 = new Recipe()
            {
                Id = 2,
                Title = "test recipe 2",
                Description = "some desc 2",
                Ingredients = "one, two, three",
                Directions = "some directions",
                ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chorizo-mozarella-gnocchi-bake-cropped-9ab73a3.jpg?webp=true&quality=90&resize=620%2C563"
            };

            var recipes = new List<Recipe> { recipe1, recipe2 };


            return View(recipes);
        }
    }
}
