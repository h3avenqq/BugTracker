using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BugTracker.Application.Interfaces;

namespace BugTracker.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<BugsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<ProjectsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<UsersProjectsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IBugsDbContext>(provider =>
                provider.GetService<BugsDbContext>());
            services.AddScoped<IProjectsDbContext>(provider =>
                provider.GetService<ProjectsDbContext>());
            services.AddScoped<IUsersProjectsDbContext>(provider =>
                provider.GetService<UsersProjectsDbContext>());

            return services;
        }
    }
}
