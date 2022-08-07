using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using BugTracker.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence
{
    public class BugsDbContext : DbContext, IBugsDbContext
    {
        public BugsDbContext(DbContextOptions<BugsDbContext> options)
            : base(options) { }

        public DbSet<Bug> Bugs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BugConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
