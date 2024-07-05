using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndustrialContoroler.Controllers.Search
{
    [Authorize(Permissions.Search.View)]
    public class SearchController : Controller
    {

        public IndustrialContorolerDatabaseContext _context;



        public SearchController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;

        }

        //\\\\\\\\\\\\\\\\/////////////////\\\\\\\\\\\\\\//////////////// Search //////////////\\\/////////// Free ///////////////\\\\\\\\\/////////\\\\\\\\\//////\\\\\/\\\\\\\/\//

        [HttpPost]
        public IActionResult FreeSearch(int select_statistic_send,  string search)
        {
            VewStatistics statistics = new();

            statistics.statistic_num = select_statistic_send;

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = " يرجى التأكد من تعبئة كافة الحقول ";
                    return RedirectToAction(nameof(Index));
                }

                else
                {

                    switch (select_statistic_send)
                    {

                        case 1: 
                            {
                                TempData["statistic_by"] = "  بحث بحسب النشاط  ";


                                if (!string.IsNullOrEmpty(search))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s =>  s.FaMainActivity.Equals(search) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 2:
                            {
                                TempData["statistic_by"] = "  بحث نوع النشاط  ";


                                if (!string.IsNullOrEmpty(search))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaActivityType.Equals(search) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 3:
                            {
                                TempData["statistic_by"] = "  بحث وضع النشاط  ";


                                if (!string.IsNullOrEmpty(search))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaMode.Equals(search) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 4:
                            {
                                TempData["statistic_by"] = "  بحث حجم النشاط  ";


                                if (!string.IsNullOrEmpty(search))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize.Equals(search) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 5:
                            {
                                TempData["statistic_by"] = " الكيان القاوني  ";


                                if (!string.IsNullOrEmpty(search))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaLegalEntity.Equals(search) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;



                        default:
                            {
                                return View();
                            };

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
            return View(statistics);
        }
        [HttpGet]
        public IActionResult FreeSearch()
        {
            return View();
        }





        /**************************************************** (Post) Function for Search in Econmic Facilitys **********************************************/
        //Statistics
        [HttpPost]
        public IActionResult SearchEco(string fa_Name, int fa_Number, string fa_MainActivity, string fa_LegalEntity, string fa_Governorate)
        {
            List<Facility> facilities2 = new List<Facility>();
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = " يرجئ التاكد من انك قمت بتعبئة كافة الحقول ";
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    if (!string.IsNullOrEmpty(fa_Name) && fa_Number != 0  && !string.IsNullOrEmpty(fa_MainActivity) && !string.IsNullOrEmpty(fa_LegalEntity) && !string.IsNullOrEmpty(fa_Governorate) && !string.IsNullOrEmpty(fa_Governorate))
                    {

                        facilities2 = _context.Facilities.Where(s => s.FaName == (fa_Name) && s.FaNumber.Equals(fa_Number)  && s.FaMainActivity.Equals(fa_MainActivity) &&  s.FaLegalEntity.Equals(fa_LegalEntity) && s.FaGovernorate.Equals(fa_Governorate) && s.IsDeleted.Equals(false)).ToList();



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

            return View(facilities2);
        }
        /**************************************************** (Get) Function for Search in  Industrial Facilitys **********************************************/

        [HttpGet]
        public IActionResult SearchEco()
        {
            return View();
        }


        //\\\\\\\\\\\\\\\\/////////////////\\\\\\\\\\\\\\//////////////// Search //////////////\\\/////////// Econmic ///////////////\\\\\\\\\/////////\\\\\\\\\//////\\\\\/\\\\\\\/\//



        /**************************************************** (Post) Function for Search in Industrial Facilitys **********************************************/

        //Statistics
        [HttpPost]
        public IActionResult SearchInd(string fa_Name, int fa_Number, string fa_OwnerName, string fa_MainActivity, string fa_Size, string fa_ActivityType, string fa_Ownership, string fa_LegalEntity, string fa_Mode, string fa_Governorate)
        {
            List<Facility> facilities = new List<Facility>();
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = " يرجئ التاكد من انك قمت بتعبئة كافة الحقول ";
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


        /**************************************************** (Get) Function for Search in Industrial Facilitys **********************************************/
        [HttpGet]
        public IActionResult SearchInd()
        {
            return View();
        }



    }
}
