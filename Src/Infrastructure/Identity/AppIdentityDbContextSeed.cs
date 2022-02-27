using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
     public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            //Admin rolu henüz yoksa oluşturur.
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "admin" });
            }

            if (!await roleManager.RoleExistsAsync("member"))
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "member" });
            }

            //seckin@xyz.com kullanıcısı yok ise oluştur ve sonra admin rolune ata

            if (!await userManager.Users.AnyAsync(x => x.Email == "seckin@xyz.com"))
            {
                AppUser u1 = new()
                {
                    NickName = "unstoppable",
                    FullName = "seckinmantar",
                    RoleType = true,
                    UserName = "seckin@xyz.com",
                    Email = "seckin@xyz.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(u1, "Seckin123_");
                await userManager.AddToRoleAsync(u1, "admin");
            }
        }
     }
}
