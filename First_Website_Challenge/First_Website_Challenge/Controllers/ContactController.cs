using First_Website_Challenge.Data;
using First_Website_Challenge.Models.ViewModels;
using First_Website_Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace First_Website_Challenge.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
                //  ModelState.Clear();

                await _emailService.SendEmail("Contact Email", model.Subject, model.Email, model.Message);
                ViewData["SuccessMessage"] = "Your message has been sent successfully!";

                return RedirectToAction("Index", "Home");


        }

    }
}

