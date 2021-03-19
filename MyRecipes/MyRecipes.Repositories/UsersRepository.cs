using MyRecipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class UsersRepository
    {
        private readonly MyRecipesDbContext _context;

        public UsersRepository(MyRecipesDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
