using System.ComponentModel.DataAnnotations;

namespace First_Website_Challenge.Models.Entity
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string Address { get; set; } = "";

    }
}
