using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Interfaces
{
    public interface IProjectsDbContext
    {
        DbSet<Project> Projects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
