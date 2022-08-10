using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BugTracker.Application.Interfaces
{
    public interface IUsersProjectsDbContext
    {
        DbSet<UserProject> UsersProjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
