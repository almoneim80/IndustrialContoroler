using IndustrialContoroler.Models;
using IndustrialContoroler.Models.requestsViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndustrialContoroler.IRepository.RequestRepository;
using IndustrialContoroler.IRepository.AttachmentRepository;
using IndustrialContoroler.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using IndustrialContoroler.Constants;
using IndustrialContoroler.ViewModel;

namespace IndustrialContoroler.Controllers.Requests
{
    [Authorize(Permissions.Request.View)]
    public class RequestController : Controller
    {
        private IndustrialContorolerDatabaseContext _context;
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor _sesstion;
        private readonly UserManager<AppUsers> _userManager;


        //request
        private readonly IRequestRepository<Request> _Requestrepository;
        private readonly IAttachmentRepository<Attachment> _attachmentrepository;
        private readonly IServicesRepositoryLogRequeist<RequestTraffic> _servicesRepositoryLog;
        private readonly IServiceREpositoryRequest<Request> _serviceREpositoryRequest;
        List<RequestAttVM> requestAttVMs = new List<RequestAttVM>();

        public int Request_Id;

        public RequestController(IndustrialContorolerDatabaseContext
            context, IWebHostEnvironment env,
            IHttpContextAccessor sesstion, UserManager<AppUsers> userManager,
            IRequestRepository<Request> requestrepository,
            IAttachmentRepository<Attachment> attachmentrepository,
            IServicesRepositoryLogRequeist<RequestTraffic> servicesRepositoryLog,
            IServiceREpositoryRequest<Request> serviceREpositoryRequest
            )
        {
            _context = context;
            this.env = env;
            _sesstion = sesstion;
            _userManager = userManager;
            _Requestrepository = requestrepository;
            _attachmentrepository = attachmentrepository;
            _servicesRepositoryLog = servicesRepositoryLog;
            _serviceREpositoryRequest = serviceREpositoryRequest;
        }



        //Index to show all requestes data
        public IActionResult Index()
        {
            return View();
        }

        /********************************************************/
        /********************************************************/


        // Create request with its attachments in the same page
        [HttpGet]
        public IActionResult Create()
        {
            AllRequestDataVM request = new AllRequestDataVM();
            request.attachments.Add(new RequestAttVM() { });

            return View(request);
        }

