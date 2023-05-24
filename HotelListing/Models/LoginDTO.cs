using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limitted to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
