using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppAdmin>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Education> Schools { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Photo> Photos { get; set; }
        // public DbSet<Project> Projects { get; set; }
        public DbSet<MyProfile> Profiles { get; set; }
        public DbSet<Experience> Experiences { get; set; }

    }
}
