using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static IndustrialContoroler.Models.Helper;

namespace IndustrialContoroler.Seeds
{
    public static class DefaultUser
    {
        //programmer
        public static async Task SeedProgrammerAsync(UserManager<AppUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefultUser = new AppUsers
            {
                UserName = Helper.UserNameProgrammer,
                FullName = Helper.FullNameProgrammer,
                Email = Helper.EmailProgrammer,
                PhoneNumber = Helper.phoneProgrammer,
                ImageUser = Helper.image,
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(DefultUser.UserName);
            if (user == null)
            {
                await userManager.CreateAsync(DefultUser, Helper.PasswordProgrammer);
                await userManager.AddToRolesAsync(DefultUser, new List<string> { Helper.Progreammer.ToString() });
            }
            //code seedin clims
            await roleManager.SeedClaimsAsync();


        }

       
        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Progreammer.ToString());
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsFromModule(module);

            foreach (var permission in allPermissions)
                if (!allClaims.Any(x => x.Type == Permission && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(Permission, permission));
        }
    }
}
