﻿using Microsoft.AspNetCore.Http;
using MyRecipes.Models;
using MyRecipes.Services.DtoModels;

namespace MyRecipes.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User user);
    }
}
