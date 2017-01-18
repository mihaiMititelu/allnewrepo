using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [MinLength(6, ErrorMessage = "Parola trebuie sa fie de minim 6 caractere")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Câmp obligatoriu")]
        [Compare("Password", ErrorMessage = "Parolele nu se potrivesc")]
        public string Password1 { get; set; }

        public int An { get; set; }

        [Required(ErrorMessage = "Selectați o opțiune")]
        public int TipCont { get; set; }
    }
}