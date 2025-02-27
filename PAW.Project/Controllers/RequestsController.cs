using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Data.Models;
using System;

namespace PAW.Project.Controllers
{
    public class RequestsController : Controller
    {
        private readonly OfficeRequestBusiness _officeRequestBusiness;

        public RequestsController(OfficeRequestBusiness officeRequestBusiness)
        {
            _officeRequestBusiness = officeRequestBusiness;
        }

        public IActionResult Index(string status)
        {
            IEnumerable<OfficeRequest> requests;

            if (string.IsNullOrEmpty(status))
            {
                requests = _officeRequestBusiness.GetRequestsOrderedByPriority();
            }
            else
            {
                requests = _officeRequestBusiness.GetRequestsByStatus(status);
            }

            return View(requests);
        }

        [HttpPost]
        public IActionResult CompleteRequest(int id, string detailText)
        {
            if (string.IsNullOrWhiteSpace(detailText))
            {
                TempData["ErrorMessage"] = "El texto del detalle no puede estar vacío.";
                return RedirectToAction("Index");
            }

            _officeRequestBusiness.CompleteRequest(id, new OfficeRequestDetail
            {
                RequestId = id,
                DetailType = "Update",
                DetailText = detailText,
                AddedBy = "System",
                AddedDate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddDetail(int requestId, string detailText, string detailType)
        {
            var allowedDetailTypes = new[] { "Follow-up", "Update", "Comment" };
            if (!allowedDetailTypes.Contains(detailType))
            {
                TempData["ErrorMessage"] = "El tipo de detalle no es válido. Use 'Follow-up', 'Update' o 'Comment'.";
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(detailText))
            {
                TempData["ErrorMessage"] = "El texto del detalle no puede estar vacío.";
                return RedirectToAction("Index");
            }

            try
            {
                _officeRequestBusiness.AddDetailToRequest(new OfficeRequestDetail
                {
                    RequestId = requestId,
                    DetailType = detailType,
                    DetailText = detailText,
                    AddedBy = "User",
                    AddedDate = DateTime.Now
                });
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OfficeRequest request)
        {
            if (ModelState.IsValid)
            {
                _officeRequestBusiness.CreateRequest(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _officeRequestBusiness.DeleteRequest(id);
            return RedirectToAction("Index");
        }
    }
}