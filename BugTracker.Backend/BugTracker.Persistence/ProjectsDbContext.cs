using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using BugTracker.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence
{
    public class ProjectsDbContext : DbContext, IProjectsDbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
