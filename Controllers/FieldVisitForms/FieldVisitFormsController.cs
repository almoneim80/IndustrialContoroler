using Microsoft.AspNetCore.Identity;
using IndustrialContoroler.IRepository.RepositoryFildform;
using IndustrialContoroler.Constants;
using Microsoft.AspNetCore.Authorization;

namespace IndustrialContoroler.Controllers.EditFacilityData
{
    [Authorize(Permissions.FieldVisitForms.View)]
    public class FieldVisitFormsController : Controller
    {
        private readonly IndustrialContorolerDatabaseContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IServiceRepositoryFieldVisitForms<Facility> _serviceRepositoryFieldVisit;
        private readonly IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms> _repositoryLogFieldVisitForms;
        private readonly IHttpContextAccessor _sesstion;

        public FieldVisitFormsController(IndustrialContorolerDatabaseContext context, 
            IWebHostEnvironment webHostEnvironment,
            UserManager<AppUsers> userManager,
            IServiceRepositoryFieldVisitForms<Facility> serviceRepositoryFieldVisit,
            IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms> repositoryLogFieldVisitForms,
            IHttpContextAccessor sesstion

            )
        {
            this._context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _serviceRepositoryFieldVisit = serviceRepositoryFieldVisit;
            _repositoryLogFieldVisitForms = repositoryLogFieldVisitForms;
            _sesstion = sesstion;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TechReoprt(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم منشأة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var facilityData = _context.Facilities.Find(Id);
                    if (facilityData == null)
                    {
                        TempData["Error"] = "المنشأة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["FaId"] = Id;
                        return View();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In  TechReoprt Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }


        //get buliding Id to delete it
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {


                if (id == 0)
                {
                    TempData[" Error "] = "يجب اختيار رقم منشأة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var facilitys = _context.Facilities.Find(id);
                    if (facilitys == null)
                    {
                        TempData[" Error "] = "المنشأة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        facilitys.IsDeleted = true;
                        _context.Facilities.Update(facilitys);
                        _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete facilitys Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        /*****************************************************************************************************************/
        /************************************************* Facility *****************************************************/


        // get facility Id and show edit page
        public IActionResult EditMainData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم منشأة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var facilityData = _context.Facilities.Find(Id);
                    if (facilityData == null)
                    {
                        TempData["Error"] = "المنشأة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["FaId"] = Id;
                        return View(facilityData);
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

        //post main data and upadte table 
        [HttpPost]
        public IActionResult EditMainData(Facility editFacilityVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(editFacilityVM);
                }
                else
                {
                    Facility facility = new Facility();
                    facility.FaId = editFacilityVM.FaId;
                    facility.ReFormNo = editFacilityVM.ReFormNo;
                    facility.FaName = editFacilityVM.FaName;
                    facility.FaNumber = editFacilityVM.FaNumber;
                    facility.FaSize = editFacilityVM.FaSize;
                    facility.FaActivityType = editFacilityVM.FaActivityType;
                    facility.FaMainActivity = editFacilityVM.FaMainActivity;
                    facility.FaShareCapital = editFacilityVM.FaShareCapital;
                    facility.FaStartProduction = editFacilityVM.FaStartProduction;
                    facility.FaTotalArea = editFacilityVM.FaTotalArea;
                    facility.FaOwnership = editFacilityVM.FaOwnership;
                    facility.FaWorkPeriods = editFacilityVM.FaWorkPeriods;
                    facility.FaLegalEntity = editFacilityVM.FaLegalEntity;
                    facility.FaOwnerName = editFacilityVM.FaOwnerName;
                    facility.FaManagerName = editFacilityVM.FaManagerName;
                    facility.FaMode = editFacilityVM.FaMode;

                    facility.FaWebSite = editFacilityVM.FaWebSite;
                    facility.FaEmail = editFacilityVM.FaEmail;
                    facility.FaFaxNumber = editFacilityVM.FaFaxNumber;
                    facility.FaPhoneNumber = editFacilityVM.FaPhoneNumber;
                    facility.FaMobileNumber = editFacilityVM.FaMobileNumber;
                    facility.FaLongitude = editFacilityVM.FaLongitude;
                    facility.FaLatitude = editFacilityVM.FaLatitude;


                    facility.FaGovernorate = editFacilityVM.FaGovernorate;
                    facility.FaAddress = editFacilityVM.FaAddress;
                    facility.FaRegionName = editFacilityVM.FaRegionName;
                    facility.FaDirectorate = editFacilityVM.FaDirectorate;




                    var req = _context.Facilities.Update(facility);
                    if (req.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم التعديل  بنجاح";
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In edit facility  Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("fieldVisits");
            }
            return View();
        }

        /*****************************************************************************************************************/
        /************************************************* Bulidings *****************************************************/

        //display buildings table of Building
        public IActionResult BuildingsData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم منشأة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
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



        //get building Id and show edit page
        [HttpGet]
        public IActionResult EditBuilding(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم مبنى صحيح";
                    return RedirectToAction("BuildingsData", "FieldVisitForms");
                }
                else
                {
                    var buildingData = _context.Buildings.Find(Id);
                    if (buildingData == null)
                    {
                        TempData["Error"] = "المبنى غير موجودة";
                        return RedirectToAction("BuildingsData", "FieldVisitForms");
                    }
                    else
                    {
                        ViewData["BuId"] = Id;
                        return View(buildingData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("BuildingsData", "FieldVisitForms");
            }
        }

        //post building date and update table 
        [HttpPost]
        public IActionResult EditBuilding(Building building)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(building);
                }
                else
                {
                    var req = _context.Buildings.Update(building);
                    if (req.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل المبنى بنجاح";
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit Action");
                Console.WriteLine($"{ex.Message}");
                TempData["success"] = "خطأ غير متوقع";
                return RedirectToAction("BuildingsData", "FieldVisitForms");
            }
            return View();
        }

        //add new building
        [HttpPost]
        public IActionResult AddBuilding(Building building)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction("BuildingsData", "FieldVisitForms");
                }
                else
                {
                    var req = _context.Buildings.Add(building);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة مبنى جديد بنجاح";
                    return RedirectToAction("BuildingsData", "FieldVisitForms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post add Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("BuildingsData", "FieldVisitForms");
            }
        }

        //get buliding Id to delete it
        [HttpGet]
        public IActionResult DeleteBuilding(int id)
        {
            try
            {


                if (id == 0)
                {
                    TempData[" Error "] = "يجب اختيار رقم مبنى صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var building = _context.Buildings.Find(id);
                    if (building == null)
                    {
                        TempData["Error"] = "المبنى غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        building.IsDeleted = true;
                        _context.Buildings.Update(building);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف المبنى بنجاح";
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete building Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }





        /*****************************************************************************************************************/
        /************************************************* Secondry Act *****************************************************/

        //display Secondry Act table 
        public IActionResult SecondryActData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم نشاط صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get SecondryActData Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        //get Secondry Act Id and show edit page
        [HttpGet]
        public IActionResult EditSecondryAct(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم نشاط صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var SecondryActData = _context.SecondaryActs.Find(Id);
                    if (SecondryActData == null)
                    {
                        TempData["Error"] = "النشاط غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["SeId"] = Id;
                        return View(SecondryActData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit SecondryAct Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Secondry Act date and update table 
        [HttpPost]
        public IActionResult EditSecondryAct(SecondaryAct secondaryAct)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(secondaryAct);
                }
                else
                {
                    var req = _context.SecondaryActs.Update(secondaryAct);
                    if (req.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل النشاط بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit SecondryAct Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Secondry Act
        [HttpPost]
        public IActionResult AddSecondryAct(SecondaryAct secondaryAct)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var req = _context.SecondaryActs.Add(secondaryAct);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة نشاط جديد بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add SecondryAct Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Secondry Act Id to delete it
        [HttpGet]
        public IActionResult DeleteSecondryAct(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم نشاط صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var SecondryAct = _context.SecondaryActs.Find(id);
                    if (SecondryAct == null)
                    {
                        TempData["Error"] = "النشاط غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        SecondryAct.IsDeleted = true;
                        _context.SecondaryActs.Update(SecondryAct);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف النشاط بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete SecondryAct Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }




        /*****************************************************************************************************************/
        /************************************************* site Reason *****************************************************/

        //display site Reason table 
        public IActionResult ReasonData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم سبب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Reason Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        //get site Reason Id and show edit page
        [HttpGet]
        public IActionResult EditReason(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم سبب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var ReasonData = _context.SiteReasons.Find(Id);
                    if (ReasonData == null)
                    {
                        TempData["Error"] = "السبب غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["RaId"] = Id;
                        return View(ReasonData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit site Reason Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post site Reason date and update table 
        [HttpPost]
        public IActionResult EditReason(SiteReason siteReason)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(siteReason);
                }
                else
                {
                    var reason = _context.SiteReasons.Update(siteReason);
                    if (reason.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل السبب بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit Site Reason Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new site Reason
        [HttpPost]
        public IActionResult AddReason(SiteReason siteReason)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var reason = _context.SiteReasons.Add(siteReason);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة سبب جديد بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add Site Reasons Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get site Reason Id to delete it
        [HttpGet]
        public IActionResult DeleteReason(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم سبب صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var reason = _context.SiteReasons.Find(id);
                    if (reason == null)
                    {
                        TempData["Error"] = "السبب غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        reason.IsDeleted = true;
                        _context.SiteReasons.Update(reason);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف السبب بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete Site Reasons Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        /*****************************************************************************************************************/
        /************************************************* Worker *****************************************************/

        //display  Worker table 
        public IActionResult WorkerData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم عمالة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Worker Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Worker Id and show edit page
        [HttpGet]
        public IActionResult EditWorker(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم عمالة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var WorkerData = _context.Workers.Find(Id);
                    if (WorkerData == null)
                    {
                        TempData["Error"] = "العمالة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["WoId"] = Id;
                        return View(WorkerData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Worker Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Worker date and update table 
        [HttpPost]
        public IActionResult EditWorker(Worker worker)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(worker);
                }
                else
                {
                    var workers = _context.Workers.Update(worker);
                    if (workers.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل العمالة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit Worker Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Worker
        [HttpPost]
        public IActionResult AddWorker(Worker worker)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var workers = _context.Workers.Add(worker);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة عمالة جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add Worker Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Worker Id to delete it
        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم عمالة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var workers = _context.Workers.Find(id);
                    if (workers == null)
                    {
                        TempData["Error"] = "العمالة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        workers.IsDeleted = true;
                        _context.Workers.Update(workers);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف العمالة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete workers Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }





        /*****************************************************************************************************************/
        /************************************************* Machine *****************************************************/

        //display  Machine table 
        public IActionResult MachineData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم آالة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Machine Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Machine Id and show edit page
        [HttpGet]
        public IActionResult EditMachine(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم آالة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var MachineData = _context.Machines.Find(Id);
                    if (MachineData == null)
                    {
                        TempData["Error"] = "الآلة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["MaId"] = Id;
                        return View(MachineData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit Machine Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Machine date and update table 
        [HttpPost]
        public IActionResult EditMachine(Machine machine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(machine);
                }
                else
                {
                    var machines = _context.Machines.Update(machine);
                    if (machines.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل الآلة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit machine Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Machine
        [HttpPost]
        public IActionResult AddMachine(Machine machine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var machines = _context.Machines.Add(machine);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة آلة جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add machine Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Machine Id to delete it
        [HttpGet]
        public IActionResult DeleteMachine(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم آلة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var machines = _context.Machines.Find(id);
                    if (machines == null)
                    {
                        TempData["Error"] = "الآلة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        machines.IsDeleted = true;
                        _context.Machines.Update(machines);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف الآلة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete machine Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }






        /*****************************************************************************************************************/
        /************************************************* Row Materials *****************************************************/

        //display  Row Materials table 
        public IActionResult RowMaterialsData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم مادة خام صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get RowMaterials Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Row Materials Id and show edit page
        [HttpGet]
        public IActionResult EditRowMaterials(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم مادة خام صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var rowMaterialData = _context.RowMaterials.Find(Id);
                    if (rowMaterialData == null)
                    {
                        TempData["Error"] = "المادة الخام غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["MaId"] = Id;
                        return View(rowMaterialData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit rowMaterial Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Row Materials date and update table 
        [HttpPost]
        public IActionResult EditRowMaterials(RowMaterial rowMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(rowMaterial);
                }
                else
                {
                    var rowMaterials = _context.RowMaterials.Update(rowMaterial);
                    if (rowMaterials.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل المادة الخام بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit rowMaterials Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Row Materials
        [HttpPost]
        public IActionResult AddRowMaterials(RowMaterial rowMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var rowMaterials = _context.RowMaterials.Add(rowMaterial);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة مادة خام جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add rowMaterial Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Row Materials Id to delete it
        [HttpGet]
        public IActionResult DeleteRowMaterials(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم مادة خام صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var rowMaterials = _context.RowMaterials.Find(id);
                    if (rowMaterials == null)
                    {
                        TempData["Error"] = "المادة الخام غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        rowMaterials.IsDeleted = true;
                        _context.RowMaterials.Update(rowMaterials);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف المادة الخام بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete rowMaterials Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }




        /*****************************************************************************************************************/
        /************************************************* Help Materials *****************************************************/

        //display  Help Materials table 
        public IActionResult HelpMaterialsData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم مادة مساعدة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get HelpMaterials Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Help Materials Id and show edit page
        [HttpGet]
        public IActionResult EditHelpMaterials(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم مادة مساعدة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var helpMaterialData = _context.HelpMaterials.Find(Id);
                    if (helpMaterialData == null)
                    {
                        TempData["Error"] = "المادة المساعدة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["MaId"] = Id;
                        return View(helpMaterialData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit help MaterialData Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Help Materials date and update table 
        [HttpPost]
        public IActionResult EditHelpMaterials(HelpMaterial helpMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(helpMaterial);
                }
                else
                {
                    var helpMaterials = _context.HelpMaterials.Update(helpMaterial);
                    if (helpMaterials.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل المادة المساعدة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit help Material Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Help Materials
        [HttpPost]
        public IActionResult AddHelpMaterials(HelpMaterial helpMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var helpMaterials = _context.HelpMaterials.Add(helpMaterial);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة مادة مساعدة جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add help Material Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Help Materials Id to delete it
        [HttpGet]
        public IActionResult DeleteHelpMaterials(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم مادة مساعدة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var helpMaterials = _context.HelpMaterials.Find(id);
                    if (helpMaterials == null)
                    {
                        TempData["Error"] = "المادة المساعدة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        helpMaterials.IsDeleted = true;
                        _context.HelpMaterials.Update(helpMaterials);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف المادة المساعدة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }   
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete helpMaterial Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }




        /*****************************************************************************************************************/
        /************************************************* Transportation  *****************************************************/

        //display Transportation table 
        public IActionResult TransportationData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم وسيلة نقل  صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Transportation Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post Transportation date and update table 
        [HttpPost]
        public IActionResult EditTransportation(Transportation transportation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(transportation);
                }
                else
                {
                    var transportations = _context.Transportations.Update(transportation);
                    if (transportations.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل وسيلة النقل بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit transportation Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new Transportation
        [HttpPost]
        public IActionResult AddTransportation(Transportation transportation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var transportations = _context.Transportations.Add(transportation);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة مادة مساعدة جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add transportations  Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get Transportation Id to delete it
        [HttpGet]
        public IActionResult DeleteTransportation(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم وسيلة نقل صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var transportations = _context.Transportations.Find(id);
                    if (transportations == null)
                    {
                        TempData["Error"] = "المادة المساعدة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        transportations.IsDeleted = true;
                        _context.Transportations.Update(transportations);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف وسيلة النقل بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete helpMaterial Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        /*****************************************************************************************************************/
        /************************************************* proCapacity  *****************************************************/

        //display proCapacity table 
        public IActionResult proCapacityData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم منتج صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get proCapacity Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post proCapacity date and update table 
        [HttpPost]
        public IActionResult EditproCapacity(ProCapacity proCapacity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(proCapacity);
                }
                else
                {
                    var proCapacitys = _context.ProCapacities.Update(proCapacity);
                    if (proCapacitys.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل المنتج بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit proCapacitys Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new proCapacity
        [HttpPost]
        public IActionResult AddproCapacity(ProCapacity proCapacity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var proCapacitys = _context.ProCapacities.Add(proCapacity);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة منتج جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add proCapacity  Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get proCapacity Id to delete it
        [HttpGet]
        public IActionResult DeleteproCapacity(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم منتج صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var proCapacitys = _context.ProCapacities.Find(id);
                    if (proCapacitys == null)
                    {
                        TempData["Error"] = "المنتج غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        proCapacitys.IsDeleted = true;
                        _context.ProCapacities.Update(proCapacitys);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف  المنتج بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete proCapacitys Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        /*****************************************************************************************************************/
        /************************************************* agentsPoint  *****************************************************/

        //display agentsPoint table 
        public IActionResult agentsPointData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم وكيل/نقطة بيع صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get agentsPoint Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get agentsPoint Id and show edit page
        [HttpGet]
        public IActionResult EditagentsPoint(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم وكيل/نقطة بيع صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var agentsPoints = _context.AgentsPoints.Find(Id);
                    if (agentsPoints == null)
                    {
                        TempData["Error"] = "الوكيل / نقطة البيع غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["ApId"] = Id;
                        return View(agentsPoints);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit agentsPoints Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post agentsPoint date and update table 
        [HttpPost]
        public IActionResult EditagentsPoint(AgentsPoint agentsPoint)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "يرجى إدخال بيانات صحيحة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var agentsPoints = _context.AgentsPoints.Update(agentsPoint);
                    if (agentsPoints.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل الوكيل/نقطة البيع بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit agentsPoints Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new agentsPoint
        [HttpPost]
        public IActionResult AddagentsPoint(AgentsPoint agentsPoint)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var agentsPoints = _context.AgentsPoints.Add(agentsPoint);
                    var rowcount = _context.SaveChanges();
                    TempData["success"] = " تم أضافة وكيل/نقطة بيع جديدة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add agentsPoint  Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get agentsPoint Id to delete it
        [HttpGet]
        public IActionResult DeleteagentsPoint(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم وكيل/نقطة بيع صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var agentsPoints = _context.AgentsPoints.Find(id);
                    if (agentsPoints == null)
                    {
                        TempData["Error"] = "الوكيل/نقطة البيع غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        agentsPoints.IsDeleted = true;
                        _context.AgentsPoints.Update(agentsPoints);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف  الوكيل/نقطة البيع بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete agentsPoints Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }




        /*****************************************************************************************************************/
        /************************************************* SafetySecurity  *****************************************************/

        //display SafetySecurity table 
        public IActionResult EditSafetySecurity(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم صحيح لوسائل الامن والسلامة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get SafetySecurity Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult EditSafetySecurity(SafetySecurity safetySecurity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(safetySecurity);
                }
                else
                {
                    var safetySecuritys = _context.SafetySecurities.Update(safetySecurity);
                    if (safetySecuritys.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم التعديل  بنجاح";
                        return RedirectToAction("index");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In edit safetySecuritys  Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        /*****************************************************************************************************************/
        /************************************************* relevantDoc  *****************************************************/

        //display relevantDoc table 
        public IActionResult RelevantDocData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم وثيقة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get RelevantDoc Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get relevantDoc Id and show edit page
        [HttpGet]
        public IActionResult EditRelevantDoc(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم وثيقة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var RelevantDocs = _context.RelevantDocs.Find(Id);
                    if (RelevantDocs == null)
                    {
                        TempData["Error"] = "الوثيقة غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        var fileName = _context.RelevantDocs.Where(rd => rd.RdId == Id && rd.IsDeleted == false).Select(rd => rd.ReUrl).FirstOrDefault();
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsFiles", fileName);
                        var RelevantDocsData = _context.RelevantDocs.Where(RelevantDocs => RelevantDocs.RdId == Id && RelevantDocs.IsDeleted == false).ToList();

                        ViewData["filePath"] = filePath;
                        ViewData["RDId"] = Id;

                        RelevantDocVM relevantDocVM = new RelevantDocVM();
                        foreach (var item in RelevantDocsData)
                        {
                            relevantDocVM.RdDocName = RelevantDocs.RdDocName;
                            relevantDocVM.RdStakeholderName = RelevantDocs.RdStakeholderName;
                            relevantDocVM.ReDescription = RelevantDocs.ReDescription;
                            relevantDocVM.RdId = RelevantDocs.RdId;
                            relevantDocVM.FaId = RelevantDocs.FaId;
                            ViewData["fileName"] = RelevantDocs.ReUrl;
                        }
                        return View(relevantDocVM);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit RelevantDoc Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //post relevantDoc date and update table 
        [HttpPost]
        public IActionResult EditRelevantDoc(RelevantDocVM relevantDocVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "يرجى إدخال بيانات صحيحة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (relevantDocVM.ReFile.ContentType.StartsWith("image/") ||
                               relevantDocVM.ReFile.ContentType == "application/pdf" ||
                               relevantDocVM.ReFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" ||
                               relevantDocVM.ReFile.ContentType == "application/msword" ||
                                relevantDocVM.ReFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" ||
                                 relevantDocVM.ReFile.ContentType == "application/vnd.ms-excel" ||
                               relevantDocVM.ReFile.ContentType == "image/tiff"
                               )
                    {
                        string FileName = relevantDocVM.ReFile.FileName;
                        FileName = Path.GetFileName(FileName);
                        string UploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadsFiles", FileName);
                        var Stream = new FileStream(UploadFilePath, FileMode.Create);
                        relevantDocVM.ReFile.CopyToAsync(Stream);




                        RelevantDoc relevantDoc = new RelevantDoc();
                        relevantDoc.RdDocName = relevantDocVM.RdDocName;
                        relevantDoc.RdStakeholderName = relevantDocVM.RdStakeholderName;
                        relevantDoc.ReDescription = relevantDocVM.ReDescription;
                        relevantDoc.ReUrl = relevantDocVM.ReFile.FileName;
                        relevantDoc.FaId = relevantDocVM.FaId;

                        var relevantDocs = _context.RelevantDocs.Update(relevantDoc);
                        if (relevantDocs.State == EntityState.Modified)
                        {
                            var rowcount = _context.SaveChanges();
                            TempData["success"] = " تم تعديل الوثيقة بنجاح";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكن إدراج ملفات من هذا النوع";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit relevantDocs Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //add new relevantDoc
        [HttpPost]
        public IActionResult AddRelevantDoc(RelevantDocVM relevantDocVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "هناك خطأ في البيانات .. الرجاء التأكد من صحة البيانات";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (relevantDocVM.ReFile.ContentType.StartsWith("image/") ||
                               relevantDocVM.ReFile.ContentType == "application/pdf" ||
                               relevantDocVM.ReFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" ||
                               relevantDocVM.ReFile.ContentType == "application/msword" ||
                                relevantDocVM.ReFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" ||
                                 relevantDocVM.ReFile.ContentType == "application/vnd.ms-excel" ||
                               relevantDocVM.ReFile.ContentType == "image/tiff"
                               )
                    {
                        string FileName = relevantDocVM.ReFile.FileName;
                        FileName = Path.GetFileName(FileName);
                        string UploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadsFiles", FileName);
                        var Stream = new FileStream(UploadFilePath, FileMode.Create);
                        relevantDocVM.ReFile.CopyToAsync(Stream);




                        RelevantDoc relevantDoc = new RelevantDoc();
                        relevantDoc.RdDocName = relevantDocVM.RdDocName;
                        relevantDoc.RdStakeholderName = relevantDocVM.RdStakeholderName;
                        relevantDoc.ReDescription = relevantDocVM.ReDescription;
                        relevantDoc.ReUrl = relevantDocVM.ReFile.FileName;
                        relevantDoc.FaId = relevantDocVM.FaId;


                        var sqlCommand = _context.RelevantDocs.Add(relevantDoc);
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم أضافة وكيل/نقطة بيع جديدة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "لايمكن إدراج ملفات من هذا النوع";
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Add relevantDoc  Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        //get relevantDoc Id to delete it
        [HttpGet]
        public IActionResult DeleteRelevantDoc(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار وثيقة صحيح ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var relevantDocs = _context.RelevantDocs.Find(id);
                    if (relevantDocs == null)
                    {
                        TempData["Error"] = "الوكيل/نقطة البيع غير موجود";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        relevantDocs.IsDeleted = true;
                        _context.RelevantDocs.Update(relevantDocs);
                        _context.SaveChanges();
                        TempData["success"] = "  تم حذف  الوثيقة بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Delete relevantDocs Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }




        /*****************************************************************************************************************/
        /************************************************* castData  *****************************************************/

        // get castData Id and show edit page
        public IActionResult EditcastData(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم منشأة صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["FaId"] = Id;
                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit castDatas Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        //post castData date and update table 
        [HttpPost]
        public IActionResult EditcastData(CastDatum castDatum)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "يرجى إدخال بيانات صحيحة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var castDatums = _context.CastData.Update(castDatum);
                    if (castDatums.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل بيانات المدلي بنجاح";
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit castDatums Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        /*****************************************************************************************************************/
        /************************************************* visitsTraffic  *****************************************************/

        // get visitsTraffic Id and show edit page
        public IActionResult EditvisitsTraffic(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم عنصر صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var visitsTraffics = _context.VisitsTraffics.Find(Id);
                    if (visitsTraffics == null)
                    {
                        TempData["Error"] = "العنصر غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["FaId"] = Id;
                        return View(visitsTraffics);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit castDatas Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        //post visitsTraffic date and update table 
        [HttpPost]
        public IActionResult EditvisitsTraffic(VisitsTraffic visitsTraffic)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "يرجى إدخال بيانات صحيحة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var visitsTraffics = _context.VisitsTraffics.Update(visitsTraffic);
                    if (visitsTraffics.State == EntityState.Modified)
                    {
                        var rowcount = _context.SaveChanges();
                        TempData["success"] = " تم تعديل البيانات بنجاح";
                        return RedirectToAction(nameof(Index));
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Edit visitsTraffics Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }








        //---------------------Referral---------------------------

        //Referral FormsVisit To General Manager from technical spcialist
        [HttpGet]
        public IActionResult ReferralVisitFormToGeneralManager(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم استمارة زيارة صحيح ";
                    return RedirectToAction("Index", "FieldVisitForms");
                }
                else
                {
                    var VisitForm = _context.Facilities.Find(id);
                    if (VisitForm == null)
                    {
                        
                        TempData["Error"] = "استمارة الزيارة غير موجودة";
                        return RedirectToAction("Index", "FieldVisitForms");
                    }
                    else
                    {
                        if (_serviceRepositoryFieldVisit.RefernceToAdmin(VisitForm) && _repositoryLogFieldVisitForms.RefernceToAdmin(VisitForm.FaId, userId))
                            SessionMsg(Helper.Success, Resource.ResourceWeb.lbrefernce, Resource.ResourceWeb.lbreferenceFieldtoGeneDone);

                       
                        return RedirectToAction("Index", "FieldVisitForms");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Referral VisitForm To General Manager Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index", "FieldVisitForms");
            }
        }

        //accept VisitForm by General Manager
        //[HttpGet]
        public IActionResult AcceptVisitForm(int id)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                if (id == 0)
                {
                    TempData["Error"] = "يجب اختيار رقم استمارة زيارة صحيح ";
                    return RedirectToAction("Index", "FieldVisitForms");
                }
                else
                {
                    var VisitForm = _context.Facilities.Find(id);
                    if (VisitForm == null)
                    {
                        TempData["Error"] = "استمارة الزيارة غير موجودة";
                        return RedirectToAction("Index", "FieldVisitForms");
                    }
                    else
                    {
                        if (_serviceRepositoryFieldVisit.AcceptFieldVisit(VisitForm) && _repositoryLogFieldVisitForms.AcceptFieldVisit(VisitForm.FaId, userId))
                            SessionMsg(Helper.Success, Resource.ResourceWeb.accept, Resource.ResourceWeb.lbacceptDone);

                        return RedirectToAction("Index", "FieldVisitForms");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Referral VisitForm To General Manager Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index", "FieldVisitForms");
            }
        }

         
        [HttpGet]
        public IActionResult RejectVisitForm(int id)
        {
         
        
            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم عنصر صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var facilityID = _context.Facilities.Find(id);
                    if (facilityID == null)
                    {
                        TempData["Error"] = "العنصر غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["FaId"] = id;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit castDatas Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        //accept VisitForm by General Manager
            [HttpPost]
        public async Task<IActionResult> RejectVisitFormAsync([FromForm][Bind("Title,Description,RoleId,ToUserId")] NotificationVM model, [FromForm] int FaId)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                var userId = _userManager.GetUserId(User);
                //Console.WriteLine($"----------EditMsg : {EditMsg}");
                //Console.WriteLine($"----------FaId : {FaId}");

                var VisitForm = _context.Facilities.Find(FaId);
                if (VisitForm == null)
                {
                    TempData["Error"] = "استمارة الزيارة غير موجودة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var notification = new Noti
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Date = DateTime.Now,
                        Sender = user.FullName,
                        Receiver = model.ToUserId,
                        ImageSender = user.ImageUser,
                        FaId = FaId,
                        IsRead = false,
                        IsDeleted = false
                    };
            
                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                    if (_serviceRepositoryFieldVisit.RejectFieldVisit(VisitForm) && _repositoryLogFieldVisitForms.RejectfieldVisit(VisitForm.FaId, userId))
                        SessionMsg(Helper.Success, Resource.ResourceWeb.rejectRequest, Resource.ResourceWeb.rejectRequestDon);

                        return RedirectToAction("Index", "FieldVisitForms");
                    
                }
                }
            
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In Referral VisitForm To General Manager Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index", "FieldVisitForms");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //accept VisitForm by General Manager
        public IActionResult EditFromByTechnicalSpecialist(int id)
        {


            try
            {
                if (id == 0)
                {
                    TempData["Error"] = "يجب إدخال رقم عنصر صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var facilityID = _context.Facilities.Find(id);
                    if (facilityID == null)
                    {
                        TempData["Error"] = "العنصر غير موجودة";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["FaId"] = id;
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Edit castDatas Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditFromByTechnicalSpecialistAsync([FromForm][Bind("Title,Description,RoleId,ToUserId")] NotificationVM model, [FromForm] int FaId)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                var userId = _userManager.GetUserId(User);
                //Console.WriteLine($"----------EditMsg : {EditMsg}");
                //Console.WriteLine($"----------FaId : {FaId}");

                var VisitForm = _context.Facilities.Find(FaId);
                if (VisitForm == null)
                {
                    TempData["Error"] = "استمارة الزيارة غير موجودة";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var notification = new Noti
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Date = DateTime.Now,
                        Sender = user.FullName,
                        Receiver = model.ToUserId,
                        ImageSender = user.ImageUser,
                        FaId = FaId,
                        IsRead = false,
                        IsDeleted = false
                    };
                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                    if (_serviceRepositoryFieldVisit.RefernceToTechToEdit(VisitForm) && _repositoryLogFieldVisitForms.RefernceTotechToEdit(VisitForm.FaId, userId))
                        SessionMsg(Helper.Success, Resource.ResourceWeb.lbrefernce, Resource.ResourceWeb.lbreferenceDone);
                    return RedirectToAction("Index", "FieldVisitForms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"====Exp In EditFromByTechnicalSpecialist Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index", "FieldVisitForms");
            }
        }


       
        //make the Filed as Read
        [HttpPost]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Facilities.FindAsync(id);
            notification.IsRead = true;
            _context.Entry(notification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //***************************************************************

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