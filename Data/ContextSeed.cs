using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Svetaine.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager,//sukuria roles
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Moderator"));
            await roleManager.CreateAsync(new IdentityRole("User"));

        }
        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "martynas.vai263@go.kauko.lt",//admin username ir email
                Email = "martynas.vai263@go.kauko.lt",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);//patikrina ar egzistuoja admin acc
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Martis123!");//passwordas
                    await userManager.AddToRoleAsync(defaultUser, "Admin");//priskiriamos roles adminui
                    await userManager.AddToRoleAsync(defaultUser, "Moderator");
                    await userManager.AddToRoleAsync(defaultUser, "User");

                }

            }
        }
    }
}
