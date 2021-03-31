using MyRecipes.Models;
using System.Collections.Generic;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
        bool CheckIfExists(string username, string email);
    }
}
