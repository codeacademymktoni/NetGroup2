using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipesService _service{ get; set; }

        public RecipesController(IRecipesService service)
        {
            _service = service;
        }

        public IActionResult Overview()
        {
            var recipes = _service.GetAllRecipes();
            return View(recipes);
        }

        public IActionResult Details(int id)
        {
            try
            {
                var recipe = _service.GetRecipeById(id);

                if (recipe == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(recipe);
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("ErrorGeneral", "Info");
            }
        }
    }
}
