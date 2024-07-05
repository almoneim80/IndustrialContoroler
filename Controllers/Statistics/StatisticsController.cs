using IndustrialContoroler.Constants;
using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndustrialContoroler.Controllers
{

    [Authorize(Permissions.Statistics.View)]
    public class StatisticsController : Controller
    {

        public IndustrialContorolerDatabaseContext _context;



        public StatisticsController(IndustrialContorolerDatabaseContext context)
        {
            _context = context;

        }


        //Statistics
        [HttpPost]
        public IActionResult Index(int select_statistic_send, string fac_size, string search_1, string search_2 , DateTime FaStart)
        {
            VewStatistics statistics = new();

            statistics.statistic_num = select_statistic_send; 

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Requests_Statistic"] = " يرجئ التاكد من انك قمت بتعبئة كافة الحقول ";
                    return RedirectToAction(nameof(Index));



              
                }
              
                else
                {

                    switch (select_statistic_send)
                    {

                        case 1: // توزيع المنشآت الصناعية بحسب النشاط وحجم الاستثمار//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط وحجم الاستثمار";


                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaShareCapital.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 2: // توزيع المنشآت الصناعية بحسب النشاط والمحافظة//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط والمحافظة";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaGovernorate.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 3: // توزيع المنشآت الصناعية بحسب النشاط وقطاع الملكية//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط وقطاع الملكية";


                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaOwnership.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 4: // توزيع المنشآت الصناعية بحسب النشاط والكيان القانون//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط والكيان القانون";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaLegalEntity.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }


                            };
                            break;

                        case 5: // توزيع المنشآت الصناعية بحسب النشاط ووضع المنشأة ///Done
                            { //وضع المنشأة
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط ووضع المنشأة";
                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 6: // توزيع المنشآت الصناعية بحسب النشاط وراس المال المصرح//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط وراس المال المصرح";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaShareCapital.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }




                            };
                            break;



                        case 8: // توزيع المنشآت الصناعية بحسب النشاط والمساحة//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط والمساحة";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.FaTotalArea.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }




                            };
                            break;

                        case 9: // توزيع المنشآت الصناعية بحسب الزمن المخطط لعملية الانتاج في المنشآة علئ مستوئ الانشطة الاقتصادية //Done
                                {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب الزمن المخطط لعملية الانتاج في المنشآة علئ مستوئ الانشطة الاقتصادية";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {



                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaStartProduction.Equals(FaStart) && s.FaMainActivity.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                }

                            };
                            break;

                        case 10: // توزيع المنشآت الصناعية بحسب النشاط الاقتصادي وسبب اختيار موقع المنشآة //Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب النشاط الاقتصادي وسبب اختيار موقع المنشآة";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {



                                 
                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaMainActivity.Equals(search_1) && s.IsDeleted.Equals(false)).ToList();

                                    List<SiteReason> siteReasons = _context.SiteReasons.Where(s => s.SrReason.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();

                                    statistics.facility = facilities;

                                    statistics.SiteReason = siteReasons;

                                    

                                }


                            };
                            break;



                        case 13: // توزيع المنشآت الصناعية بحسب الكيان القانوني والمحافظة//Done
                            {
                                TempData["statistic_by"] = "توزيع المنشآت الصناعية بحسب الكيان القانوني والمحافظة";


                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.FaLegalEntity.Equals(search_1) && s.FaGovernorate.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();


                                    statistics.facility = facilities;

                                    statistics.facility = facilities;

                                }


                            };
                            break;


                        case 14: // الانتاج والمبيعات خلال العام للمنشآت الصناعية بحسب السلعة//Done
                            {
                                TempData["statistic_by"] = "الانتاج والمبيعات خلال العام للمنشآت الصناعية بحسب السلعة";

                                if (!string.IsNullOrEmpty(fac_size) && !string.IsNullOrEmpty(search_1) && !string.IsNullOrEmpty(search_2))
                                {

                                    List<Facility> facilities = _context.Facilities.Where(s => s.FaSize == (fac_size) && s.IsDeleted.Equals(false)).ToList();

                                    List<ProCapacity> proCapacity = _context.ProCapacities.Where(s => s.PcYearQuantity.Equals(search_1) && s.PcProductName.Equals(search_2) && s.IsDeleted.Equals(false)).ToList();

                                    statistics.ProCapacity = proCapacity;

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
        public IActionResult Index()
        {
            return View();
        }



        //PrintStatistics

        public IActionResult Print()
        {

            return View();
        }





    }
}
