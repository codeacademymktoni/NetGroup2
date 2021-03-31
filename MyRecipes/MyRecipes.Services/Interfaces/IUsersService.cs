using MyRecipes.Models;
using MyRecipes.Services.DtoModels;
using System.Collections.Generic;

namespace MyRecipes.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        List<User> GetAll();
        StatusModel ToggleAdminRole(int id);
        StatusModel Delete(int id);
    }
}
