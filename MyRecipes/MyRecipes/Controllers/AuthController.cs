﻿using Microsoft.AspNetCore.Mvc;
using MyRecipes.Mappings;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SignIn(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.SignInAsync(signInModel.Username, signInModel.Password, signInModel.IsPersistent, HttpContext);

                if (response.IsSuccessful)
                {
                    if(returnUrl == null)
                    {
                        return RedirectToAction("Overview", "Recipes");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var user = signUpModel.ToModel();
                var response = _authService.SignUp(user);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signUpModel);
                }
            }

            return View(signUpModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
