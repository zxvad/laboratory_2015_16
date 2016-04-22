using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerReports.Web.Controllers
{
    public class HomeController : Controller
    {
        public const string Name = "home";

        public const string DefaultAction = "index";
        public const string ErrorAction = "error";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ActionName(DefaultAction)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName(ErrorAction)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError("An unhandled exception has occurred: ", feature.Error.Message);
            return View();
        }
    }
}