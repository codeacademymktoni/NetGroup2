using Microsoft.AspNetCore.Mvc;
using MyRecipes.Mappings;
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
    }
}
