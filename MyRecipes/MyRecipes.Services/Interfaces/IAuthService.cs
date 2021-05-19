using Microsoft.AspNetCore.Http;
using MyRecipes.Models;
using MyRecipes.Services.DtoModels;
using System.Threading.Tasks;

namespace MyRecipes.Services.Interfaces
{
    public interface IAuthService
    {
        Task<StatusModel> SignInAsync(string username, string password, bool isPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User user);
    }
}
