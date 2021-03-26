using MyRecipes.Models;

namespace MyRecipes.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
    }
}
