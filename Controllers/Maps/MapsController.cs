using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using IndustrialContoroler.Models.MapsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndustrialContoroler.Controllers
{
    [Authorize(Permissions.Maps.View)]
    public class MapsController : Controller
    {
        public IndustrialContorolerDatabaseContext _context;
        public MapsController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;
        }



        [HttpPost]
        public IActionResult Index(string fa_Name, int fa_Number)
        {


            List<Facility> facilities = new List<Facility>();

            List<MapsVM> mapsVM = new List<MapsVM>();

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = " يرجئ التاكد من انك قمت بتعبئة كافة الحقول ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (!string.IsNullOrEmpty(fa_Name) && fa_Number != 0)
                    {
                        TempData["Maps_fa_Name"] = fa_Name;

                        facilities = _context.Facilities.Where(s => s.FaName == (fa_Name) && s.FaNumber.Equals(fa_Number) && s.IsDeleted.Equals(false)).ToList();


                    }


                    foreach (var item in facilities)
                    {

                        mapsVM.Add(new MapsVM(item.FaName, item.FaLongitude.ToString(), item.FaLatitude.ToString(), item.FaAddress));

                    }
                    ViewBag.mapsVM = JsonConvert.SerializeObject(mapsVM);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exp: In Post FacilityMainData Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }


            return View(mapsVM);


        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Index2()
        {

            return View();
        }
    }
}
