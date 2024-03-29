using System.ComponentModel.DataAnnotations;

namespace First_Website_Challenge.Models.ViewModels
{
    public class ContactViewModel
    {
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string SenderEmail { get; set; }
    }
}




