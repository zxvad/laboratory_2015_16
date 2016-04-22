using ManagerReports.Web.ViewModels.Models;
using Microsoft.AspNet.Mvc;

namespace ManagerReports.Web.ViewComponents
{
    public class PaymentsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PaymentModel payment)
        {
            return View("_Payments", payment);
        }
    }
}