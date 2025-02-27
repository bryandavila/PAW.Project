using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Model;

namespace PAW.Project.Controllers
{
    public class RequestsController : Controller
    {
        private readonly OfficeRequestBusiness _officeRequestBusiness;

        public RequestsController(OfficeRequestBusiness officeRequestBusiness)
        {
            _officeRequestBusiness = officeRequestBusiness;
        }

        public IActionResult Index()
        {
            var requests = _officeRequestBusiness.GetRequestsByStatus("Pending");
            return View(requests);
        }
    }
}