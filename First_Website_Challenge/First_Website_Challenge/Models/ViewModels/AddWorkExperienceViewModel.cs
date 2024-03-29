using System.ComponentModel.DataAnnotations;

namespace First_Website_Challenge.Models.ViewModels
{
    public class AddWorkExperienceViewModel
    {
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Organization { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string Achievements { get; set; }
    }
}
