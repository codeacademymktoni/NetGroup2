using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Mappings;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecipes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirst("Id").Value;
            var user = usersService.GetDetails(userId);

            if(user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }

            return View(user.ToDetailsModel());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageOverview(string successMessage, string errorMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;

            var id = int.Parse(User.FindFirst("Id").Value);
            var users = usersService.GetAll();
            var viewModel = users.Where(x => x.Id != id).Select(x => x.ToManageOverviewModel()).ToList();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ToggleAdminRole(int id)
        {
            var response = usersService.ToggleAdminRole(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User updated successfuly"});
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var response = usersService.Delete(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "User deleted successfuly" });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }
    }
}
