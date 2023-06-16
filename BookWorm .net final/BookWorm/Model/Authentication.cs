using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class Authentication
    {
        public int AuthenticationId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
        [Required]

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string? Password { get; set; }
        public int CustomerId { get; set; }

        public CustomerMaster? Customer { get; set; }

    }
}
