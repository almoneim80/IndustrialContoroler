//using DevExtreme.AspNet.Data;
using IndustrialContoroler.Constants;
using IndustrialContoroler.VewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndustrialContoroler.Models
{
    [Authorize(Permissions.Charts.View)]
    public class ChartsController : Controller
    {

        public IndustrialContorolerDatabaseContext _context;

        public ChartsController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;

        }

   
        public IActionResult char1()
        {

            try
            {
                ///////////////////////////رسم بياني للمحافظات///////////////////////////     

                List<VewCharts> Index1 = new List<VewCharts>();

                var data1 = _context.Facilities.Where(x => x.IsDeleted.Equals(false)).GroupBy(x => x.FaGovernorate).Select(x => new { Name = x.Key, Count = x.Count() }).OrderByDescending(cp => cp.Count).ToList();

                foreach (var item in data1)
                {

                    Index1.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.Index1 = JsonConvert.SerializeObject(Index1);





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





        public IActionResult char2()
        {


            try
            {
              


                /////////////////////////////////رسم بياني للطلبات ///////////////////////

                List<VewCharts> Index2 = new List<VewCharts>();

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

                    Index2.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.Index2 = JsonConvert.SerializeObject(Index2);




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

        public IActionResult char3()
        {
            try
            {


                /////////////////////////////////رسم بياني لوضع المنشأة ///////////////////////

                List<VewCharts> Index3 = new List<VewCharts>();

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

                    Index3.Add(new VewCharts(item.Name, item.Count));
                }


                ViewBag.Index3 = JsonConvert.SerializeObject(Index3);




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


    }

   
}
