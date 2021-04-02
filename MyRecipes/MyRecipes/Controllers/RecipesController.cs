using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Mappings;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
using System.Linq;

namespace MyRecipes.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class RecipesController : Controller
    {
        private IRecipesService _service { get; set; }

        public RecipesController(IRecipesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var user = User;
            var recipes = _service.GetRecipesByTitle(title);

            var recipeOverviewModels = recipes.Select(x => x.ToOverviewModel()).ToList();

            return View(recipeOverviewModels);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var recipe = _service.GetRecipeById(id);

                if (recipe == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var viewModel = recipe.ToDetailsModel();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var recipes = _service.GetAllRecipes();

            var viewModels = recipes.Select(x => x.ToManageOverviewModel()).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateModel recipe)
        {
            if (ModelState.IsValid)
            {
                var domainModel = recipe.ToModel();
                _service.CreateRecipe(domainModel);
                return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe created sucessfully"});
            }

            return View(recipe);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = _service.Delete(id);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe deleted sucessfully"});
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recipe = _service.GetRecipeById(id);

            if (recipe == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = "Recipe not found" });
            }

            return View(recipe.ToUpdateModel());
        }

        [HttpPost] 
        public IActionResult Update(RecipeUpdateModel recipe)
        {
            if (ModelState.IsValid)  
            {
                try
                {
                    var response = _service.Update(recipe.ToModel());

                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe updated successfuly" });
                    }
                    else
                    {
                        return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError", "Info");
                }
            }

            return View(recipe);
        }
    }
}
