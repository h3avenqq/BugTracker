using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Identity.Controlles
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
