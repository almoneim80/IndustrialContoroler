using IndustrialContoroler.Constants;
using IndustrialContoroler.IRepository.RepositoryFildform;
using IndustrialContoroler.Models;
using IndustrialContoroler.Models.Repositories;
using IndustrialContoroler.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialContoroler.Controllers.Requests
{
    [Authorize(Permissions.WorkFlowRequest.View)]
    public class WorkFlowRequestController : Controller
    {
        private readonly IServiceREpositoryRequest<Request> _servicesRequest;
        private readonly IServicesRepositoryLogRequeist<RequestTraffic> _servicesRequestLog;

        private readonly UserManager<AppUsers> _userManager;
        private readonly IHttpContextAccessor _sesstion;
        private readonly IServiceRepositoryFieldVisitForms<Facility> _serviceRepositoryFieldVisit;
        private readonly IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms> _repositoryLogFieldVisitForms;

        public WorkFlowRequestController(IServiceREpositoryRequest<Request> servicesRequest,
            IServicesRepositoryLogRequeist<RequestTraffic> servicesRequestLog,
            UserManager<AppUsers> userManager, IHttpContextAccessor sesstion,
             IServiceRepositoryFieldVisitForms<Facility> serviceRepositoryFieldVisit,
            IServicesRepositoryLogFieldVisitForms<LogFieldVisitForms> repositoryLogFieldVisitForms)
        {
            _servicesRequest = servicesRequest;
            _servicesRequestLog = servicesRequestLog;
            _userManager = userManager;
            _sesstion = sesstion;
            _serviceRepositoryFieldVisit = serviceRepositoryFieldVisit;
            _repositoryLogFieldVisitForms = repositoryLogFieldVisitForms;
        }
        [Authorize(Permissions.WorkFlowRequest.View)]
        public IActionResult Index()        
        {
            return View(new Logsystem
            {
               Requests=_servicesRequest.GetAll(),
               RequestTraffics=_servicesRequestLog.GetAll(),
                Facility = _serviceRepositoryFieldVisit.GetAll(),
                LogFieldVisitForms = _repositoryLogFieldVisitForms.GetAll(),
                facility = new Facility(),
                requests =new Request()
                    
            });
        }


        //Delete log
        [Authorize(Permissions.WorkFlowRequest.Delete)]
        public IActionResult DeleteLog(int Id)
        {
            if (_servicesRequestLog.DeleteLog(Id))
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Permissions.WorkFlowRequest.Delete)]
        public IActionResult DeleteLogFiled(int Id)
        {
            if (_repositoryLogFieldVisitForms.DeleteLog(Id))
                return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index));
        }

    }
}
