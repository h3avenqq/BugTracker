using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using BugTracker.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence
{
    public class UsersProjectsDbContext : DbContext, IUsersProjectsDbContext
    {
        public UsersProjectsDbContext(DbContextOptions<UsersProjectsDbContext> options)
            : base(options) { }

        public DbSet<UserProject> UsersProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserProjectConfigurations());
            base.OnModelCreating(builder);
        }

    }
}
