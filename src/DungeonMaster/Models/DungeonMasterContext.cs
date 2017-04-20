using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DungeonMaster.Models
{
    public class DungeonMasterContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\mssqllocaldb; Database = EFGetStarted.AspNetCore.NewDb; Trusted_Connection = True;");
        }
    }
}