using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using MyRecipes.Services.DtoModels;
using MyRecipes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyRecipes.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<StatusModel> SignInAsync(string username, string password, bool isPersistent, HttpContext httpContext) 
        {
            var response = new StatusModel();
            var user = _usersRepository.GetByUsername(username);

            if(user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var dict = new Dictionary<string, string>();
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Address", user.Address),
                    new Claim("Email", user.Email)
                };

                if (user.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = isPersistent };

                await httpContext.SignInAsync(principal, authProps);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Username or password is incorrect";
            }

            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SignUp(User user)
        {
            var response = new StatusModel();

            var exist = _usersRepository.CheckIfExists(user.Username, user.Email);

            if (exist)
            {
                response.IsSuccessful = false;
                response.Message = "User with username or email already exists";
                return response;
            }

            var newUser = new User()
            {
                Username = user.Username,
                Email = user.Email,
                Address = user.Address,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                DateCreated = DateTime.Now
            };

            _usersRepository.Add(newUser);

            return response;
        }
    }
}
