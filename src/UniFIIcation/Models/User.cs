using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DungeonMaster.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public string TimeZone { get; set; }

        public string Password { get; set; }

    }
}