using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace BugTracker.Application.Interfaces
{
    public interface IBugTrackerDbContext
    {
        DbSet<Bug> Bugs { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<User_Project> Users_Projects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
