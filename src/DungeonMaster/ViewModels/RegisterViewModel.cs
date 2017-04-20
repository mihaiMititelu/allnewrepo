using System.ComponentModel.DataAnnotations;

namespace DungeonMaster.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required!")]
        [MinLength(6, ErrorMessage = "Password should be longer than 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}