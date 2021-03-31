using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Collections.Generic;
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

        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Add(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
