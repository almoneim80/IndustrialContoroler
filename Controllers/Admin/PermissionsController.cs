using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using IndustrialContoroler.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IndustrialContoroler.Controllers
{
    [Authorize(Permissions.Account.View)]
    public class PermissionsController : Controller
    {
        #region Constructor
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _sesstion;
        public PermissionsController(RoleManager<IdentityRole> roleManager, IHttpContextAccessor sesstion)
        {
            _roleManager = roleManager;
            _sesstion = sesstion;
        }
        #endregion


        #region Method
        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var claims = _roleManager.GetClaimsAsync(role).Result.Select(x => x.Value).ToList();
            var allPermissions = Permissions.PermissionsList()
                    .Select(x => new RoleClaimsViewModel { Value = x }).ToList();
            foreach (var permission in allPermissions)
                if (claims.Any(x => x == permission.Value))
                    permission.Selected = true;

            return View(new PermissionVM
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleClaims = allPermissions
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PermissionVM model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
                await _roleManager.RemoveClaimAsync(role, claim);

            var SelectedClaims = model.RoleClaims.Where(x => x.Selected).ToList();
            foreach (var claim in SelectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim(Helper.Permission, claim.Value));
            SessionMsg(Helper.Success, Resource.ResourceWeb.lbSave, Resource.ResourceWeb.lbbtnSavepermission);

            return RedirectToAction("Role", "Roles");
        }

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }

        #endregion


    }
}
