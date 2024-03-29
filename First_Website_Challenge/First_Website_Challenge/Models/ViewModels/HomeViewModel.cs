namespace First_Website_Challenge.Models.ViewModels
{
    public class HomeViewModel
    {
        public string Name { get; set; }

        public string Role { get; set; }
        public string Tagline { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }
    }

}







