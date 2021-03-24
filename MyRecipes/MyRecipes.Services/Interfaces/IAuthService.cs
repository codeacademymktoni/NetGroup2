using Microsoft.AspNetCore.Http;
using MyRecipes.Services.DtoModels;

namespace MyRecipes.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, HttpContext httpContext);
    }
}
