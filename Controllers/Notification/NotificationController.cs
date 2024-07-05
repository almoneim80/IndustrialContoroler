using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using IndustrialContoroler.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IndustrialContoroler.Controllers.Notification
{
    [Authorize(Permissions.Notification.View)]
    public class NotificationController : Controller
    {
        private readonly IndustrialContorolerDatabaseContext _context;
        private readonly UserManager<AppUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _sesstion;


        // GET: NotificationController
        public NotificationController(IndustrialContorolerDatabaseContext context,
            UserManager<AppUsers> userManager, RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor sesstion)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager; 
            _sesstion = sesstion;
        }


        // GET: Notification
        public ActionResult Index()
        {
            var notification=_context.Notis.ToList();
            return View(notification);
        }   

        // GET: Notification/Create
        public IActionResult Create()
        {
            return View(); 
        }

        //POST: Notification/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,RoleId,ToUserId")] NotificationVM model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (ModelState.IsValid)
            {
                var notification = new Noti
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = DateTime.Now,
                    Sender = user.FullName,
                    Receiver = model.ToUserId,
                    ImageSender= user.ImageUser,
                    IsRead = false,
                    IsDeleted = false
                };
                
                _context.Add(notification);
                await _context.SaveChangesAsync();
                SessionMsg(Helper.Success, Resource.ResourceWeb.lbsendMessage, Resource.ResourceWeb.lbsendMessageDon);

                return RedirectToAction(nameof(Index));
            }

            ViewData["Roles"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Roles, "Name", "Name");
            return View(model);
        }

        //POST: Notification/Delete/5
        //[HttpPost]

        //[ValidateAntiForgeryToken]
        [Authorize(Permissions.Notification.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var notification = await _context.Notis.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            notification.IsDeleted = true;
            _context.Update(notification);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Notification/GetUsersInRole/rolename
        public async Task<IActionResult> GetUsersInRole(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName);
            var result = users.Select(u => new { u.Id, u.FullName }).ToList();
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Notis.FindAsync(id);
            notification.IsRead = true;
            _context.Entry(notification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //==============Make ALl notification As read
        [HttpPost]
        public async Task<ActionResult> MarkAllAsRead()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            var notification =_context.Notis.Where(n => n.Receiver == user.Id && !n.IsRead);
            foreach(var n in notification)
            {
                n.IsRead = true;
            }

            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //reject the Request

        [HttpGet]
        public IActionResult ShowReasonReject(int Id)
        {
            //List<RequestAttsAttsTypeVM> requestAttVMs = new List<RequestAttVM>();

            var GetTheReason = _context.Notis.Where(e=>e.FaId==Id &&e.IsDeleted == false).OrderByDescending(x => x.Date).ToList();

            if (GetTheReason == null)
            {
                return NotFound();
            }


            return View(GetTheReason);
        }



        /********************************************************/
        [HttpGet]
        public IActionResult NotForEdit(int Id)
        {
            //List<RequestAttsAttsTypeVM> requestAttVMs = new List<RequestAttVM>();

            var GetThenNotiForEdit = _context.Notis.Where(e => e.FaId == Id && e.IsDeleted == false).OrderByDescending(x=>x.Date).ToList();

            if (GetThenNotiForEdit == null)
            {
                return NotFound();
            }


            return View(GetThenNotiForEdit);
        }
        //--------------------------------------------------------------------------------------
        //View Specific notificatio
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            //List<RequestAttsAttsTypeVM> requestAttVMs = new List<RequestAttVM>();

            var GetNoti = _context.Notis.Where(e => e.Id == Id && e.IsDeleted == false).FirstOrDefault();

            if (GetNoti == null)
            {
                return NotFound();
            }


            return View(GetNoti);
        }

     
 

        //--------------------------------------------------------------------------------------
        //this Session And Aelert
        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }

    }
   }
