using System.ComponentModel.DataAnnotations;

namespace First_Website_Challenge.Models.Entity
{
    public class WorkExperience
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Organization { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string Achievements { get; set; } =  "";
        public string StartDate { get; set; } =  "";
        public string EndDate { get; set; } =  "";

    }
}
