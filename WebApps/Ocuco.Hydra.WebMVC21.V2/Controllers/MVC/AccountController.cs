using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.DataModel.Hydradbsecurity.Entities;
using Ocuco.Hydra.WebMVC21.V2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers.MVC
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<HubUser> signInManager;

        public AccountController(ILogger<AccountController> logger,
                                 SignInManager<HubUser> signInManager)
        {
            this.logger = logger;
            this.signInManager = signInManager;
        }


        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "LuxRxoUI");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username,
                                                                     model.Password,
                                                                     model.RememberMe,
                                                                     false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        RedirectToAction(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        RedirectToAction("AuditDashboard", "LuxRxoUI");
                    }
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "LuxRxoUI");
        }
    }
}
