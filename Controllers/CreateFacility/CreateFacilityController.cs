using System.Data;
using OfficeOpenXml;
using System.Data.OleDb;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using IndustrialContoroler.Constants;

namespace IndustrialContoroler.Controllers.InsertFacilityData
{
    [Authorize(Permissions.CreateFacility.View)]
    public class CreateFacilityController : Controller
    {
        int FaID;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IndustrialContorolerDatabaseContext _context;
        private readonly IRepository<Temporary> _repository;
        private readonly IRepository<Facility> _repositoryFa;
        private readonly IRepository<Building> _repositoryBu;
        private readonly IConfiguration configuration;
        private readonly IRepository<Worker> _repositoryW;
        private readonly IRepository<Worker> _repositoryWo;
        private readonly IRepository<Machine> _repositoryMa;
        private readonly IRepository<RowMaterial> _repositoryRM;
        private readonly IRepository<HelpMaterial> _repositoryHM;
        private readonly IRepository<Transportation> _repositoryTr;
        private readonly IRepository<AgentsPoint> _repositoryAP;
        private readonly IRepository<ProCapacity> _repositoryPC;
        private readonly IRepository<SafetySecurity> _repositorySS;
        private readonly IRepository<RelevantDoc> _repositoryRD;
        private readonly IRepository<CastDatum> _repositoryCD;
        private readonly IRepository<VisitsTraffic> _repositoryVT;
        private readonly IRepository<SecondaryAct> _repositorySA;
        private readonly IRepository<SiteReason> _repositorySR;

        private readonly IHttpContextAccessor _sesstion;

        public CreateFacilityController(
            IHttpContextAccessor contextAccessor,
            IRepository<Temporary> repository,
            IRepository<Facility> repositoryFa,
            IRepository<Worker> repositoryW,
            IRepository<Worker> repositoryWo,
            IndustrialContorolerDatabaseContext context,
            IRepository<Machine> repositoryMa,
            IRepository<RowMaterial> repositoryRM,
            IRepository<HelpMaterial> repositoryHM,
            IRepository<Transportation> repositoryTr,
            IRepository<AgentsPoint> repositoryAP,
            IRepository<ProCapacity> repositoryPC,
            IRepository<SafetySecurity> repositorySS,
            IRepository<RelevantDoc> repositoryRD,
            IRepository<CastDatum> repositoryCD,
            IRepository<VisitsTraffic> repositoryVT,
            IRepository<SecondaryAct> repositorySA,
            IRepository<SiteReason> repositorySR,
            IRepository<Building> repositoryBu,
            IConfiguration configuration,
            IHttpContextAccessor sesstion)
        {
            _contextAccessor = contextAccessor;
            _repository = repository;
            _context = context;
            _repositoryFa = repositoryFa;
            _repositoryW = repositoryW;
            _repositoryWo = repositoryWo;
            _repositoryMa = repositoryMa;
            _repositoryRM = repositoryRM;
            _repositoryHM = repositoryHM;
            _repositoryTr = repositoryTr;
            _repositoryAP = repositoryAP;
            _repositoryPC = repositoryPC;
            _repositorySS = repositorySS;
            _repositoryRD = repositoryRD;
            _repositoryCD = repositoryCD;
            _repositoryVT = repositoryVT;
            _repositorySA = repositorySA;
            _repositorySR = repositorySR;
            _repositoryBu = repositoryBu;
            this.configuration = configuration;
            _sesstion = sesstion;
        }

        //----------------------Facility Main Data 
        [HttpGet]
        public IActionResult FacilityMainData()
        {
            Console.WriteLine($"Enter in Get FacilityMainData");
            Facility facility = new Facility();
            facility.Reasons.Add(new SiteReason() { });
            facility.secondaryActs.Add(new SecondaryAct() { });


            string ERRMSG = TempData["ExFileNull"] as string;
            if (!string.IsNullOrEmpty(ERRMSG))
            {
                TempData["ExFileErr"] = ERRMSG;
            }
            var GetInsertedFaCount = _repository.GetAll().Where(fa => fa.TblDesc == "facility").ToList();
            string faNama = null;
            if (GetInsertedFaCount.Count != 0)
            {
                foreach (var item in GetInsertedFaCount) { faNama = item.Cel2.ToString(); }
                TempData["Warning"] = "  يوجد بيانات مخزنة مسبقاً تخص المنشأة التي تحمل الأسم" +" (  "+ faNama +"  )"+ "هل تريد تهيئة البيانات المؤقتة والبدء من جديد ؟";
            }
            return View(facility);
        }

