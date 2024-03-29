using First_Website_Challenge.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First_Website_Challenge.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHomepage(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the uploaded image
                if (model.Image != null && model.Image.Length > 0)
                {
                    var imagePath = Path.Combine("wwwroot", "images", model.Image.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }
                    model.ImagePath = $"/images/{model.Image.FileName}";
                }

                // Here you can save other details to the database or perform any other necessary actions

                return View("HomePage", model);
            }
            // If the model state is not valid, return to the create homepage view to display validation errors
            return View("CreateHomepage", model);
        }

        public IActionResult HomePage(HomeViewModel model)
        {
            return View(model);
        }
    }
}

