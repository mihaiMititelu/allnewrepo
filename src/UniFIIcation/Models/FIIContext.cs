﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewWebSite.Models;

namespace UniFIIcation.Models
{
    public class FIIContext : IdentityDbContext<User>
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\mssqllocaldb; Database = EFGetStarted.AspNetCore.NewDb; Trusted_Connection = True;");
        }
    }
}