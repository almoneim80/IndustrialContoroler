using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;

namespace IndustrialContoroler.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        public IndustrialContorolerDatabaseContext _context;

        public HomeController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;

        }



        //الصفحة الرئيسية للرسوم البيانية
        
        public IActionResult Index()
        {

            try
            {
                ///////////////////////////رسم بياني للمحافظات///////////////////////////     

                List<VewCharts> govermentdata = new List<VewCharts>();

                var data1 = _context.Facilities
                  .GroupBy(_ => _.FaGovernorate)
                  .Select(g => new
                  {
                      Name = g.Key,
                      Count = g.Count()
                  })
                  .OrderByDescending(cp => cp.Count)
                  .ToList();

                foreach (var item in data1)
                {

                    govermentdata.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.VewGoverment = JsonConvert.SerializeObject(govermentdata);



                /////////////////////////////////رسم بياني للطلبات ///////////////////////

                List<VewCharts> requstdata = new List<VewCharts>();

                var data2 = _context.Requests
                  .GroupBy(_ => _.ReType)
                  .Select(g => new
                  {
                      Name = g.Key,
                      Count = g.Count()
                  })
                  .OrderByDescending(cp => cp.Count)
                  .ToList();

                foreach (var item in data2)
                {

                    requstdata.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.VewRequst = JsonConvert.SerializeObject(requstdata);




                /////////////////////////////////رسم بياني لوضع المنشأة ///////////////////////

                List<VewCharts> modesdata = new List<VewCharts>();

                var data3 = _context.Facilities
                  .GroupBy(_ => _.FaMode)
                  .Select(g => new
                  {
                      Name = g.Key,
                      Count = g.Count()
                  })
                  .OrderByDescending(cp => cp.Count)
                  .ToList();

                foreach (var item in data3)
                {

                    modesdata.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.VewMode = JsonConvert.SerializeObject(modesdata);




                return View();


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exp: In Post FacilityMainData Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction("Index");
            }


        }



        public IActionResult Requsets()
        {
            return View();

        }

        public IActionResult userManagement()
        {
            return View();
        }

        public IActionResult Permissions()
        {
            return View();
        }

        public IActionResult fieldVisits()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        //facility data
        public IActionResult facilityMainData()
        {
            return View();
        }

        public IActionResult facilityLocationAndContactData()
        {
            return View();
        }

        public IActionResult facilityBuildings()
        {
            return View();
        }

        public IActionResult facilityWorkers()
        {
            return View();
        }

        public IActionResult facilityMachines()
        {
            return View();
        }

        public IActionResult facilityRawMaterial()
        {
            return View();
        }

        public IActionResult facilityHelpMaterial()
        {
            return View();
        }

        public IActionResult facilityTransportation()
        {
            return View();
        }
        public IActionResult facilityPointOfSale()
        {
            return View();
        }

        public IActionResult facilityProductionCapacity()
        {
            return View();
        }

        public IActionResult facilitySafety()
        {
            return View();
        }

        public IActionResult facilityDataCaster()
        {
            return View();
        }

        public IActionResult facilityRelevantDocuments()
        {
            return View();
        }

        public IActionResult facilityAnotherDate()
        {
            return View();
        }


        //sreach

        public IActionResult searchIndustrialSurvey()
        {
            return View();
        }

        public IActionResult searchByFacilityName()
        {
            return View();
        }



        //Maps

        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult showMap()
        {
            return View();
        }


        //Notification

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult addNotification()
        {
            return View();
        }

        //reports

        public IActionResult reportModel1()
        {
            return View();
        }


        public IActionResult reportModel3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}