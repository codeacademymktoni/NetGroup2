using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Models;

namespace PizzaPlace.Pages.Dashboard
{
    public class UsersListModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersListModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        public void OnGet()
        {
            Users = _userManager.Users.ToList();
            Roles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnGetRemoveRole(string roleName, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, roleName);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetAddRole(string roleName, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetDeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);

            return RedirectToPage();
        }
    }
}
