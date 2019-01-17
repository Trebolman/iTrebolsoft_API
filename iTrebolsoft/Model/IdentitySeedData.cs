using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace iTrebolsoft.Model
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Daniele";
        private const string adminPassword = "Daniele1234";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Daniele");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}