using Microsoft.EntityFrameworkCore;

namespace ProiectDeTest8.Models
{
    public class MatContext : DbContext
    {
        public MatContext(DbContextOptions<MatContext> options)
            : base(options)
        { }

        public DbSet<Materie> Materii { get; set; }
        public DbSet<Postare> Postari { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
