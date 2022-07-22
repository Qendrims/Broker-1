using Broker.ApplicationDBContext;
using Broker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Broker.Data
{
    public class AppDbInitializer
    {
        private readonly ApplicationDbContext _db;
        public AppDbInitializer(ApplicationDbContext db)
        {
            this._db = db;
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {

                //Roles

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin)) {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                

                //Users

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();


                var adminUser = await userManager.FindByEmailAsync("admin@brokerapp.com");

                if (adminUser == null)
                {
                    var newAdminUser = new User
                    {
                        Name = "Admin",
                        LastName = "User",
                        Birthday = DateTime.Now,
                        Street = "Mon Maqi",
                        City = "Gjakove",
                        State = "Ks",
                        ZipCode = 50000,
                        UserName = "admin",
                        Email = "admin@brokerapp.com",
                        EmailConfirmed = true,   
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin.1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                

                var appUser = await userManager.FindByEmailAsync("user@brokerapp.com");

                if (appUser == null)
                {
                    var newAppUser = new User
                    {
                        Name = "User",
                        LastName="user",
                        Birthday = DateTime.Now,
                        Street = "Mon Maqi",
                        City = "Gjakove",
                        State = "Ks",
                        ZipCode = 50000,
                        UserName = "user",
                        Email = "user@brokerapp.com",
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "User.1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        
        }

        public static void createCategory(IApplicationBuilder applicationBuilder)
        {
                ApplicationDbContext _db = new ApplicationDbContext();

                Category house = new Category
            {
                CategoryName = "House",
                DefaultActive = true
            };

            Category apartment = new Category
            {
                CategoryName = "Apartment",
                DefaultActive = false
            };

            Category office = new Category
            {
                CategoryName = "Office",
                DefaultActive = false
            };

            Category land = new Category
            {
                CategoryName = "Land",
                DefaultActive = false
            };

            Category bar = new Category
            {
                CategoryName = "Bar",
                DefaultActive = false
            };

            _db.Categories.Add(house);
            _db.Categories.Add(apartment);
            _db.Categories.Add(office);
            _db.Categories.Add(land);
            _db.Categories.Add(bar);
        }
    }
}