        [HttpPost]
        public IActionResult FacilityMainData(Facility facility)
        {
            try
            {
                var GetInsertedFaCount = _repository.GetAll().Where(fa => fa.TblDesc == "facility").ToList();
                if (GetInsertedFaCount.Count != 0)
                {
                    TempData["Error"] = "هناك بيانات رئيسية قمت بإدخالها مسبقاً";
                    return View(facility);
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        if (facility.FaMobileNumber == null)
                        {
                            TempData["FaMobileNumberError"] = "يرجى إدخال رقم هاتف المنشأة";
                            return View(facility);
                        }
                        else
                        {
                            foreach (var item in facility.Reasons)
                            {
                                if (item.SrReason == null)
                                {
                                    TempData["ReasonNull"] = "يرجى إدخال أسباب أختيار موقع المنشأة";
                                }
                            }
                            foreach (var item in facility.secondaryActs)
                            {
                                if (item.SaName == null)
                                {
                                    TempData["ActNull"] = "يرجى إدخال النشاط الثانوي للمنشأة";
                                }
                            }
                            Console.WriteLine($"Enter in !ModelState.IsValid");
                            return View(facility);
                        }
                    }
                    else
                    {
                        var FacilityName = _context.Facilities.Where(fa => fa.FaName == facility.FaName).Select(x => x.FaName).FirstOrDefault();
                        var FacilityNumber = _context.Facilities.Where(fa => fa.FaNumber == facility.FaNumber).Select(x => x.FaNumber).FirstOrDefault();
                        if (FacilityName == null)
                        {
                            if (FacilityNumber == null)
                            {
                                if (facility.FaStartProduction > DateTime.Now)
                                {
                                    TempData["FaStartProductionError"] = "لايمكن إدخال تاريخ أكبر من تاريخ اليوم" + DateTime.Now.ToString();
                                    return View(facility);
                                }
                                else
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = facility.ReFormNo.ToString();
                                    temporary.Cel2 = facility.FaName;
                                    temporary.Cel3 = facility.FaNumber.ToString();
                                    temporary.Cel4 = facility.FaSize;
                                    temporary.Cel5 = facility.FaActivityType;
                                    temporary.Cel6 = facility.FaMainActivity;
                                    temporary.Cel7 = facility.FaShareCapital;
                                    temporary.Cel8 = facility.FaStartProduction.ToString();
                                    temporary.Cel9 = facility.FaTotalArea.ToString();
                                    temporary.Cel10 = facility.FaOwnership;
                                    temporary.Cel11 = facility.FaWorkPeriods.ToString();
                                    temporary.Cel12 = facility.FaLegalEntity;
                                    temporary.Cel13 = facility.FaOwnerName;
                                    temporary.Cel14 = facility.FaManagerName;
                                    temporary.Cel15 = facility.FaMode;

                                    temporary.Cel16 = facility.FaWebSite;
                                    temporary.Cel17 = facility.FaEmail;
                                    temporary.Cel18 = facility.FaFaxNumber;
                                    temporary.Cel19 = facility.FaPhoneNumber;
                                    temporary.Cel20 = facility.FaMobileNumber;


                                    temporary.Cel21 = facility.FaGovernorate;
                                    temporary.Cel22 = facility.FaDirectorate;
                                    temporary.Cel23 = facility.FaAddress;
                                    temporary.Cel24 = facility.FaRegionName;
                                    temporary.Cel25 = facility.FaLongitude.ToString();
                                    temporary.Cel26 = facility.FaLatitude.ToString();
                                    temporary.TblDesc = "facility";


                                    var inserttemporaryFa = _repository.Add(temporary);

                                    foreach (var item in facility.Reasons)
                                    {
                                        Temporary temporaryRe = new Temporary();
                                        temporaryRe.Cel1 = item.SrReason;
                                        temporaryRe.TblDesc = "reason";
                                        var inserttemporaryRe = _repository.Add(temporaryRe);
                                        Console.WriteLine($"-------Res--------------{item.SrReason}");
                                    }

                                    foreach (var item in facility.secondaryActs)
                                    {
                                        Temporary temporarySA = new Temporary();
                                        temporarySA.Cel1 = item.SaName;
                                        temporarySA.TblDesc = "secondary";
                                        var inserttemporarySA = _repository.Add(temporarySA);
                                        Console.WriteLine($"---------Act------------{item.SaName}");
                                    }

                                    Console.WriteLine($"insert temporary facility done");
                                    return RedirectToAction("BuildingsData", "CreateFacility");
                                }
                            }
                            else

                            {
                                TempData["Error"] = "يبدو أنك تحاول إدخال رقم منشأة موجود مسبقاً";
                                return View(facility);
                            }
                        }
                        else
                        {
                            TempData["Error"] = "يبدو أنك تحاول إدخال أسم منشأة موجود مسبقاً";
                            return View(facility);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post Facility Main Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult FacilityMainNext()
        {
            var GetInsertedFaCount = _repository.GetAll().Where(fa => fa.TblDesc == "facility").ToList();
            if (GetInsertedFaCount.Count != 0)
            {
                return RedirectToAction("BuildingsData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات المباني قبل إدخال البيانات الرئيسية للمنشأة";
                return RedirectToAction("FacilityMainData", "CreateFacility");
            }
        }

        [HttpGet]
        public IActionResult RemoveTempTable()
        {
            try
            {
                _context.Temporaries.RemoveRange(_context.Temporaries);
                _context.SaveChanges();
                return RedirectToAction("FacilityMainData","CreateFacility");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exp: In Get RemoveTempTable  Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }



        //----------------------Buildings Data
        [HttpGet]
        public IActionResult BuildingsData()
        {
            Console.WriteLine($"Enter in Get Buildings Data");
            return View();
        }

        //----------------------Multi Buildings Data
        [HttpPost]
        public IActionResult BuildingsData(Building building)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(building);
                }
                else
                {
                    var facilityData = _repository.GetAll().Where(fa => fa.TblDesc == "facility").ToList();
                    if (facilityData.Count != 0)
                    {
                        if (building.BuOwnership == null)
                        {
                            TempData["BuOwnershipError"] = "يرجى تحديد ملكية المبنى";
                            return View(building);
                        }
                        else if (building.BuDescription == null)
                        {
                            TempData["BuDescriptionError"] = "يرجى إدخال وصف المبنى";
                            return View(building);
                        }
                        else if (building.BuLocation == null)
                        {
                            TempData["BuLocationError"] = "يرجى إدخال موقع المبنى";
                            return View(building);
                        }
                        else if (building.BuType == null)
                        {
                            TempData["BuTypeError"] = "يرجى إدخال نوعية البناء";
                            return View(building);
                        }
                        else if (building.BuLength == null)
                        {
                            TempData["BuLengthError"] = "يرجى إدخال طول المبنى";
                            return View(building);
                        }
                        else if (building.BuWidth == null)
                        {
                            TempData["BuWidthError"] = "يرجى إدخال عرض المبنى";
                            return View(building);
                        }
                        else if (building.BuHigh == null)
                        {
                            TempData["BuHighError"] = "يرجى إدخال ارتفاع المبنى";
                            return View(building);
                        }
                        else if (building.BuArea == null)
                        {
                            TempData["BuAreaError"] = "يرجى إدخال مساحة المبنى";
                            return View(building);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = building.BuOwnership;
                            temporary.Cel2 = building.BuDescription;
                            temporary.Cel3 = building.BuLocation;
                            temporary.Cel4 = building.BuType;
                            temporary.Cel5 = building.BuLength.ToString();
                            temporary.Cel6 = building.BuWidth.ToString();
                            temporary.Cel7 = building.BuHigh.ToString();
                            temporary.Cel8 = building.BuArea;
                            if (building.BuNotes == null)
                            {
                                temporary.Cel9 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel9 = building.BuNotes;
                            }
                            temporary.Cel10 = building.FaId.ToString();
                            temporary.TblDesc = "building";


                            var inserttemporaryBu = _repository.Add(temporary);
                            ModelState.Clear();
                            Console.WriteLine($"insert temporary building done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانات المباني قبل إدخال البيانات الرئسية للمنشأة";
                        return View();
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi building Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        //----------------------if click next button
        [HttpPost]
        public IActionResult BuildingsNext()
        {
            var GetInsertedBuCount = _repository.GetAll().Where(Bu => Bu.TblDesc == "building").ToList();
            if (GetInsertedBuCount.Count != 0)
            {
                return RedirectToAction("WorkersData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات العمالة قبل إدخال بيانات المباني";
                return RedirectToAction("BuildingsData", "CreateFacility");
            }
        }

        //----------------------delete temp building
        public IActionResult DeleteBuildings(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم المبنى غير صحيح";
                    return RedirectToAction(nameof(BuildingsData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("BuildingsData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete building Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileBU(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("BuildingsData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                    if (tableName == "Building.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.Cel7 = worksheet.Cells[row, 7].Value.ToString().Trim();
                                    temporary.Cel8 = worksheet.Cells[row, 8].Value.ToString().Trim();
                                    temporary.Cel9 = worksheet.Cells[row, 9].Value.ToString().Trim();
                                    temporary.TblDesc = "building";
                                    _repository.Add(temporary);
                                }
                            }
                        }
                        tableName = null;
                        return RedirectToAction("BuildingsData", "CreateFacility");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }







        //----------------------Workers Data
        [HttpGet]
        public IActionResult WorkersData()
        {
            Console.WriteLine($"Enter in Get Workers Data");
            return View();
        }

        //----------------------Multi Workers Data
        [HttpPost]
        public IActionResult WorkersData(Worker worker)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(worker);
                }
                else
                {
                    var BulidingData = _repository.GetAll().Where(bu => bu.TblDesc == "building").ToList();
                    if (BulidingData.Count != 0)
                    {
                        if (worker.WoType == null)
                        {
                            TempData["WoTypeError"] = "يرجى إدخال نوعية العمالة";
                            return View(worker);
                        }
                        else if (worker.WoTotal == null)
                        {
                            TempData["WoTotalError"] = "يرجى إدخال إجمالي عدد العمالة";
                            return View(worker);
                        }
                        else if (worker.WoMaleNumber == null)
                        {
                            TempData["WoMaleNumberError"] = "يرجى إدخال عدد العمال الذكور";
                            return View(worker);
                        }
                        else if (worker.WoFemaleNumber == null)
                        {
                            TempData["WoFemaleNumberError"] = "يرجى إدخال عدد العمال الإناث";
                            return View(worker);
                        }
                        else if (worker.WoEduQualifying == null)
                        {
                            TempData["WoEduQualifyingError"] = "يرجى إدخال المؤهل التعليمي للعمالة";
                            return View(worker);
                        }
                        else if (worker.WoSpecialization == null)
                        {
                            TempData["WoSpecializationError"] = "يرجى إدخال تخصص العمالة";
                            return View(worker);
                        }
                        else if (worker.WoNationality == null)
                        {
                            TempData["WoNationalityError"] = "يرجى إدخال جنسية العمالة";
                            return View(worker);
                        }
                        else if(worker.WoTotal != (worker.WoFemaleNumber + worker.WoMaleNumber))
                        {
                            TempData["WoTotalError"] = "يجب أن يكون إجمالي العمالة مساوي لعدد العمال الذكور مع عدد العمال الإناث";
                            return View(worker);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = worker.WoType;
                            temporary.Cel2 = worker.WoNationality;
                            temporary.Cel3 = worker.WoTotal.ToString();
                            temporary.Cel4 = worker.WoMaleNumber.ToString();
                            temporary.Cel5 = worker.WoFemaleNumber.ToString();
                            temporary.Cel6 = worker.WoEduQualifying;
                            temporary.Cel7 = worker.WoSpecialization;
                            if (worker.WoNotes == null)
                            {
                                temporary.Cel8 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel8 = worker.WoNotes;
                            }
                            temporary.Cel10 = worker.FaId.ToString();
                            temporary.TblDesc = "worker";


                            var inserttemporaryWo = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary worker done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانت العمالة قبل إدخال بيانات المباني";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi building Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult WorkersNext()
        {

            var GetInsertedWoCount = _repository.GetAll().Where(Wo => Wo.TblDesc == "worker").ToList();
            if (GetInsertedWoCount.Count != 0)
            {
                return RedirectToAction("MachinesData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات المعدات قبل إدخال بيانات العمالة";
                return RedirectToAction("WorkersData", "CreateFacility");
            }
        }


        //----------------------delete temp building
        public IActionResult DeleteWorkers(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم العمالة غير صحيح";
                    return RedirectToAction(nameof(WorkersData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("WorkersData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete Workers Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileWO(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("WorkersData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                    if (tableName == "Worker.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {

                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.Cel7 = worksheet.Cells[row, 7].Value.ToString().Trim();
                                    temporary.Cel8 = worksheet.Cells[row, 8].Value.ToString().Trim();
                                    temporary.TblDesc = "worker";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("WorkersData", "CreateFacility");

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }




        //----------------------Machine Data
        [HttpGet]
        public IActionResult MachinesData()
        {
            Console.WriteLine($"Enter in Get Machines Data");
            return View();
        }

        //----------------------Multi Machines Data
        [HttpPost]
        public IActionResult MachinesData(Machine machine)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(machine);
                }
                else
                {
                    if (machine.MaName == null)
                    {
                        TempData["MaNameError"] = "يرجى إدخال اسم الآلة";
                        return View(machine);
                    }
                    else if (machine.MaNumber == null)
                    {
                        TempData["MaNumberError"] = "يرجى إدخال العدد";
                        return View(machine);
                    }
                    else if (machine.MaCountryManufacture == null)
                    {
                        TempData["MaCountryManufactureError"] = "يرجى إدخال بلد الصنع";
                        return View(machine);
                    }
                    else if (machine.MaMeasruingUnit == null)
                    {
                        TempData["MaMeasruingUnitError"] = "يرجى إدخال وحدة القياس";
                        return View(machine);
                    }
                    else if (machine.MaAbility == null)
                    {
                        TempData["MaAbilityError"] = "يرجى إدخال قدرة الآلة";
                        return View(machine);
                    }
                    else if (machine.MaSource == null)
                    {
                        TempData["MaSourceError"] = "يرجى إدخال مصدر الآلة";
                        return View(machine);
                    }
                    else if (machine.MaSourceAddress == null)
                    {
                        TempData["MaSourceAddressError"] = "يرجى إدخال عنوان مصدر الآلة";
                        return View(machine);
                    }
                    else if (machine.MaUses == null)
                    {
                        TempData["MaUsesError"] = "يرجى إدخال استخدامات الآلة";
                        return View(machine);
                    }
                    else
                    {
                        var WorkersData = _repository.GetAll().Where(wo => wo.TblDesc == "worker").ToList();
                        if (WorkersData.Count != 0)
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = machine.MaName;
                            temporary.Cel2 = machine.MaNumber.ToString();
                            temporary.Cel3 = machine.MaUses;
                            temporary.Cel4 = machine.MaCountryManufacture;
                            temporary.Cel5 = machine.MaMeasruingUnit;
                            temporary.Cel6 = machine.MaAbility;
                            temporary.Cel7 = machine.MaSource;
                            temporary.Cel8 = machine.MaSourceAddress;
                            if (machine.MaNotes == null)
                            {
                                temporary.Cel9 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel9 = machine.MaNotes;
                            }
                            temporary.Cel10 = machine.FaId.ToString();
                            temporary.TblDesc = "machine";


                            var inserttemporaryMa = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary machine done");
                            return View();
                        }
                        else
                        {
                            TempData["Error"] = "لايمكنك إدخال بيانات الآلات قبل إدخال بيانات العمالة";
                            return View();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi machine Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult machinesNext()
        {

            var GetInsertedMaCount = _repository.GetAll().Where(Ma => Ma.TblDesc == "machine").ToList();
            if (GetInsertedMaCount.Count != 0)
            {
                return RedirectToAction("RowMaterialData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات المواد الخام قبل إدخال بيانات الآلات والمعدات";
                return RedirectToAction("MachinesData", "CreateFacility");
            }
        }


        //----------------------delete temp Machine
        public IActionResult Deletemachines(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم المعدات غير صحيح";
                    return RedirectToAction(nameof(WorkersData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("MachinesData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete machine Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileMA(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("MachinesData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                     if (tableName == "Machine.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.Cel7 = worksheet.Cells[row, 7].Value.ToString().Trim();
                                    temporary.Cel8 = worksheet.Cells[row, 8].Value.ToString().Trim();
                                    temporary.Cel9 = worksheet.Cells[row, 9].Value.ToString().Trim();
                                    temporary.TblDesc = "machine";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("MachinesData", "CreateFacility");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }







        //----------------------Row material Data
        [HttpGet]
        public IActionResult RowMaterialData()
        {
            Console.WriteLine($"Enter in Get Row material Data");
            return View();
        }

        //----------------------Multi row Material Data
        [HttpPost]
        public IActionResult RowMaterialData(RowMaterial rowMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(rowMaterial);
                }
                else
                {
                    var MachinesData = _repository.GetAll().Where(Ma => Ma.TblDesc == "machine").ToList();
                    if (MachinesData.Count != 0)
                    {
                        if (rowMaterial.RmName == null)
                        {
                            TempData["RmNameError"] = "يرجى إدخال اسم المادة الخام";
                            return View(rowMaterial);
                        }
                        else if (rowMaterial.RmMeasruingUnit == null)
                        {
                            TempData["RmMeasruingUnitError"] = "يرجى إدخال وحدة القياس";
                            return View(rowMaterial);
                        }
                        else if (rowMaterial.RmPercentInPro == 0)
                        {
                            TempData["RmPercentInProError"] = "يرجى إدخال النسبة المئوية في المنتج";
                            return View(rowMaterial);
                        }
                        else if (rowMaterial.RmAmountUsed == null)
                        {
                            TempData["MaUsesError"] = "يرجى إدخال الكمية المستخدمة";
                            return View(rowMaterial);
                        }
                        else if (rowMaterial.RmSource == null)
                        {
                            TempData["RmSourceError"] = "يرجى إدخال مصدر المادة الخام";
                            return View(rowMaterial);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = rowMaterial.RmName;
                            temporary.Cel2 = rowMaterial.RmMeasruingUnit;
                            temporary.Cel3 = rowMaterial.RmAmountUsed;
                            temporary.Cel4 = rowMaterial.RmPercentInPro.ToString();
                            temporary.Cel5 = rowMaterial.RmSource;
                            if (rowMaterial.RmNotes == null)
                            {
                                temporary.Cel6 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel6 = rowMaterial.RmNotes;
                            }
                            temporary.Cel7 = rowMaterial.FaId.ToString();
                            temporary.TblDesc = "rowmaterial";


                            var inserttemporaryRM = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary row Material done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانات بيانات المواد الخام قبل إدخال بيانات الآلات";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi row Material Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult RowMaterialNext()
        {

            var GetInsertedRMCount = _repository.GetAll().Where(RM => RM.TblDesc == "rowmaterial").ToList();
            if (GetInsertedRMCount.Count != 0)
            {
                return RedirectToAction("HelpMaterialData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات المواد المساعدة قبل إدخال بيانات  المواد الخام";
                return RedirectToAction("RowMaterialData", "CreateFacility");
            }
        }


        //----------------------delete temp row Material
        public IActionResult DeleteRowMaterial(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم المادة الخام غير صحيح";
                    return RedirectToAction(nameof(RowMaterialData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("RowMaterialData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete row material Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileRM(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("RowMaterialData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                     if (tableName == "RowMaterial.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.TblDesc = "rowmaterial";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("RowMaterialData", "CreateFacility");

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }







        //----------------------help material Data
        [HttpGet]
        public IActionResult HelpMaterialData()
        {
            Console.WriteLine($"Enter in Get help material Data");
            return View();
        }

        //----------------------Multi help Material Data
        [HttpPost]
        public IActionResult HelpMaterialData(HelpMaterial helpMaterial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(helpMaterial);
                }
                else
                {
                    var RowmaterialData = _repository.GetAll().Where(RM => RM.TblDesc == "rowmaterial").ToList();
                    if (RowmaterialData.Count != 0)
                    {
                        if (helpMaterial.HmName == null)
                        {
                            TempData["RmNameError"] = "يرجى إدخال اسم المادة الخام";
                            return View(helpMaterial);
                        }
                        else if (helpMaterial.HmMeasruingUnit == null)
                        {
                            TempData["RmMeasruingUnitError"] = "يرجى إدخال وحدة القياس";
                            return View(helpMaterial);
                        }
                        else if (helpMaterial.HmPercentInPro == 0)
                        {
                            TempData["HmPercentInProError"] = "يرجى إدخال النسبة المئوية في المنتج";
                            return View(helpMaterial);
                        }
                        else if (helpMaterial.HmAmountUsed == null)
                        {
                            TempData["HmAmountUsedError"] = "يرجى إدخال الكمية المستخدمة";
                            return View(helpMaterial);
                        }
                        else if (helpMaterial.HmSource == null)
                        {
                            TempData["HmSourceError"] = "يرجى إدخال مصدر المادة الخام";
                            return View(helpMaterial);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = helpMaterial.HmName;
                            temporary.Cel2 = helpMaterial.HmMeasruingUnit;
                            temporary.Cel3 = helpMaterial.HmAmountUsed;
                            temporary.Cel4 = helpMaterial.HmPercentInPro.ToString();
                            temporary.Cel5 = helpMaterial.HmSource;
                            if (helpMaterial.HmNotes == null)
                            {
                                temporary.Cel6 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel6 = helpMaterial.HmNotes;
                            }
                            temporary.Cel7 = helpMaterial.FaId.ToString();
                            temporary.TblDesc = "helpmaterial";


                            var inserttemporaryHM = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary help Material done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إخال بيانات المواد المساعدة قبل إدخال بيانات المواد الخام";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi help Material Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult HelpMaterialNext()
        {

            var GetInsertedHMCount = _repository.GetAll().Where(RM => RM.TblDesc == "helpmaterial").ToList();
            if (GetInsertedHMCount.Count != 0)
            {
                return RedirectToAction("TransportationData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات وسائل النقل قبل إدخال بيانات المواد المساعدة";
                return RedirectToAction("HelpMaterialData", "CreateFacility");
            }
        }


        //----------------------delete temp row Material
        public IActionResult DeleteHelpMaterial(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم المادة المساعدة غير صحيح";
                    return RedirectToAction(nameof(RowMaterialData));
                }
                else
                {
                    //_repository.DeleteTmp(Id);
                    return RedirectToAction("HelpMaterialData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete help material Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileHM(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("HelpMaterialData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                     if (tableName == "HelpMaterial.xlsx")
                    {

                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.TblDesc = "helpmaterial";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("HelpMaterialData", "CreateFacility");

                    }
                    
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }







        //----------------------Transportation Data
        [HttpGet]
        public IActionResult TransportationData()
        {
            Console.WriteLine($"Enter in Get Transportation Data");
            return View();
        }

        //----------------------Multi Transportation Data
        [HttpPost]
        public IActionResult TransportationData(Transportation transportation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(transportation);
                }
                else
                {
                    var HelpmaterialData = _repository.GetAll().Where(HM => HM.TblDesc == "helpmaterial").ToList();
                    if (HelpmaterialData.Count != 0)
                    {

                        if (transportation.TrType == null)
                        {
                            TempData["TrTypeError"] = "يرجى إدخال نوع وسيلة النقل";
                            return View(transportation);
                        }
                        else if (transportation.TrPlateNumber == null)
                        {
                            TempData["TrPlateNumberError"] = "يرجى إدخال رقم لوحة وسيلة النقل";
                            return View(transportation);
                        }
                        else if (transportation.TrLoad == null)
                        {
                            TempData["TrLoadError"] = "يرجى إدخال مقدار حمولة وسيلة النقل";
                            return View(transportation);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = transportation.TrType;
                            temporary.Cel2 = transportation.TrPlateNumber.ToString();
                            temporary.Cel3 = transportation.TrLoad;
                            if (transportation.TrNotes == null)
                            {
                                temporary.Cel4 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel4 = transportation.TrNotes;
                            }
                            temporary.Cel5 = transportation.FaId.ToString();
                            temporary.TblDesc = "transportation";


                            var inserttemporaryTr = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary transportation done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانات وسائل النقل قبل إدخال بيانات المواد المساعدة";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi Transportation Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult TransportationNext()
        {

            var GetInsertedTrCount = _repository.GetAll().Where(Tr => Tr.TblDesc == "transportation").ToList();
            if (GetInsertedTrCount.Count != 0)
            {
                return RedirectToAction("AgentsSellingPointsData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات الوكلاء ونقاط البيع قبل إدخال بيانات وسائل النقل";
                return RedirectToAction("TransportationData", "CreateFacility");
            }
        }


        //----------------------delete temp Transportation
        public IActionResult DeleteTransportationl(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم وسيلة النقل غير صحيح";
                    return RedirectToAction(nameof(TransportationData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("TransportationData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete Transportation Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileTR(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("TransportationData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                     if (tableName == "Transportation.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.TblDesc = "transportation";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("TransportationData", "CreateFacility");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }












        //----------------------Agents Selling Point Data
        [HttpGet]
        public IActionResult AgentsSellingPointsData()
        {
            Console.WriteLine($"Enter in Get Agents Selling Point Data");
            return View();
        }

        //----------------------Multi Agents Selling Point Data
        [HttpPost]
        public IActionResult AgentsSellingPointsData(AgentsPoint agentsPoint)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(agentsPoint);
                }
                else
                {
                    var TransportationData = _repository.GetAll().Where(Tr => Tr.TblDesc == "transportation").ToList();
                    if (TransportationData.Count != 0)
                    {
                        if (agentsPoint.ApName == null)
                        {
                            TempData["ApNameError"] = "يرجى إدخال اسم الوكيل أو نقطة البيع";
                            return View(agentsPoint);
                        }
                        else if (agentsPoint.ApTradeName == null)
                        {
                            TempData["ApTradeNameError"] = "يرجى إدخال الاسم التجاري للوكيل أو نقطة البيع";
                            return View(agentsPoint);
                        }
                        else if (agentsPoint.ApPhoneNumber == null)
                        {
                            TempData["ApPhoneNumberError"] = "يرجى إدخال رقم هاتف الوكيل أو نقطة البيع";
                            return View(agentsPoint);
                        }
                        else if (agentsPoint.ApAddress == null)
                        {
                            TempData["ApAddressError"] = "يرجى إدخال عنوان الوكيل أو نقطة البيع";
                            return View(agentsPoint);
                        }
                        else if (agentsPoint.ApType == null)
                        {
                            TempData["ApTypeError"] = "يرجى إدخال النوع";
                            return View(agentsPoint);
                        }
                        Temporary temporary = new Temporary();
                        temporary.Cel1 = agentsPoint.ApName;
                        temporary.Cel2 = agentsPoint.ApTradeName;
                        temporary.Cel3 = agentsPoint.ApPhoneNumber;
                        temporary.Cel4 = agentsPoint.ApAddress;
                        temporary.Cel5 = agentsPoint.ApType;
                        if (agentsPoint.ApNotes == null)
                        {
                            temporary.Cel6 = "لاتوجد ملاحظات";
                        }
                        else
                        {
                            temporary.Cel6 = agentsPoint.ApNotes;
                        }
                        temporary.Cel7 = agentsPoint.FaId.ToString();
                        temporary.TblDesc = "agentspoint";


                        var inserttemporaryAP = _repository.Add(temporary);
                        Console.WriteLine($"insert temporary agents Point done");

                        return View();
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانات الوكلاء ونقاط البيع قبل إدخال بيانات وسائل النقب";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi Transportation Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult AgentsSellingPointsNext()
        {

            var GetInsertedAPCount = _repository.GetAll().Where(AP => AP.TblDesc == "agentspoint").ToList();
            if (GetInsertedAPCount.Count != 0)
            {
                return RedirectToAction("ProductionCapacityData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات الطاقة الانتاجية قبل إدخال بيانات الوكلاء ونقاط البيع";
                return RedirectToAction("AgentsSellingPointsData", "CreateFacility");
            }
        }


        //----------------------delete temp Agents Selling Point
        public IActionResult DeleteAgentsSellingPoints(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم الوكيل/نقطة البيع غير صحيح";
                    return RedirectToAction(nameof(TransportationData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("AgentsSellingPointsData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete Agents Selling Points Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFileAP(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("AgentsSellingPointsData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                     if (tableName == "AgentsSellingPoint.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.Cel5 = worksheet.Cells[row, 5].Value.ToString().Trim();
                                    temporary.Cel6 = worksheet.Cells[row, 6].Value.ToString().Trim();
                                    temporary.TblDesc = "agentspoint";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("AgentsSellingPointsData", "CreateFacility");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }












        //----------------------production capacity Data
        [HttpGet]
        public IActionResult ProductionCapacityData()
        {
            Console.WriteLine($"Enter in Get production capacity  Data");
            return View();
        }

        //----------------------Multi production capacity Data
        [HttpPost]
        public IActionResult ProductionCapacityData(ProCapacity proCapacity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(proCapacity);
                }
                else
                {
                    var AgentsSellingPointData = _repository.GetAll().Where(AP => AP.TblDesc == "agentspoint").ToList();
                    if (AgentsSellingPointData.Count != 0)
                    {
                        if (proCapacity.PcProductName == null)
                        {
                            TempData["PcProductNameError"] = "يرجى إدخال اسم المنتج";
                            return View(proCapacity);
                        }
                        else if (proCapacity.PcMeasruingUnit == null)
                        {
                            TempData["PcMeasruingUnitError"] = "يرجى إدخال وحدة القياس";
                            return View(proCapacity);
                        }
                        else if (proCapacity.PcYearQuantity == null)
                        {
                            TempData["PcYearQuantityError"] = "يرجى إدخال الكمية المنتجة";
                            return View(proCapacity);
                        }
                        else
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = proCapacity.PcProductName;
                            temporary.Cel2 = proCapacity.PcMeasruingUnit;
                            temporary.Cel3 = proCapacity.PcYearQuantity;
                            if (proCapacity.PcNotes == null)
                            {
                                temporary.Cel4 = "لاتوجد ملاحظات";
                            }
                            else
                            {
                                temporary.Cel4 = proCapacity.PcNotes;
                            }
                            temporary.Cel5 = proCapacity.FaId.ToString();
                            temporary.TblDesc = "procapacity";


                            var inserttemporaryPC = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary production capacity done");

                            return View();
                        }
                    }
                    else
                    {
                        TempData["Error"] = "لايمكنك إدخال بيانات الطاقة الانتاجية قبل إدخال بيانات الوكلاء ونقاط البيع";
                        return View();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi production capacity Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult ProductionCapacityNext()
        {

            var GetInsertedPCCount = _repository.GetAll().Where(PC => PC.TblDesc == "procapacity").ToList();
            if (GetInsertedPCCount.Count != 0)
            {
                return RedirectToAction("SeftySecurityData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات وسائل الأمن والسلامة قبل إدخال بيانات الطاقة الأنتاجية";
                return RedirectToAction("ProductionCapacityData", "CreateFacility");
            }
        }


        //----------------------delete temp production capacity
        public IActionResult DeleteProductionCapacity(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم المنتج غير صحيح";
                    return RedirectToAction(nameof(ProductionCapacityData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("ProductionCapacityData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete Production Capacity Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }

        //Import Excel Files
        [HttpPost]
        public IActionResult ImportExcelFilePC(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    string actionName = ControllerContext.ActionDescriptor.DisplayName;
                    TempData["ExFileNull"] = "لايمكن رفع ملف فارغ";
                    return RedirectToAction("ProductionCapacityData", "CreateFacility");
                }
                else
                {
                    var tableName = formFile.FileName;
                    if (tableName == "productionCapacity.xlsx")
                    {
                        using (var stream = new MemoryStream())
                        {
                            formFile.CopyToAsync(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var rowcount = worksheet.Dimension.Rows;
                                for (int row = 2; row <= rowcount; row++)
                                {
                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = worksheet.Cells[row, 1].Value.ToString().Trim();
                                    temporary.Cel2 = worksheet.Cells[row, 2].Value.ToString().Trim();
                                    temporary.Cel3 = worksheet.Cells[row, 3].Value.ToString().Trim();
                                    temporary.Cel4 = worksheet.Cells[row, 4].Value.ToString().Trim();
                                    temporary.TblDesc = "procapacity";
                                    _repository.Add(temporary);

                                }

                            }

                        }
                        tableName = null;
                        return RedirectToAction("ProductionCapacityData", "CreateFacility");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"------Excel Err----------{ex.Message}");
                TempData["Error"] = "تأكد من صحة الملف";
                return RedirectToAction("Index", "Home");
            }
        }






        //----------------------sefty security Data
        [HttpGet]
        public IActionResult SeftySecurityData()
        {
            Console.WriteLine($"Enter in Get sefty security  Data");
            return View();
        }

        //----------------------Multi sefty security Data
        [HttpPost]
        public IActionResult SeftySecurityData(SafetySecurity safetySecurity)

        {
            try
            {
                var GetInsertedSSCount = _repository.GetAll().Where(fa => fa.TblDesc == "seftysecurity").ToList();
                if (GetInsertedSSCount.Count != 0)
                {

                    TempData["Error"] = "لقد قمت بإدخال بيانات الأمن والسلامة مسبقاً";
                    return View(safetySecurity);
                }
                else
                {
                    if (
                    safetySecurity.SsFireSystem == null ||
                    safetySecurity.SsEmergencyExit == null ||
                    safetySecurity.SsOccSafety == null ||
                    safetySecurity.SsSafetyDashboard == null ||
                    safetySecurity.SsVentilation == null ||
                    safetySecurity.SsFirstAidKit == null ||
                    safetySecurity.SsFireSystem == null
                    )
                    {
                        TempData["Error"] = "لايمكن إدخال بيانات فارغة";
                        return View(safetySecurity);
                    }
                    else
                    {
                        var productioncapacityData = _repository.GetAll().Where(PC => PC.TblDesc == "procapacity").ToList();
                        if (productioncapacityData.Count != 0)
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = safetySecurity.SsFireSystem.ToString();
                            temporary.Cel2 = safetySecurity.SsEmergencyExit.ToString();
                            temporary.Cel3 = safetySecurity.SsOccSafety.ToString();
                            temporary.Cel4 = safetySecurity.SsSafetyDashboard.ToString();
                            temporary.Cel5 = safetySecurity.SsVentilation.ToString();
                            temporary.Cel6 = safetySecurity.SsLighting.ToString();
                            temporary.Cel7 = safetySecurity.SsFirstAidKit.ToString();
                            temporary.Cel8 = safetySecurity.FaId.ToString();
                            temporary.TblDesc = "seftysecurity";



                            var inserttemporarySS = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary sefty security done");

                            return RedirectToAction("relevantDocData", "CreateFacility");
                        }
                        else
                        {
                            TempData["Error"] = "لايمكنك إدخال بيانات وسائل الأمن والسلامة قبل إدخال بيانات الطاقة الأنتاجية";
                            return View();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi production capacity Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return View();
            }
        }

        public IActionResult SeftySecurityNext()
        {
            var GetInsertedSSCount = _repository.GetAll().Where(fa => fa.TblDesc == "seftysecurity").ToList();
            if (GetInsertedSSCount.Count != 0)
            {
                return RedirectToAction("relevantDocData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات وثائق الجهات ذات الصلة قبل إدخال بيانات الأمن والسلامة";
                return RedirectToAction("SeftySecurityData", "CreateFacility");
            }
        }







        //----------------------relevant Documents Data
        [HttpGet]
        public IActionResult relevantDocData()
        {
            Console.WriteLine($"Enter in Get relevant Documents  Data");
            return View();
        }

        //----------------------Multi relevant Documents Data
        [HttpPost]
        public IActionResult relevantDocData(RelevantDocVM relevantDocVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Enter in !ModelState.IsValid");
                    return View(relevantDocVM);
                }
                else
                {
                    if (relevantDocVM.RdDocName == null)
                    {
                        TempData["RdDocNameError"] = "يرجى إدخال اسم الوثيقة";
                        return View(relevantDocVM);
                    }
                    else if (relevantDocVM.RdStakeholderName == null)
                    {
                        TempData["RdStakeholderNameError"] = "يرجى إدخال اسم الجههة ذات الصلة";
                        return View(relevantDocVM);
                    }
                    else if (relevantDocVM.ReFile == null)
                    {
                        TempData["ReFileError"] = "يرجى إدراج ملف الوثيقة";
                        return View(relevantDocVM);
                    }
                    else
                    {
                        var seftysecurityData = _repository.GetAll().Where(SS => SS.TblDesc == "seftysecurity").ToList();
                        if (seftysecurityData.Count != 0)
                        {
                            if (relevantDocVM.ReFile != null)
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
                                    string FileName = relevantDocVM.ReFile.FileName; //file name
                                    FileName = Path.GetFileName(FileName);              // file path
                                    string UploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadsFiles", FileName);
                                    var Stream = new FileStream(UploadFilePath, FileMode.Create);
                                    relevantDocVM.ReFile.CopyToAsync(Stream);


                                    Temporary temporary = new Temporary();
                                    temporary.Cel1 = relevantDocVM.RdDocName;
                                    temporary.Cel2 = relevantDocVM.RdStakeholderName;
                                    if (relevantDocVM.ReDescription == null)
                                    {
                                        temporary.Cel3 = "لايوجد وصف";
                                    }
                                    else
                                    {
                                        temporary.Cel3 = relevantDocVM.ReDescription;
                                    }
                                    temporary.Cel4 = relevantDocVM.ReFile.FileName;
                                    temporary.Cel5 = relevantDocVM.FaId.ToString();
                                    temporary.TblDesc = "relevantdoc";


                                    var inserttemporaryRD = _repository.Add(temporary);
                                    Console.WriteLine($"insert temporary relevant Documents done");
                                }
                                else
                                {
                                    TempData["Error"] = "لايمكن إدراج ملفات من هذا النوع";
                                    return View(relevantDocVM);
                                }
                            }
                            else
                            {
                                TempData["Error"] = "لايمكن إدراج ملف فارغ";
                                return View(relevantDocVM);
                            }
                        }
                        else
                        {
                            TempData["Error"] = "لايمكنك إدخال بيانات وثائق الجهات ذات الصلة قبل إدخال بيانات الأمن والسلامة";
                            return View();
                        }
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi relevant Documents Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult relevantDocNext()
        {
            var GetInsertedRDCount = _repository.GetAll().Where(RD => RD.TblDesc == "relevantdoc").ToList();
            if (GetInsertedRDCount.Count != 0)
            {
                return RedirectToAction("CastDataData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى بيانات المدلي قبل إدخال بيانات وثائق الجهات المختصة";
                return RedirectToAction("relevantDocData", "CreateFacility");
            }
        }


        //----------------------delete temp relevant Documents
        public IActionResult DeleterelevantDoc(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Error"] = "رقم الوثيقة غير صحيح";
                    return RedirectToAction(nameof(relevantDocData));
                }
                else
                {
                    _repository.DeleteTmp(Id);
                    return RedirectToAction("relevantDocData", "CreateFacility");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Get Delete relevant Documents Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }

        }








        //----------------------cast Data Data
        [HttpGet]
        public IActionResult CastDataData()
        {
            Console.WriteLine($"Enter in Get Cast Data  Data");
            return View();
        }

        //----------------------Multi Cast Data Data
        [HttpPost]
        public IActionResult CastDataData(CastDatum CastDatum)
        {
            try
            {
                if (CastDatum.CdName == null)
                {
                    TempData["CdNameError"] = "يرجى إدخال اسم المدلي";
                    return View(CastDatum);
                }
                else if (CastDatum.CdJob == null)
                {
                    TempData["CdJobError"] = "يرجى إدخال وظيفة المدلي";
                    return View(CastDatum);
                }
                else if (CastDatum.CdPhoneNumber == null)
                {
                    TempData["CdPhoneNumberError"] = "يرجى إدخال رقم هاتف المدلي";
                    return View(CastDatum);
                }
                else if (CastDatum.CdIdCardNumber == null)
                {
                    TempData["CdIdCardNumberError"] = "يرجى إدخال رقم بطاقة المدلي";
                    return View(CastDatum);
                }
                else if (CastDatum.CdCardPlaceIssu == null)
                {
                    TempData["CdCardPlaceIssuError"] = "يرجى إدخال مكان إصدار بطاقة المدلي";
                    return View(CastDatum);
                }
                else if (CastDatum.CdCardIssuDate == null)
                {
                    TempData["CdCardIssuDateError"] = "يرجى إدخال تاريخ بطاقة المدلي";
                    return View(CastDatum);
                }
                if (CastDatum.CdCardIssuDate > DateTime.Now)
                {
                    TempData["CdCardIssuDateError"] = "لايمكن إدخال تاريخ أكبر من تاريخ اليوم" + DateTime.Now.ToString();
                    return View(CastDatum);
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        Console.WriteLine($"Enter in !ModelState.IsValid");
                        return View(CastDatum);
                    }
                    else
                    {
                        var GetInsertedCDCount = _repository.GetAll().Where(cd => cd.TblDesc == "castdata").ToList();
                        if (GetInsertedCDCount.Count != 0)
                        {

                            TempData["Error"] = "لقد قمت بإدخال بيانات المدلي مسبقاً";
                            return View(CastDatum);
                        }
                        else
                        {
                            var relevantDocumentsyData = _repository.GetAll().Where(RD => RD.TblDesc == "relevantdoc").ToList();
                            if (relevantDocumentsyData.Count != 0)
                            {
                                Temporary temporary = new Temporary();
                                temporary.Cel1 = CastDatum.CdName;
                                temporary.Cel2 = CastDatum.CdJob;
                                temporary.Cel3 = CastDatum.CdPhoneNumber;
                                temporary.Cel4 = CastDatum.CdIdCardNumber.ToString();
                                temporary.Cel5 = CastDatum.CdCardPlaceIssu;
                                temporary.Cel6 = CastDatum.CdCardIssuDate.ToString();
                                temporary.Cel7 = CastDatum.FaId.ToString();
                                temporary.TblDesc = "castdata";


                                var inserttemporaryRD = _repository.Add(temporary);
                                Console.WriteLine($"insert temporary Cast Data done");
                                return RedirectToAction("AnotherData", "CreateFacility");
                            }
                            else
                            {
                                TempData["Error"] = "لايمكنك إدخال بيانات المدلي قبل إدخال بيانات وثائق الجهات ذات الصلة";
                                return View();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with multi Cast Data Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CastDataNext()
        {
            var GetInsertedCDCount = _repository.GetAll().Where(cd => cd.TblDesc == "castdata").ToList();
            if (GetInsertedCDCount.Count != 0)
            {
                return RedirectToAction("AnotherData", "CreateFacility");
            }
            else
            {
                TempData["Error"] = "لايمكنك التجاوز الى البيانات الأخرى قبل إدخال بيانات المدلي";
                return RedirectToAction("CastDataData", "CreateFacility");
            }
        }




        //----------------------Another Data
        [HttpGet]
        public IActionResult AnotherData()
        {
            Console.WriteLine($"Enter in Get another  Data");
            return View();
        }

        [HttpPost]
        public IActionResult AnotherData(VisitsTraffic visitsTraffic)
        {
            try
            {
                if (visitsTraffic.VtVisitDate == null)
                {
                    TempData["VtVisitDateError"] = "يرجى إدخال تاريخ الزيارة الى المنشأة";
                    return View(visitsTraffic);
                }
                else if (visitsTraffic.VtVisitPurpose == null)
                {
                    TempData["VtVisitPurposeError"] = "يرجى تحديد الغرض من الزيارة الى المنشأة";
                    return View(visitsTraffic);
                }
                else if (visitsTraffic.FaDataState == null)
                {
                    TempData["FaDataStateError"] = "يرجى تحديد حالة بيانات المنشأة";
                    return View(visitsTraffic);
                }
                if (visitsTraffic.VtVisitDate > DateTime.Now)
                {
                    TempData["VtVisitDateError"] = "لايمكن إدخال تاريخ أكبر من تاريخ اليوم" + DateTime.Now.ToString();
                    return View(visitsTraffic);
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        Console.WriteLine($"Enter in !ModelState.IsValid");
                        return View(visitsTraffic);
                    }
                    else
                    {
                        var castData = _repository.GetAll().Where(CD => CD.TblDesc == "castdata").ToList();
                        if (castData.Count != 0)
                        {
                            Temporary temporary = new Temporary();
                            temporary.Cel1 = visitsTraffic.VtVisitDate.ToString();
                            temporary.Cel2 = visitsTraffic.VtVisitPurpose;
                            temporary.Cel3 = visitsTraffic.ReFormNo.ToString();
                            temporary.Cel4 = visitsTraffic.FaId.ToString();
                            temporary.Cel5 = visitsTraffic.FaDataState;
                            temporary.TblDesc = "visitstraffic";


                            var inserttemporaryVT = _repository.Add(temporary);
                            Console.WriteLine($"insert temporary visits Traffic done");

                            AddAllFacilityData();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["Error"] = "لايمكنك الانهاء قبل إدخال بيانات المدلي";
                            return View();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post insert with visits Traffic Action");
                Console.WriteLine($"{ex.Message}");
                TempData["Error"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }
        }





        //add all data to database
        public void AddAllFacilityData()
        {
            try
            {
                //add main data
                var facilityData = _repository.GetAll().Where(fa => fa.TblDesc == "facility").ToList();
                Facility facility = new Facility();
                foreach (var itemFa in facilityData)
                {
                    facility.ReFormNo = int.Parse(itemFa.Cel1);
                    facility.FaName = itemFa.Cel2;
                    facility.FaNumber = int.Parse(itemFa.Cel3);
                    facility.FaSize = itemFa.Cel4;
                    facility.FaActivityType = itemFa.Cel5;
                    facility.FaMainActivity = itemFa.Cel6;
                    facility.FaShareCapital = itemFa.Cel7;
                    facility.FaStartProduction = DateTime.Parse(itemFa.Cel8);
                    facility.FaTotalArea = itemFa.Cel9;
                    facility.FaOwnership = itemFa.Cel10;
                    facility.FaWorkPeriods = int.Parse(itemFa.Cel11);
                    facility.FaLegalEntity = itemFa.Cel12;
                    facility.FaOwnerName = itemFa.Cel13;
                    facility.FaManagerName = itemFa.Cel14;
                    facility.FaMode = itemFa.Cel15;

                    facility.FaWebSite = itemFa.Cel16;
                    facility.FaEmail = itemFa.Cel17;
                    facility.FaFaxNumber = itemFa.Cel18;
                    facility.FaPhoneNumber = itemFa.Cel19;
                    facility.FaMobileNumber = itemFa.Cel20;


                    facility.FaGovernorate = itemFa.Cel21;
                    facility.FaDirectorate = itemFa.Cel22;
                    facility.FaAddress = itemFa.Cel23;
                    facility.FaRegionName = itemFa.Cel24;
                    facility.FaLongitude = double.Parse(itemFa.Cel25);
                    facility.FaLatitude = double.Parse(itemFa.Cel26);

                    var result = _repositoryFa.Add(facility);
                    FaID = _context.Facilities.Where(faId => faId.FaName == itemFa.Cel2).Select(x => x.FaId).FirstOrDefault();
                }



                //add secondary Act data
                var secondaryActData = _repository.GetAll().Where(SA => SA.TblDesc == "secondary").ToList();
                SecondaryAct secondaryAct = new SecondaryAct();
                foreach (var itemSA in secondaryActData)
                {
                    secondaryAct.SaName = itemSA.Cel1;
                    secondaryAct.FaId = FaID;

                    _repositorySA.Add(secondaryAct);
                }

                //add site Reasons data
                var siteReasonsData = _repository.GetAll().Where(SR => SR.TblDesc == "reason").ToList();
                SiteReason siteReason = new SiteReason();
                foreach (var itemSR in siteReasonsData)
                {
                    siteReason.SrReason = itemSR.Cel1;
                    siteReason.FaId = FaID;

                    _repositorySR.Add(siteReason);
                }


                //add Buliding Data
                var BulidingData = _repository.GetAll().Where(bu => bu.TblDesc == "building").ToList();
                foreach (var itemBu in BulidingData)
                {
                    Building building = new Building();

                    building.BuOwnership = itemBu.Cel1;
                    building.BuDescription = itemBu.Cel2;
                    building.BuLocation = itemBu.Cel3;
                    building.BuType = itemBu.Cel4;
                    building.BuLength = int.Parse(itemBu.Cel5);
                    building.BuWidth = int.Parse(itemBu.Cel6);
                    building.BuHigh = int.Parse(itemBu.Cel7);
                    building.BuArea = itemBu.Cel8;
                    building.BuNotes = itemBu.Cel9;
                    building.FaId = FaID;

                    _repositoryBu.Add(building);
                }



                //add Workers Data
                var WorkersData = _repository.GetAll().Where(wo => wo.TblDesc == "worker").ToList();
                foreach (var itemWo in WorkersData)
                {
                    Worker worker = new Worker();
                    worker.WoType = itemWo.Cel1;
                    worker.WoNationality = itemWo.Cel2;
                    worker.WoTotal = int.Parse(itemWo.Cel3);
                    worker.WoMaleNumber = int.Parse(itemWo.Cel4);
                    worker.WoFemaleNumber = int.Parse(itemWo.Cel5);
                    worker.WoEduQualifying = itemWo.Cel6;
                    worker.WoSpecialization = itemWo.Cel7;
                    worker.WoSpecialization = itemWo.Cel7;
                    worker.WoNotes = itemWo.Cel8;
                    worker.FaId = FaID;

                    _repositoryWo.Add(worker);
                }


                //add Machines Data
                var MachinesData = _repository.GetAll().Where(Ma => Ma.TblDesc == "machine").ToList();
                foreach (var itemMa in MachinesData)
                {
                    Machine machine = new Machine();
                    machine.MaName = itemMa.Cel1;
                    machine.MaNumber = int.Parse(itemMa.Cel2);
                    machine.MaUses = itemMa.Cel3;
                    machine.MaCountryManufacture = itemMa.Cel4;
                    machine.MaMeasruingUnit = itemMa.Cel5;
                    machine.MaAbility = itemMa.Cel6;
                    machine.MaSource = itemMa.Cel7;
                    machine.MaSourceAddress = itemMa.Cel8;
                    machine.MaNotes = itemMa.Cel9;
                    machine.FaId = FaID;

                    _repositoryMa.Add(machine);
                }


                //add Row material Data
                var RowmaterialData = _repository.GetAll().Where(RM => RM.TblDesc == "rowmaterial").ToList();
                foreach (var itemRM in RowmaterialData)
                {
                    RowMaterial rowMaterial = new RowMaterial();
                    rowMaterial.RmName = itemRM.Cel1;
                    rowMaterial.RmMeasruingUnit = itemRM.Cel2;
                    rowMaterial.RmAmountUsed = itemRM.Cel3;
                    rowMaterial.RmPercentInPro = int.Parse(itemRM.Cel4);
                    rowMaterial.RmSource = itemRM.Cel5;
                    rowMaterial.RmNotes = itemRM.Cel6;
                    rowMaterial.FaId = FaID;

                    _repositoryRM.Add(rowMaterial);
                }



                //add Help material Data
                var HelpmaterialData = _repository.GetAll().Where(HM => HM.TblDesc == "helpmaterial").ToList();
                foreach (var itemHM in HelpmaterialData)
                {
                    HelpMaterial helpMaterial = new HelpMaterial();
                    helpMaterial.HmName = itemHM.Cel1;
                    helpMaterial.HmMeasruingUnit = itemHM.Cel2;
                    helpMaterial.HmAmountUsed = itemHM.Cel3;
                    helpMaterial.HmPercentInPro = int.Parse(itemHM.Cel4);
                    helpMaterial.HmSource = itemHM.Cel5;
                    helpMaterial.HmNotes = itemHM.Cel6;
                    helpMaterial.FaId = FaID;

                    _repositoryHM.Add(helpMaterial);
                }


                //add Transportation Data
                var TransportationData = _repository.GetAll().Where(Tr => Tr.TblDesc == "transportation").ToList();
                foreach (var itemTr in TransportationData)
                {
                    Transportation transportation = new Transportation();
                    transportation.TrType = itemTr.Cel1;
                    transportation.TrPlateNumber = int.Parse(itemTr.Cel2);
                    transportation.TrLoad = itemTr.Cel3;
                    transportation.TrNotes = itemTr.Cel4;
                    transportation.FaId = FaID;

                    _repositoryTr.Add(transportation);
                }


                //add Agents Selling Point Data
                var AgentsSellingPointData = _repository.GetAll().Where(AP => AP.TblDesc == "agentspoint").ToList();
                foreach (var itemAP in AgentsSellingPointData)
                {
                    AgentsPoint agentsPoint = new AgentsPoint();
                    agentsPoint.ApName = itemAP.Cel1;
                    agentsPoint.ApTradeName = itemAP.Cel2;
                    agentsPoint.ApPhoneNumber = itemAP.Cel3;
                    agentsPoint.ApAddress = itemAP.Cel4;
                    agentsPoint.ApType = itemAP.Cel5;
                    agentsPoint.ApNotes = itemAP.Cel6;
                    agentsPoint.FaId = FaID;

                    _repositoryAP.Add(agentsPoint);
                }


                //add production capacity Data
                var productioncapacityData = _repository.GetAll().Where(PC => PC.TblDesc == "procapacity").ToList();
                foreach (var itemPC in productioncapacityData)
                {
                    ProCapacity proCapacity = new ProCapacity();
                    proCapacity.PcProductName = itemPC.Cel1;
                    proCapacity.PcMeasruingUnit = itemPC.Cel2;
                    proCapacity.PcYearQuantity = itemPC.Cel3;
                    proCapacity.PcNotes = itemPC.Cel4;
                    proCapacity.FaId = FaID;

                    _repositoryPC.Add(proCapacity);
                }


                //add sefty security Data
                var seftysecurityData = _repository.GetAll().Where(SS => SS.TblDesc == "seftysecurity").ToList();
                foreach (var itemSS in seftysecurityData)
                {
                    SafetySecurity safetySecurity = new SafetySecurity();
                    safetySecurity.SsFireSystem = itemSS.Cel1;
                    safetySecurity.SsEmergencyExit = itemSS.Cel2;
                    safetySecurity.SsOccSafety = itemSS.Cel3;
                    safetySecurity.SsSafetyDashboard = itemSS.Cel4;
                    safetySecurity.SsVentilation = itemSS.Cel5;
                    safetySecurity.SsLighting = itemSS.Cel6;
                    safetySecurity.SsFirstAidKit = itemSS.Cel7;
                    safetySecurity.FaId = FaID;

                    _repositorySS.Add(safetySecurity);
                }


                //add relevant Documents Data
                var relevantDocumentsyData = _repository.GetAll().Where(RD => RD.TblDesc == "relevantdoc").ToList();
                foreach (var itemRD in relevantDocumentsyData)
                {
                    RelevantDoc relevantDoc = new RelevantDoc();
                    relevantDoc.RdDocName = itemRD.Cel1;
                    relevantDoc.RdStakeholderName = itemRD.Cel2;
                    relevantDoc.ReDescription = itemRD.Cel3;
                    relevantDoc.ReUrl = itemRD.Cel4;
                    relevantDoc.FaId = FaID;

                    _repositoryRD.Add(relevantDoc);
                }



                //add cast Data Data
                var castData = _repository.GetAll().Where(CD => CD.TblDesc == "castdata").ToList();
                foreach (var itemCD in castData)
                {
                    CastDatum castDatum = new CastDatum();
                    castDatum.CdName = itemCD.Cel1;
                    castDatum.CdJob = itemCD.Cel2;
                    castDatum.CdPhoneNumber = itemCD.Cel3;
                    castDatum.CdIdCardNumber = itemCD.Cel4;
                    castDatum.CdCardPlaceIssu = itemCD.Cel5;
                    castDatum.CdCardIssuDate = DateTime.Parse(itemCD.Cel6);
                    castDatum.FaId = FaID;

                    _repositoryCD.Add(castDatum);
                }


                //add Another Data
                var AnotherData = _repository.GetAll().Where(VT => VT.TblDesc == "visitstraffic").ToList();
                foreach (var itemVT in AnotherData)
                {
                    VisitsTraffic visitsTraffic = new VisitsTraffic();
                    visitsTraffic.VtVisitDate = DateTime.Parse(itemVT.Cel1);
                    visitsTraffic.VtVisitPurpose = itemVT.Cel2;
                    visitsTraffic.ReFormNo = int.Parse(itemVT.Cel3);
                    visitsTraffic.FaDataState = itemVT.Cel5;
                    visitsTraffic.FaId = FaID;

                    _repositoryVT.Add(visitsTraffic);
                }

                //rtuncate temp table 
                _context.Temporaries.RemoveRange(_context.Temporaries);
                _context.SaveChanges();

                SessionMsg(Helper.Success, Resource.ResourceWeb.AddNewFacility, Resource.ResourceWeb.Success);
                RedirectToAction("Index", "FieldVisitForms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"Erorr!");
            }
        }



        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            _sesstion.HttpContext.Session.SetString(Helper.MsgType, MsgType);
            _sesstion.HttpContext.Session.SetString(Helper.Title, Title);
            _sesstion.HttpContext.Session.SetString(Helper.Msg, Msg);
        }

    }
}