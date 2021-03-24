using MyRecipes.Models;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
    }
}
