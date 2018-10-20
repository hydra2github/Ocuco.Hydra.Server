using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.MailService;
using Ocuco.Hydra.WebMVC21.V2.ViewModels;
using System.IO;

namespace Ocuco.Hydra.WebMVC21.V2.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AppController : Controller
    {
        private readonly ILogger<AppController> logger;
        private readonly IMailService mailService;

        public AppController(ILogger<AppController> logger,
                              IMailService mailService)
        {
            this.logger = logger;
            this.mailService = mailService;
        }


        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/LandingPage", "index.html"), "text/HTML");
            //return View();
        }


        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            //throw new InvalidOperationException("Bad things");

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                mailService.SendMessage("daniel.tassi@ocuco.com", model.Subject, $"From: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // Show the errors
            }
            return View();
        }
    }
}
