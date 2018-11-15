using System.ComponentModel.DataAnnotations;

namespace Chushka.Models.ViewModels.Users
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
