using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Password1 { get; set; }

        public int An { get; set; }

        [Required]
        public int TipCont { get; set; }
    }
}
