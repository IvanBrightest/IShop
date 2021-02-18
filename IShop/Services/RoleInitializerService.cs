using IShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Services
{
    public class RoleInitializerService
    {
        public static async Task InitializeAsync(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "ivan.brightest@gmail.com";
            string login = "Administrator";
            string password = "123456Qq@";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                IdentityRole adminRole = new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "Администратор"
                };
                await roleManager.CreateAsync(adminRole);
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                IdentityRole userRole = new IdentityRole()
                {
                    Name = "user",
                    NormalizedName = "Пользователь"
                };
                await roleManager.CreateAsync(userRole);
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                Customer admin = new Customer { Email = adminEmail, UserName = login };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
