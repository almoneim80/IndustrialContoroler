using IndustrialContoroler.Constants;
using IndustrialContoroler.VewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialContoroler.Models
{
    [Authorize(Permissions.Reports.View)]
    public class reportsController : Controller
    {
        public IndustrialContorolerDatabaseContext _context;



        public reportsController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;

        }

        //Statistics
        [HttpPost]
        public IActionResult Index( string fa_Name, int fa_Number, string fa_OwnerName, string fa_MainActivity, string fa_Size, string fa_ActivityType, string fa_Ownership, string fa_LegalEntity, string fa_Mode, string fa_Governorate)
        {

            List<Facility> facilities  = new List<Facility>();
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Requests_reports"] = " يرجئ التاكد من انك قمت بتعبئة كافة الحقول ";
                    return RedirectToAction(nameof(Index));




                }

                else
                {
                    if (!string.IsNullOrEmpty(fa_Name) && fa_Number != 0 && !string.IsNullOrEmpty(fa_OwnerName) && !string.IsNullOrEmpty(fa_MainActivity) && !string.IsNullOrEmpty(fa_Size) && !string.IsNullOrEmpty(fa_ActivityType) && !string.IsNullOrEmpty(fa_Ownership) && !string.IsNullOrEmpty(fa_LegalEntity) && !string.IsNullOrEmpty(fa_Mode) && !string.IsNullOrEmpty(fa_Governorate))
                    {

                         facilities = _context.Facilities.Where(s => s.FaName == (fa_Name) && s.FaNumber.Equals(fa_Number) && s.FaOwnerName.Equals(fa_OwnerName) && s.FaMainActivity.Equals(fa_MainActivity) && s.FaSize.Equals(fa_Size) && s.FaActivityType.Equals(fa_ActivityType) && s.FaOwnership.Equals(fa_Ownership) && s.FaLegalEntity.Equals(fa_LegalEntity) && s.FaMode.Equals(fa_Mode) && s.FaGovernorate.Equals(fa_Governorate) && s.IsDeleted.Equals(false)).ToList();



                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exp: In Post FacilityMainData Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }

            return View(facilities);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
