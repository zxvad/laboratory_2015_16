using System.DirectoryServices.AccountManagement;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ManagerReports.Web.ViewModels.Models;
using Microsoft.Extensions.Logging;

namespace ManagerReports.Web.Controllers
{
    public class AccountController : Controller
    {
        public const string Name = "account";

        public const string LoginAction = "login";
        public const string LogoffAction = "logoff";

        private readonly IConfigurationRoot _configuration;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IConfigurationRoot configuration, ILogger<AccountController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [ActionName(LoginAction)]
        public ActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(LoginAction)]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToLocal(returnUrl);
            }

            ViewData["ReturnUrl"] = returnUrl;

            bool loginSuccessful = ModelState.IsValid && TryAuthauthenticateUser(model.Login, model.Password);

            if (!loginSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Отказано в доступе");
                _logger.LogWarning($"Failed to login {model.Login}");
                return View();
            }

            var identity = new ClaimsIdentity(new[] {new Claim("sub", model.Login)}, "local", "name", "role");
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(identity));
            _logger.LogInformation($"Login successful {model.Login}");

            return RedirectToLocal(returnUrl);
        }

        [Authorize]
        [ActionName(LogoffAction)]
        public IActionResult Logoff()
        {
            _logger.LogInformation($"Logoff {HttpContext.User.Identity.Name}");
            return RedirectToAction(HomeController.DefaultAction, HomeController.Name);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(HomeController.DefaultAction, HomeController.Name);
        }

        private bool IsTrustedUser(string userName)
        {
            return _configuration["LDAP:TrustedUsers"].Split(',').Contains(userName);
        }

        private bool TryAuthauthenticateUser(string login, string password)
        {
            if (!IsTrustedUser(login))
            {
                return false;
            }

            var domain = _configuration["LDAP:Domain"];
            var options = _configuration["LDAP:Options"];

            using (var context = new PrincipalContext(ContextType.Domain, domain, options))
            {
                return context.ValidateCredentials(login, password);
            }
        }
    }
}