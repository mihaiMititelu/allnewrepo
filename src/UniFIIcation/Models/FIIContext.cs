﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UniFIIcation.Models
{
    public class FIIContext : IdentityDbContext<User>
    {
        public FIIContext()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = EFGetStarted.AspNetCore.NewDb; Trusted_Connection = True;");
        }
    }
}