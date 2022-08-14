using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppAdmin> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppAdmin>{
                   new AppAdmin
                    {
                        Name = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com",
                        AccessType="admin"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }


            await context.SaveChangesAsync();


        }

        public static async Task SeedRolesAsync(UserManager<AppAdmin> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Domain.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Domain.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Domain.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Domain.Roles.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<AppAdmin> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new AppAdmin
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Domain.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Domain.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Domain.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Domain.Roles.SuperAdmin.ToString());
                }
            }
        }
    }
}