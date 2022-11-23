using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser{
                    DisplayName = "Bob",
                    Email = "bob@bob.com",
                    UserName ="Bobis",
                    Address = new Address{
                        FirstName = "Bob",
                        LastName = "Bobson",
                        Street = "10 street",
                        City = "NY",
                        State = "NY",
                        ZipCode = "32218600"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}