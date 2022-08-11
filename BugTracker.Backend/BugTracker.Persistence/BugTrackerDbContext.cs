using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using BugTracker.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence
{
    public class BugTrackerDbContext : DbContext, IBugTrackerDbContext
    {
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
            : base(options) { }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UsersProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BugConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new UserProjectConfigurations());

            base.OnModelCreating(builder);
        }
    }
}
