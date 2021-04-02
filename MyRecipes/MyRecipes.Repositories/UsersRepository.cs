using Microsoft.EntityFrameworkCore;
using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System.Linq;

namespace MyRecipes.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {

        public UsersRepository(MyRecipesDbContext context) :base(context)
        { }

        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
        public override User GetById(int entityId)
        {
            return _context.Users.Include(x => x.Comments).ThenInclude(x => x.Recipe).FirstOrDefault(x => x.Id == entityId);
        }
    }
}
