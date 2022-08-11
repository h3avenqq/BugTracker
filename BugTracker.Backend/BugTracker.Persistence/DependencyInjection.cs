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

            services.AddDbContext<BugTrackerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IBugTrackerDbContext>(provider =>
                provider.GetService<BugTrackerDbContext>());


            return services;
        }
    }
}
