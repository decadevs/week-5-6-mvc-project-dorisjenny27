using System.ComponentModel.DataAnnotations;

namespace First_Website_Challenge.Models.ViewModels
{
    public class WorkExperienceViewModel
    {
        public string Id { get; set; }
        public string JobTitle { get; set; }

        public string Organization { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Achievements { get; set; }
    }
}
