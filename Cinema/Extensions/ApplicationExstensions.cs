using BuisnessLogic.Helpers;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BuisnessLogic.Extensions
{
    public static class ApplicationExstensions
    {
        public static void SeedRolesAndInitialAdmin(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                IdentityInitializer.SeedRolesAsync(roleManager).Wait();
                IdentityInitializer.SeedAdminAsync(userManager).Wait();
            }
        }
    }
}
