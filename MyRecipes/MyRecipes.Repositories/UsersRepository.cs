using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MyRecipesDbContext _context;

        public UsersRepository(MyRecipesDbContext context)
        {
            _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
