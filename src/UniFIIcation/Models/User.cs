using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UniFIIcation.Models
{
    public class User : IdentityUser
    {
        public string Nume { get; set; }

        public override string UserName { get; set; }

        public string Prenume { get; set; }

        public string Password { get; set; }

        public int An { get; set; }

        public int TipCont { get; set; }
    }
}
