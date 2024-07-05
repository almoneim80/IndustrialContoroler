using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using IndustrialContoroler.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Controllers
{
    [Authorize(Permissions.Account.View)]
    public class AccountController : Controller
    {
        #region Decleration
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly UserManager<AppUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IndustrialContorolerDatabaseContext _context;
        private readonly IHttpContextAccessor _sesstion;

        #endregion

        #region Constrctor
        public AccountController(SignInManager<AppUsers> signInManager, UserManager<AppUsers> userManager,
            RoleManager<IdentityRole>
           roleManager, IndustrialContorolerDatabaseContext context, IHttpContextAccessor sesstion)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _sesstion = sesstion;
        }
        #endregion

        //=================

        #region Method
        public IActionResult Index()
        {
            return View();
        }

        //method to get Cuurentuser


        //Denied
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


        //Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            //ViewData["ReturnUrl"]= returnUrl;
            //Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");//tp
            //Response.Headers.Add("Pragma", "no-cache");
            //Response.Headers.Add("Expires", "0");
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> LoginAsync(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorLogin = false;
                    return View();
                }

            }

            return View(login);
        }



        [HttpGet]
        [Authorize(Permissions.Account.View)]
        public IActionResult Register()
        {

            var obj = new UserVM
            {
                newRegister = new UserVM.NewRegister(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                Users = _context.VwUsers.OrderBy(x => x.Role).ToList(),

            };

            return View(obj);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Account.Create)]
        /*        [Authorize(Permissions.Account.Edit)]
        */
        public async Task<IActionResult> RegisterAsync(UserVM obj)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    var file = HttpContext.Request.Form.Files;
                    if (file.Count() > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        obj.newRegister.ImageUser = ImageName;
                    }
                    else if (obj.newRegister.ImageUser == null)
                    {
                        //Not Upload Image
                        obj.newRegister.ImageUser = "DefultImage.jpg";
                    }
                    else
                    {
                        obj.newRegister.ImageUser = obj.newRegister.ImageUser;
                    }
                    var user = new AppUsers
                    {
                            
                        Id = obj.newRegister.Id,
                        FullName = obj.newRegister.FullName,
                        UserName = obj.newRegister.UserName,
                        Email = obj.newRegister.Email,
                        PhoneNumber = obj.newRegister.PhoneNumber,
                        ActiveUser = obj.newRegister.ActiveUser,
                        ImageUser = obj.newRegister.ImageUser
                    };
                    if (user.Id == null)
                    {
                        //Create
                        user.Id = Guid.NewGuid().ToString();
                        var result = await _userManager.CreateAsync(user, obj.newRegister.Password);
                        if (result.Succeeded)
                        {   //Succsseded
                            var role = await _userManager.AddToRoleAsync(user, obj.newRegister.RoleName);
                            if (role.Succeeded)
                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbSave, Resource.ResourceWeb.lbSaveMsgUser);
                            else // Not Successeded
                                SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotSavedMsgUser);

                        }
                        else //Not Successeded
                        {
                            SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbthenameisDuplicate);
                        }
                    }
                    else
                    {
                        //------------------Update------//
                        var userupdate = await _userManager.FindByIdAsync(user.Id);
                        //userupdate.Id = user.Id;
                        userupdate.FullName = obj.newRegister.FullName;
                        userupdate.UserName = obj.newRegister.UserName;
                        userupdate.Email = obj.newRegister.Email;
                        userupdate.PhoneNumber = obj.newRegister.PhoneNumber;
                        userupdate.ActiveUser = obj.newRegister.ActiveUser;
                        userupdate.ImageUser = obj.newRegister.ImageUser;

                        var result = await _userManager.UpdateAsync(userupdate);
                        if (result.Succeeded)
                        {
                            var oldRole = await _userManager.GetRolesAsync(userupdate);
                            await _userManager.RemoveFromRolesAsync(userupdate, oldRole);
                            var addRole = await _userManager.AddToRoleAsync(userupdate, obj.newRegister.RoleName);

                            if (addRole.Succeeded)
                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbUpdateMsgUser);
                            else // Not Successeded
                                SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
                        }
                        else
                            SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbthenameisDuplicate);

                        return RedirectToAction(nameof(Register));
                    }
                    return RedirectToAction("Register", "Account");
                }
                SessionMsg(Helper.Error, Resource.ResourceWeb.ErroNOExcepted, Resource.ResourceWeb.ErrorVald);

                return RedirectToAction("Register", "Account");
            }
            catch (Exception)
            {

                Console.WriteLine("in else in login user");
                return View(); ;
            }
        }


        //----------------------------------------End Create And Update
        //delete


        [Authorize(Permissions.Account.Delete)]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                var cuurentUsre = await _userManager.FindByNameAsync(User.Identity?.Name);

                if (cuurentUsre.Id != userId)
                {
                    var User = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                    //to delet image user
                    if (User.ImageUser != null && User.ImageUser != Guid.Empty.ToString())
                    {
                        var PathImage = Path.Combine(@"wwwroot/", Helper.PathImageuser, User.ImageUser);
                        if (System.IO.File.Exists(PathImage))
                            System.IO.File.Delete(PathImage);
                    }

                    if ((await _userManager.DeleteAsync(User)).Succeeded)
                        return RedirectToAction("Register", "Account");

                    return RedirectToAction("Register", "Account");
                }

                else
                {
                    SessionMsg(Helper.Error, Resource.ResourceWeb.ErroNOExcepteddelete, Resource.ResourceWeb.cannotDeleteYourSelf);
                    return RedirectToAction("Register", "Account");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("in else in login user");
                return View(); ;
            }
        }


        /////change password
        /// <summary>

        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //
        [Authorize(Permissions.Account.Edit)]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(UserVM model)
        {
            var user = await _userManager.FindByIdAsync(model.ChangePassword.Id);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                var AddNewPassword = await _userManager.AddPasswordAsync(user, model.ChangePassword.NewPassword);
                if (AddNewPassword.Succeeded)
                    SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbMsgSavedChangePassword);
                else // Not Successeded
                    SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbMsgNotSavedChangePassword);


                return RedirectToAction(nameof(Register));
            }

            return RedirectToAction(nameof(Register));

        }

        //method to get cuurent user
        //[AllowAnonymous]
        //private async Task<AppUsers> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        //[AllowAnonymous]
        //public async Task<string> GetCurrentUserId()
        //{
        //    var user = await GetCurrentUserAsync();
        //    return user.Id;
        //}
        //-----------------Profile--------------------
        //-------------------------------------------
        //------------------------------------------

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ProFile()
        {

            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var userData = _userManager.Users.FirstOrDefault(x => x.Id.Equals(user.Id));
            var obj = new profileVM
            {
                NewPro = new profileVM.newPro(),


            };
            obj.NewPro.Id = userData.Id;
            obj.NewPro.FullName = userData.FullName;
            //obj.NewPro.UserName = userData.UserName;
            obj.NewPro.Email = userData.Email;
            obj.NewPro.PhoneNumber = userData.PhoneNumber;
            obj.NewPro.ImageUser = userData.ImageUser;
            ViewData["id"] = userData.Id;
            ViewData["FullName"] = userData.FullName;
            ViewData["UserName"] = userData.UserName;
            ViewData["Email"] = userData.Email;
            ViewData["imageName"] = userData.ImageUser;
            ViewData["PhoneNumber"] = userData.PhoneNumber;
            return View(obj);



        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ProFileAsync(profileVM model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                if (ModelState.IsValid)
                {
                    var file = HttpContext.Request.Form.Files;
                    if (file.Count() > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        model.NewPro.ImageUser = ImageName;
                    }
                    else if (model.NewPro.ImageUser == null)
                    {
                        //Not Upload Image
                        model.NewPro.ImageUser = user.ImageUser;
                    }
                    else
                    {
                        model.NewPro.ImageUser = model.NewPro.ImageUser;
                    }

                    if (model.NewPro.Id != null)
                    {

                        //------------------Update------//
                        var userupdate = await _userManager.FindByIdAsync(user.Id);
                        //userupdate.Id = user.Id;
                        userupdate.FullName = model.NewPro.FullName;
                        //userupdate.UserName = model.NewPro.UserName;
                        userupdate.Email = model.NewPro.Email;
                        userupdate.PhoneNumber = model.NewPro.PhoneNumber;
                        userupdate.ImageUser = model.NewPro.ImageUser;

                        var result = await _userManager.UpdateAsync(userupdate);
                        if (result.Succeeded)
                        {

                            SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbUpdateMsgUser);
                            return RedirectToAction("ProFile", "Account");
                        }
                        else
                            SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbthenameisDuplicate);

                        return RedirectToAction(nameof(ProFile));
                    }
                    return RedirectToAction("ProFile", "Account");
                }
                SessionMsg(Helper.Error, Resource.ResourceWeb.ErroNOExcepted, Resource.ResourceWeb.ErrorVald);

                return RedirectToAction("ProFile", "Account");
            }
            catch (Exception)
            {

                Console.WriteLine("in else in login user");
                return View(); ;
            }
        }

        //chande password profile
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ChangePasswordprofile(profileVM Profile)
        {

            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            var userid = await _userManager.FindByIdAsync(user.Id);

            if (userid != null)
            {
                var changepassword = await _userManager.ChangePasswordAsync(user, Profile.ChangePasswordPf.OldPassword, Profile.ChangePasswordPf.NewPassword);
                //await _userManager.RemovePasswordAsync(user);
                //var AddNewPassword = await _userManager.AddPasswordAsync(user, Profile.ChangePassword.NewPassword);
                if (changepassword.Succeeded)
                    SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbMsgSavedChangePassword);
                else // Not Successeded
                    SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbMsgNotSavedChangePassword);


                return RedirectToAction(nameof(ProFile));
            }

            return RedirectToAction(nameof(ProFile));



        }
        //----------------------Logut

        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        //--------------------------------------------------------------------------------------
        //this Session And Aelert
        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }
        #endregion

    }

    //End Login

    //Begin Rgister



}
