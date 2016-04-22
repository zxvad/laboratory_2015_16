using System;
using ManagerReports.Services.Interfaces;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace ManagerReports.Web.Controllers
{
    public class PaymentsController : Controller
    {
        public const string Name = "payments";

        public const string AddPaymentAction = "add-payment";
        public const string RemovePaymentAction = "remove-payment";
        public const string PaymentTemplateAction = "payment-template";

        private readonly IPaymentService _paymentService;
        private readonly IProjectService _projectService;

        public PaymentsController(IPaymentService paymentService, IProjectService projectService)
        {
            _paymentService = paymentService;
            _projectService = projectService;
        }

        [HttpPost]
        [ActionName(AddPaymentAction)]
        public IActionResult AddPayment(Guid paymentId, decimal amount, string date, int? projectVersionId = null)
        {
            try
            {
                DateTime parsedDate;
                if (!DateTime.TryParse(date, out parsedDate))
                {
                    parsedDate = DateTime.Now;
                }

                _paymentService.Update(paymentId, projectVersionId, parsedDate, amount);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = string.Concat(ex.Message, ':', ex.InnerException?.Message)
                });
            }
        }

        [HttpPost]
        [ActionName(RemovePaymentAction)]
        public IActionResult RemovePayment(Guid paymentId)
        {
            try
            {
                _paymentService.Remove(paymentId);
                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = string.Concat(ex.Message, ':', ex.InnerException?.Message)
                });
            }
        }

        [HttpPost]
        [ActionName(PaymentTemplateAction)]
        public IActionResult PaymentTemplate(Guid projectId)
        {
            try
            {
                var versions = _projectService.GetAllVersions(projectId).Select(i => new
                {
                    id = i.Item1,
                    name = i.Item2
                }).ToArray();

                var paymentRecord = _paymentService.Add(projectId, null, DateTime.Now, 0);

                return Json(new
                {
                    success = true,
                    date = DateTime.Now.ToShortDateString(),
                    versions = JsonConvert.SerializeObject(versions),
                    paymentId = paymentRecord.Id
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = string.Concat(ex.Message, ' ', ex.InnerException?.Message)
                });
            }
        }
    }
}