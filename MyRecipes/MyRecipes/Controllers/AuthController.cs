using Microsoft.AspNetCore.Mvc;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;

namespace MyRecipes.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                
                var response = _authService.SignIn(signInModel.Username, signInModel.Password, signInModel.IsPersistent, HttpContext);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("Overview", "Recipes");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signInModel);
                }
            }

            return View(signInModel);
        }

        public IActionResult SignOut()
        {
            //sign out
            _authService.SignOut(HttpContext);
            return RedirectToAction("Overview", "Recipes");
        }
    }
}
