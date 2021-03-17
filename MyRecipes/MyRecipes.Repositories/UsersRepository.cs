using MyRecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
