using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DungeonMaster.Models
{
    public class User : IdentityUser
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}