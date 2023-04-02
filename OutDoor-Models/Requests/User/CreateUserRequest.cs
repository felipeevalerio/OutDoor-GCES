using OutDoor_Models.Models;
using System.ComponentModel.DataAnnotations;

namespace OutDoor_Models.Requests.User
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public UserTypes UserType { get; set; }
    }
}
