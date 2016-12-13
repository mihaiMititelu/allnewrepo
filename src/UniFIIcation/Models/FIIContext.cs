using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UniFIIcation.Models
{
    public class FIIContext : IdentityDbContext<User>
    {
        public FIIContext()
        {
                
        }
    }
}
