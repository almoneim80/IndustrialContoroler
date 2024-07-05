using IndustrialContoroler.Models;
using IndustrialContoroler.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IndustrialContoroler.Constants;
using Microsoft.AspNetCore.Authorization;

namespace IndustrialContoroler.Controllers
{
    [Authorize(Permissions.Roles.View)]
    public class RolesController : Controller
    {


        #region Constructor
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IndustrialContorolerDatabaseContext _context;
        private readonly IHttpContextAccessor _sesstion;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUsers> userManager, IndustrialContorolerDatabaseContext context, IHttpContextAccessor sesstion)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _sesstion = sesstion;
        }
        #endregion



        #region Method


        // GET: RolesContoller/Create
        public ActionResult Role()
        {

            var model = new RoleVM();
            {
                model.NewRole = new NewRole();
                model.Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList();

            };
            return View(model);

        }

        // POST: RolesContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Roles.Create)]
        public async Task<ActionResult> Role(RoleVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model.NewRole.RoleId == null)
                    {
                        //role.Id = Guid.NewGuid().ToString();
                        if (_roleManager.Roles.FirstOrDefault(x => x.Name.Equals(model.NewRole.RoleName.Trim())) != null)
                        {
                            SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotSavedMsgRolealreadyExists);
                            return RedirectToAction(nameof(Role));
                        }
                        else
                        {
                            var result = await _roleManager.CreateAsync(new IdentityRole(model.NewRole.RoleName));

                            if (result.Succeeded)// Succeeded 
                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbSave, Resource.ResourceWeb.lbSaveMsgRole);
                            else // Not Successeded
                                SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotSavedMsgRole);
                        }
                    }
                    else //Update
                    {
                        if (model.NewRole.RoleName == Helper.SuperAdmin || model.NewRole.RoleName == Helper.ReEmployee
                            || model.NewRole.RoleName == Helper.TechnicalSpecialist || model.NewRole.RoleName == Helper.SysAdminsitrator)
                        {
                            SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotEditteRole, Resource.ResourceWeb.lbNotEditteRoleMs);
                            return RedirectToAction(nameof(Role));
                        }
                        else
                        {
                            var RoleUpdate = await _roleManager.FindByIdAsync(model.NewRole.RoleId);
                            RoleUpdate.Id = model.NewRole.RoleId;
                            RoleUpdate.Name = model.NewRole.RoleName;
                            var Result = await _roleManager.UpdateAsync(RoleUpdate);
                            if (Result.Succeeded) // Succeeded
                                                  //contain of index Roles

                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbUpdateMsgRole);
                            else  // Not Successeded
                                SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgRole);
                        }
                    }
                }
                return RedirectToAction("Role");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit Dept Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction("Role");
            }
        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Permissions.Roles.Delete)]
        public async Task<ActionResult> Delete(string Id)
        {
            try
            {
                var role = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
                if (role.Name == Helper.SuperAdmin || role.Name == Helper.ReEmployee || role.Name == Helper.TechnicalSpecialist || role.Name == Helper.SysAdminsitrator)
                {
                    SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotDeleteRole, Resource.ResourceWeb.lbNotdeleteRoleMs);
                    return RedirectToAction(nameof(Role));
                }
                else if ((await _roleManager.DeleteAsync(role)).Succeeded)
                {
                    return RedirectToAction("Role");
                }
                return RedirectToAction(nameof(Role));
            }
            catch (Exception ex)
            {

                Console.WriteLine($"=====Exp In Edit Dept Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return View();
            }
        }




        //session and sweetalert

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }
        #endregion
    }
}
