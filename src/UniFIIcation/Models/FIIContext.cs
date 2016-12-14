using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UniFIIcation.Models
{
    public class FIIContext : IdentityDbContext<User>
    {
        public FIIContext()
        {
                
        }
    }
}
