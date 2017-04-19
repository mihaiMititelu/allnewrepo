using System.ComponentModel.DataAnnotations;

namespace DungeonMaster.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campul este obligatoriu")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campul este obligatoriu")]
        public string Password { get; set; }
    }
}