using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.Interfaces;

namespace MyRecipes.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public User GetDetails(string userId)
        {
            return usersRepository.GetById(int.Parse(userId));
        }
    }
}
