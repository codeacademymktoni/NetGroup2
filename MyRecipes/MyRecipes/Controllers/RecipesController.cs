using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Common.Models;
using MyRecipes.Common.Services;
using MyRecipes.Mappings;
using MyRecipes.Models;
using MyRecipes.Services;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class RecipesController : Controller
    {
        private readonly ILogService _logService;
        private IRecipesService _service { get; set; }
        private ISidebarService _sidebarService { get; set; }

        public RecipesController(IRecipesService service, ISidebarService sidebarService, ILogService logService)
        {
            _service = service;
            _sidebarService = sidebarService;
            _logService = logService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            throw new Exception("this is test exception");
            var user = User;
            var recipes = _service.GetRecipesByTitle(title);

            var overviewDataModel = new RecipeOverviewDataModel();

            var recipeOverviewModels = recipes.Select(x => x.ToOverviewModel()).ToList();
            overviewDataModel.OverviewRecipes = recipeOverviewModels;
            overviewDataModel.SidebarData = _sidebarService.GetSidebarData();

            return View(overviewDataModel);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var recipe = _service.GetRecipeDetails(id);

                if (recipe == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var recipeDetailsDataModel = new RecipeDetailsDataModel();

                recipeDetailsDataModel.RecipeDetails = recipe.ToDetailsModel();

                recipeDetailsDataModel.SidebarData = _sidebarService.GetSidebarData();

                return View(recipeDetailsDataModel);
            }
            catch (Exception)
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

                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with id {userId} created recipe {recipe.Title}" };
                _logService.Log(logData);

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