        [HttpPost]
        public IActionResult Create(AllRequestDataVM request)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                else
                {
                    if (request.ReType == null)
                    {
                        TempData["ReTypeError"] = "يرجى تحديد نوع الطلب";
                        return View(request);
                    }
                    else if (request.ReDate == null)
                    {
                        TempData["ReDateError"] = "يرجى إدخال تاريخ الطلب";
                        return View(request);
                    }
                    else if (request.ReDate > DateTime.Now)
                    {
                        TempData["ReDateError"] = "لايمكن إدخال تاريخ أكبر من تاريخ اليوم" + DateTime.Now.ToString();
                        return View(request);
                    }
                    else if (request.ReFormNo == 0)
                    {
                        TempData["ReFormNoError"] = "يرجى إدخال رقم إستمارة الطلب";
                        return View(request);
                    }
                    else if (request.ReSuemNo == 0)
                    {
                        TempData["ReSuemNoError"] = "يرجى إدخال رقم السند";
                        return View(request);
                    }
                    else if (request.ReApplicant == null)
                    {
                        TempData["ReApplicantError"] = "يرجى إدخال اسم مقدم الطلب";
                        return View(request);
                    }
                    else
                    {
                        var RequestFormNo = _context.Requests.Where(re => re.IsDeleted == false && re.ReFormNo.Equals(request.ReFormNo)).Select(x => x.ReFormNo).FirstOrDefault();
                        if (RequestFormNo != null)
                        {
                            TempData["ExistRequestFormNo"] = "يبدو انك تحاول إدخال رقم إستمارة طلب موجود مسبقاً";
                            return View(request);
                        }

                        var RequestSuemNo = _context.Requests.Where(re => re.IsDeleted == false && re.ReSuemNo.Equals(request.ReSuemNo)).Select(x => x.ReSuemNo).FirstOrDefault();
                            if (RequestSuemNo != null)
                            {
                                TempData["ExistRequestSuemNo"] = "يبدو انك تحاول إدخال رقم سند موجود مسبقاً";
                                return View(request);
                            }

                        if (request.attachments.Count == 0)
                        {
                            TempData["Error"] = "لايمكن أضافة طلب بدون مرفقات";
                            return View(request);
                        }
                        else
                        {
                            Request requestData = new Request();
                            requestData.ReType = request.ReType;
                            requestData.ReDate = request.ReDate;
                            requestData.ReApplicant = request.ReApplicant;
                            requestData.ReFormNo = request.ReFormNo;
                            requestData.ReSuemNo = request.ReSuemNo;

                            _Requestrepository.Add(requestData);


                            string[] allowedExtentions = { ".jpg", ".png", ".jpeg", ".pdf", ".docx" };
                            foreach (var item in request.attachments)
                            {
                                if (item.AtUrl != null)
                                {
                                    if (!allowedExtentions.Contains(Path.GetExtension(item.AtUrl.FileName).ToLower()))
                                    {
                                        TempData["Error"] = Path.GetExtension(item.AtUrl.FileName).ToLower().ToString() + "هذا النوع من الملفات غير مسوح به";
                                        return View(request);
                                    }
                                    else
                                    {
                                        var Stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RequestAtts", Path.GetFileName(item.AtUrl.FileName)), FileMode.Create);
                                        item.AtUrl.CopyToAsync(Stream);
                                        Stream.Close();

                                        var RequestId = _context.Requests.Where(re => re.ReFormNo == request.ReFormNo && re.IsDeleted == false).Select(x => x.ReId).FirstOrDefault();
                                        Attachment attachmentData = new Attachment();
                                        attachmentData.AtUrl = item.AtUrl.FileName;
                                        attachmentData.ReId = RequestId;
                                        attachmentData.AttId = item.AttId;

                                        _attachmentrepository.Add(attachmentData);

                                        //if (_attachmentrepository.Save(attachmentData) &&
                                        //     _servicesRepositoryLog.Save(requestData.ReId, userId))
                                        //{
                                        //    SessionMsg(Helper.Success, Resource.ResourceWeb.AddRequest, Resource.ResourceWeb.AddRequestDone);

                                        //}

                                    }
                                }
                                else
                                {
                                    TempData["Error"] = "لايمكن ان يكون ملف المرفق فارغ";
                                    return View(request);
                                }
                            }
                            SessionMsg(Helper.Success, Resource.ResourceWeb.AddRequest, Resource.ResourceWeb.AddRequestDone);
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----------------------------------------------************************Exp In Post Create Request {ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        /********************************************************/
        /********************************************************/


        //Show all request Data without attachments
        [HttpGet]
        public IActionResult ShowRequests(int Id)
        {
            //List<RequestAttsAttsTypeVM> requestAttVMs = new List<RequestAttVM>();

            var GetAllRequestData = _context.Requests.Where(re => re.ReId == Id && re.IsDeleted == false).ToList();

            var GetAllAttachmentsData = _context.Attachments.Where(at => at.ReId == Id && at.IsDeleted == false).ToList();

            //var GetAllAttachmentsTypeData = _context.Attachments.Where(re => re.ReId == Id && re.IsDeleted == false).ToList();

            var result = new RequestAttsAttsTypeVM
            {
                request = GetAllRequestData,
                attachment = GetAllAttachmentsData
            };


            return View(result);
        }



        /********************************************************/
        /********************************************************/


        //Show Attachments for a specific request
        [HttpGet]
        public IActionResult ShowAttachment(int Id)
        {
            ViewData["ReId"] = Id;
            Request_Id = Id;
            return View();
        }

        /********************************************************/
        /********************************************************/

        //Edit only request Data
        [HttpGet]
        public IActionResult EditRequests(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم طلب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var RequestData = _context.Requests.Find(Id);
                    if (RequestData == null)
                    {
                        TempData["Error"] = "الطلب غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["ReId"] = Id;
                        return View(RequestData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditRequests(Request request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                else
                {
                    var req = _context.Requests.Update(request);
                    if (req.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        SessionMsg(Helper.Success, Resource.ResourceWeb.RequestEdit, Resource.ResourceWeb.RequestEditDon);

                    }
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp In Post Create Request {ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }


        /********************************************************/
        /********************************************************/

        //Edit only Attachment Data
        [HttpGet]
        public IActionResult EditAttachment(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم طلب صحيح";
                    return View();
                }
                else
                {
                    var RequestData = _context.Requests.Find(Id);
                    if (RequestData == null)
                    {
                        TempData["Error"] = "الطلب غير موجودة";
                        return View();
                    }
                    else
                    {
                        ViewData["ReId"] = Id;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditAttachment(RequestAttVM requestAtt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(requestAtt);
                }
                else
                {
                    string[] allowedExtentions = { ".jpg", ".png", ".jpeg", ".pdf", ".docx", ".xlsx", ".csv", ".jfif" };
                    if (requestAtt.AtUrl != null)
                    {
                        if (!allowedExtentions.Contains(Path.GetExtension(requestAtt.AtUrl.FileName).ToLower()))
                        {
                            TempData["Error"] = Path.GetExtension(requestAtt.AtUrl.FileName).ToLower().ToString() + "هذا النوع من الملفات غير مسوح به";
                            return RedirectToAction("EditAttachment");
                        }
                        else
                        {
                            var Stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RequestAtts", Path.GetFileName(requestAtt.AtUrl.FileName)), FileMode.Create);
                            requestAtt.AtUrl.CopyToAsync(Stream);

                            Attachment attachmentData = new Attachment();
                            attachmentData.AtUrl = requestAtt.AtUrl.FileName;
                            attachmentData.ReId = requestAtt.ReId;
                            attachmentData.AttId = requestAtt.AttId;
                            attachmentData.AtId = requestAtt.Id;

                            var req = _context.Attachments.Update(attachmentData);
                            if (req.State == EntityState.Modified)
                            {
                                var rowcount = _context.SaveChanges();
                                TempData["Requests_Created"] = " تم التعديل المرفق بنجاح";
                            }
                            return RedirectToAction("EditAttachment", new { Id = requestAtt.ReId });
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكن ان يكون ملف المرفق فارغ";
                        return RedirectToAction("EditAttachment");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp In Post Create Request {ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("EditAttachment");
            }
        }

        /********************************************************/
        /********************************************************/

        //Add another Attachment when Edit 

        [HttpGet]
        public IActionResult AddAttachment(int Id)
        {
            ViewData["ReId"] = Id;
            Request_Id = Id;
            return View();
        }


        [HttpPost]
        public IActionResult AddAttachment(RequestAttVM requestAtt)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "تأكد من صحة البيانات التي تريد إدخالها";
                    return RedirectToAction("EditAttachment");
                }
                else
                {
                    string[] allowedExtentions = { ".jpg", ".png", ".jpeg", ".pdf", ".docx", ".xlsx", ".csv" };
                    if (requestAtt.AtUrl != null)
                    {
                        if (!allowedExtentions.Contains(Path.GetExtension(requestAtt.AtUrl.FileName).ToLower()))
                        {
                            TempData["Error"] = Path.GetExtension(requestAtt.AtUrl.FileName).ToLower().ToString() + "هذا النوع من الملفات غير مسوح به";
                            return RedirectToAction("EditAttachment");
                        }
                        else
                        {
                            var Stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RequestAtts", Path.GetFileName(requestAtt.AtUrl.FileName)), FileMode.Create);
                            requestAtt.AtUrl.CopyToAsync(Stream);


                            Attachment attachmentData = new Attachment();
                            attachmentData.AtUrl = requestAtt.AtUrl.FileName;
                            attachmentData.ReId = requestAtt.ReId;
                            attachmentData.AttId = requestAtt.AttId;

                            _attachmentrepository.Add(attachmentData);
                            Stream.Close();

                            
                            SessionMsg(Helper.Success, Resource.ResourceWeb.Success, Resource.ResourceWeb.AddNewAttachment);
                            return RedirectToAction("EditAttachment", new { Id = requestAtt.ReId });
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكن ان يكون ملف المرفق فارغ";
                        return RedirectToAction("EditAttachment");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp In Post Create Request {ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }


        /********************************************************/
        /********************************************************/

        //Delete Attachment 
        [HttpGet]
        [Authorize(Permissions.Request.Delete)]

        public IActionResult DeleteRequest(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم طلب صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var request = _context.Requests.Find(id);
                    if (request == null)
                    {
                        TempData["Error"] = "الطلب غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        request.IsDeleted = true;
                        _context.Requests.Update(request);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete attachment Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Requests_Created"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }


        //Delete Attachment 
        [HttpGet]
        public IActionResult DeleteAtt(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم مرفق صحيح ";
                    return RedirectToAction(nameof(EditAttachment));
                }
                else
                {
                    var attachment = _context.Attachments.Find(id);
                    if (attachment == null)
                    {
                        TempData["Error"] = "المرفق غير موجود";
                        return RedirectToAction(nameof(EditAttachment));
                    }
                    else
                    {
                        var ReId = _context.Attachments.Where(at => at.AtId == id && at.IsDeleted == false).Select(x => x.ReId).FirstOrDefault();
                        attachment.IsDeleted = true;
                        _context.Attachments.Update(attachment);
                        _context.SaveChanges();
                        //TempData["success"] = "  تم حذف المرفق بنجاح";
                        return RedirectToAction("EditAttachment", new { id = ReId });
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete attachment Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Requests_Created"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }


        //Referral Request
        [HttpGet]
        public IActionResult ReferralRequest(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم طلب صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var request = _context.Requests.Find(id);
                    if (request == null)
                    {
                        TempData["Error"] = "الطلب غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        if (User.IsInRole(Helper.SuperAdmin))
                        {

                            if (_serviceREpositoryRequest.RefernceToTech(request) && _servicesRepositoryLog.RefernceReTotech(request.ReId, userId))
                            {
                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbrefernce, Resource.ResourceWeb.lbreferenceReDone);
                            }
                            return RedirectToAction("Index");
                        }
                        else if (User.IsInRole(Helper.ReEmployee))
                        {
                            if (_serviceREpositoryRequest.RefernceToAdmin(request) && _servicesRepositoryLog.ReferenceReToAdmin(request.ReId, userId))
                            {
                                SessionMsg(Helper.Success, Resource.ResourceWeb.lbrefernce, Resource.ResourceWeb.lbreferenceReToAdmminDone);


                            }
                            return RedirectToAction("Index");
                        }
                        return RedirectToAction("Index");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Referral Request To General Manager Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        //referral Request To tech
        [HttpGet]
        public IActionResult ReferralRequestToSpecific(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم طلب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var RequestData = _context.Requests.Find(Id);
                    if (RequestData == null)
                    {
                        TempData["Error"] = "الطلب غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["ReId"] = Id;
                        return View(RequestData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult ReferralRequestToSpecific(Request request)
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                if (!ModelState.IsValid)
                {
                    return View(request);
                }
                else
                {
                    //_context.Requests.Attach(request);
                    _context.Entry(request).Property(m => m.RoleId).IsModified = true;
                    _context.Entry(request).Property(m => m.UserId).IsModified = true;


                    _context.SaveChanges();
                    if (_serviceREpositoryRequest.RefernceToTech(request) && _servicesRepositoryLog.RefernceReTotech(request.ReId, userId))
                    {
                        SessionMsg(Helper.Success, Resource.ResourceWeb.lbrefernce, Resource.ResourceWeb.lbreferenceReDone);
                    }
                    return RedirectToAction("index");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp In Post Create Request {ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        //make the request as Read
        [HttpPost]
        public async Task<ActionResult> MarkRejectAndAcceptAsRead(int id)
        {


            var allAcccpetAndReqest = _context.Facilities.Where(x=>x.IsDeleted.Equals(false) && x.IsDeleted.Equals(false) && (x.FaReference.Equals(4)|| x.FaReference.Equals(3)));
            foreach (var n in allAcccpetAndReqest)
            {
                n.IsRead = true;
            }


            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //***************************************************************
        //make the request as Read
        [HttpPost]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Requests.FindAsync(id);
            notification.IsRead = true;
            _context.Entry(notification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //***************************************************************

        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }
    }
}