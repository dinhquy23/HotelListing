using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class UserDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
