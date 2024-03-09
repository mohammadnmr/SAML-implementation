using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using saml_integration_test.Models;
using System.Diagnostics;

namespace saml_integration_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("cookie");
            RedirectToAction("Details");
            return SignOut("cookie", "saml2");
        }


        [Route("/sign-in")]
        [Authorize]
        public IActionResult SignIn()
        {
            return Redirect("/");
        }

        [Route("/sign-out")]
        public IActionResult FullLogout()
        {
            
            return SignOut("cookie", "saml2");
        }

        //[Route("/app-sign-out")]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync("cookie");
        //    return Redirect("/");
        //}
    }
}
