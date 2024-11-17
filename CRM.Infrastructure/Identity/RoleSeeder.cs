using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Seeders
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Define roles
            string[] roles = { "Admin", "Sales Manager", "Sales Executive" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Admin user
            var adminUser = await userManager.FindByEmailAsync("admin@filipscrmapp.com");
            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = "admin@filipscrmapp.com",
                    Email = "admin@filipscrmapp.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newAdmin, "Admin123!"); // Ensure a strong password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }

            // Seed Sales Manager user
            var salesManagerUser = await userManager.FindByEmailAsync("salesmanager@filipscrmapp.com");
            if (salesManagerUser == null)
            {
                var newSalesManager = new IdentityUser
                {
                    UserName = "salesmanager@filipscrmapp.com",
                    Email = "salesmanager@filipscrmapp.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newSalesManager, "Manager123!"); // Ensure a strong password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newSalesManager, "Sales Manager");
                }
            }

            // Seed Sales Executive user
            var salesExecutiveUser = await userManager.FindByEmailAsync("salesexecutive@filipscrmapp.com");
            if (salesExecutiveUser == null)
            {
                var newSalesExecutive = new IdentityUser
                {
                    UserName = "salesexecutive@filipscrmapp.com",
                    Email = "salesexecutive@filipscrmapp.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newSalesExecutive, "Executive123!"); // Ensure a strong password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newSalesExecutive, "Sales Executive");
                }
            }
        }
    }
}
