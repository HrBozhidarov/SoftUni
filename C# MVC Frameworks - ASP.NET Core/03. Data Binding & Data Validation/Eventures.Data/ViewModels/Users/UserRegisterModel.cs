using System.ComponentModel.DataAnnotations;

namespace Eventures.Data.ViewModels.Users
{
    public class UserRegisterModel
    {
        [Required]
        [RegularExpression("[A-Za-z._0-9~*-]{3,}")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^([0-9]{10})$")]
        public string UCN { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\S{5,}$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
