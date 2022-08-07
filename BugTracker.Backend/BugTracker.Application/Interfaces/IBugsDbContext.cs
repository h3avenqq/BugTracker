using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace BugTracker.Application.Interfaces
{
    public interface IBugsDbContext
    {
        DbSet<Bug> Bugs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
