using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Data
{
    public class Seed
    {

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //беру роли админ и юзер из моего класса юзерролс
                if (!await roleManager.RoleExistsAsync(UserRoless.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoless.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoless.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoless.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "dasha@mail.ru";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)//если нет имэйла то создаю пользователя с этим имэйлом
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "dasha",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Adress = new Address
                        {
                            City = "Kazan",
                            Street = "Pushkina 32",
                            Region = "Tatarstan Republic"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");//даю этому пользователю паролль Coding@1234?
                    await userManager.AddToRoleAsync(newAdminUser, UserRoless.Admin);//даю этому пользователю роль
                }

                string appUserEmail = "user@mail.ru";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Adress = new Address
                        {
                            City = "Kazan",
                            Street = "Pushkina 32",
                            Region = "Tatarstan Republic"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoless.User);
                }
            }
        }
    }
}
