using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System.Collections.Generic;

namespace MyRecipes.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public List<User> GetAll()
        {
            return usersRepository.GetAll();
        }

        public User GetDetails(string userId)
        {
            return usersRepository.GetById(int.Parse(userId));
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            
            var user = usersRepository.GetById(id);

            if(user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }
            else
            {
                user.IsAdmin = !user.IsAdmin;
                usersRepository.Update(user);
            }

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();

            var user = usersRepository.GetById(id);

            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }
            else
            {
                usersRepository.Delete(user);
            }

            return response;
        }
    }
}
