using MyRecipes.Models;

namespace MyRecipes.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
        User GetById(int userId);
    }
}
