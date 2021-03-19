using Microsoft.AspNetCore.Mvc;
using MyRecipes.Common.Exceptions;
using MyRecipes.Models;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipesService _service { get; set; }

        public RecipesController(IRecipesService service)
        {
            _service = service;
        }

        public IActionResult Overview(string title)
        {
            var recipes = _service.GetRecipesByTitle(title);
            return View(recipes);
        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _service.CreateRecipe(recipe);
                return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe created sucessfully"});
            }

            return View(recipe);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe deleted sucessfully"});
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
    }
}
