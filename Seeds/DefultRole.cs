using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Identity;

namespace IndustrialContoroler.Seeds
{
    public static class DefultRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            //if (!roleManager.Roles.Any())
            //{
            await roleManager.CreateAsync(new IdentityRole(Helper.Progreammer.ToString()));//this for Programmer
            await roleManager.CreateAsync(new IdentityRole(Helper.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Helper.SysAdminsitrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Helper.TechnicalSpecialist.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Helper.ReEmployee.ToString()));

            //}

        }

    }
}
