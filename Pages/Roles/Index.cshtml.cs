using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Svetaine.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IList<IdentityUser> usersL { get; set; }
        public IList<IdentityRole> rolesL { get; set; }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            usersL = users;
            

            var roles = await _roleManager.Roles.ToListAsync();

            



            return Page();
        }
        private async Task<List<string>> GetUserRoles(IdentityUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
