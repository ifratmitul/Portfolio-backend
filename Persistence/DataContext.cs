using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Education> Schools { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        // public DbSet<Skill> Skills { get; set; }
        // public DbSet<Profile> Profiles { get; set; }
    }
}