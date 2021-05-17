using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;

namespace MyRecipes.Controllers
{
    [Authorize]
    public class RecipeLikesController : Controller
    {
        private readonly IRecipeLikesService _recipeLikesService;

        public RecipeLikesController(IRecipeLikesService recipeLikesService)
        {
            _recipeLikesService = recipeLikesService;
        }

        public IActionResult Add(int recipeId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _recipeLikesService.Add(recipeId, userId);

            return RedirectToAction("Overview", "Recipes");
        }

        public IActionResult Remove(int recipeId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _recipeLikesService.Remove(recipeId, userId);

            return Ok();
        }
    }
}
