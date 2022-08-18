using BugTracker.Identity.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Identity.Controlles
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, 
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }

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
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.FindByNameAsync(viewModel.Email);

            if(user == null)
            {
                ModelState.AddModelError(String.Empty, "User is not found.");
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, 
                viewModel.Password, false, false);

            if (result.Succeeded)
                return Redirect(viewModel.ReturnUrl);

            ModelState.AddModelError(string.Empty, "Login error are occurred.");

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = new User
            {
                Email = viewModel.Email,
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect("/");
            }

            ModelState.AddModelError(string.Empty, "Register error are occurred.");

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
