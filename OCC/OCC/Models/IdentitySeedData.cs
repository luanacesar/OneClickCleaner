using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCC.Models
{
    public static class IdentitySeedData
    {
        private const string cleaner1 = "Mary";
        private const string cleaner1Email = "mary_smith@gmail.com";
        private const string cleaner1Password = "Cleaner123@";

        private const string cleaner2 = "Jhosua";
        private const string cleaner2Password = "Cleaner123@";
        private const string cleaner2Email = "jhosua@gmail.com";

        private const string cleaner3 = "Rob";
        private const string cleaner3Password = "Cleaner123@";
        private const string cleaner3Email = "rob@gmail.com";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            //
            UserManager<AppUser> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<AppUser>>();

            //clean1 user
            AppUser user1 = await userManager.FindByNameAsync(cleaner1);

            if (user1 == null)
            {
                AppUser appUser = new AppUser
                {
                    UserName = cleaner1,
                    Email = cleaner1Email
                };
                IdentityResult result = await userManager.CreateAsync(
                       appUser, cleaner1Password);
            }

            //clean2 user
            AppUser user2 = await userManager.FindByNameAsync(cleaner2);

            if (user2 == null)
            {
                AppUser appUser = new AppUser
                {
                    UserName = cleaner2,
                    Email = cleaner2Email
                };
                IdentityResult result = await userManager.CreateAsync(
                       appUser, cleaner2Password);
            }

            //clean3 user
            AppUser user3 = await userManager.FindByNameAsync(cleaner3);

            if (user3 == null)
            {
                AppUser appUser = new AppUser
                {
                    UserName = cleaner3,
                    Email = cleaner3Email
                };
                IdentityResult result = await userManager.CreateAsync(
                       appUser, cleaner3Password);
            }


        }
    }
}
