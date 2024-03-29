using First_Website_Challenge.Data;
using First_Website_Challenge.Models.Entity;
using First_Website_Challenge.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First_Website_Challenge.Controllers
{
    public class ProfileController : Controller
    {
        private readonly MyDbContext _ctx;
        public ProfileController(MyDbContext ctx)
        {
            _ctx = ctx;

        }
        
        [HttpGet]
        public IActionResult Index()
        {
            List<WorkExperienceViewModel> WorkExperiences = new List<WorkExperienceViewModel>();

            var workExperiences = _ctx.WorkExperiences;
            if (workExperiences != null)
            {
                WorkExperiences = workExperiences.Select(workExperience => new WorkExperienceViewModel
                {
                    Id = workExperience.Id,
                    JobTitle = workExperience.JobTitle,
                    Organization = workExperience.Organization,
                    StartDate = workExperience.StartDate,
                    EndDate = workExperience.EndDate,
                    Achievements = workExperience.Achievements,

                }).OrderByDescending(w => w.StartDate).ToList();
            }
                var viewModel = new ProfileViewModel
                {
                    WorkExperiences = WorkExperiences
                };

                return View(viewModel);

        }

        [HttpGet]
        public IActionResult AddWorkExperience()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddWorkExperience(AddWorkExperienceViewModel model)
        {
            var workExperience = _ctx.WorkExperiences;
            if (ModelState.IsValid)
            {
                var newWorkExperience = new WorkExperience
                {
                    JobTitle = model.JobTitle,
                    Organization = model.Organization,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Achievements = model.Achievements,
                };

                workExperience.Add(newWorkExperience);
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult UpdateWorkExperience(string id)
        {
            var workExperiences = _ctx.WorkExperiences;
            var workExperience = _ctx.WorkExperiences.FirstOrDefault(x => x.Id == id);
            UpdateWorkExperienceViewModel viewModel = new UpdateWorkExperienceViewModel()
            {
                JobTitle = workExperience.JobTitle,
                Organization = workExperience.Organization,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate,
                Achievements = workExperience.Achievements
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult UpdateWorkExperience(string id, UpdateWorkExperienceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the view with validation errors
                return View(model);
            }

            var workExperience = _ctx.WorkExperiences.FirstOrDefault(x => x.Id == id);

            if (workExperience != null)
            {
                workExperience.JobTitle = model.JobTitle;
                workExperience.Organization = model.Organization;
                workExperience.StartDate = model.StartDate;
                workExperience.EndDate = model.EndDate;
                workExperience.Achievements = model.Achievements;

                _ctx.WorkExperiences.Update(workExperience);
                _ctx.SaveChanges();
            }

            // You should redirect to the index action after updating the work experience
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteWorkExperience(string id)
        {
            var workExperience = _ctx.WorkExperiences.FirstOrDefault(x => x.Id == id);

            if(workExperience != null)
            {
                _ctx.Remove(workExperience);
                _ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       

        /*[HttpGet]
        public IActionResult Index() 
        {
          
            var workExperiences = _ctx.WorkExperiences;
 
              var viewModel = workExperiences.OrderByDescending(x => new WorkExperienceViewModel
                {
                    JobTitle = x.JobTitle,
                    Organization = x.Organization,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Achievements = x.Achievements,

                }).ToList();
           
            return View(viewModel);
        }

  
  

        public IActionResult Delete(int Id)
        {
            var work = _ctx.WorkExperiences;
            if (work != null)
            {
                var workFound = work.FirstOrDefault(x => x.Id == Id);
                _ctx.Remove(workFound);
                _ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, WorkExperienceViewModel model)
        {

            var work = _ctx.WorkExperiences;
            if (work != null && work.Any(x => x.Id == id))
            {
                var workFound = work.First(x => x.Id == id);
                if (workFound != null)
                {
                    workFound.JobTitle = model.JobTitle;
                    workFound.Organization = model.Organization;
                    workFound.EndDate = model.EndDate;
                    workFound.StartDate = model.StartDate;
                    workFound.Achievements = model.Achievements;

                    work.Update(workFound);
                    _ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(WorkExperienceViewModel model)
        {
            return View(model);
        }*/

    }
}

