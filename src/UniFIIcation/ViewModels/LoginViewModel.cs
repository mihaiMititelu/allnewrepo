using System.ComponentModel.DataAnnotations;

namespace DungeonMaster.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Field is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Field is required!")]
        public string Password { get; set; }
    }
}