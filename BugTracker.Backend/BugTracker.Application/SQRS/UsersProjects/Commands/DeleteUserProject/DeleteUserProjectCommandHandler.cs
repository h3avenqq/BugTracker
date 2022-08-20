using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.DeleteUserProject
{
    public class DeleteUserProjectCommandHandler 
        : IRequestHandler<DeleteUserProjectCommand>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public DeleteUserProjectCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUserProjectCommand request, 
            CancellationToken cancellationToken)
        {
            var project =
                await _dbContext.Projects.FirstOrDefaultAsync(project =>
                        project.AdminId == request.UserId && project.AdminId == request.UserId,
                        cancellationToken);

            if (project == null)
                throw new NotFoundException(nameof(Project), request.ProjectId);

            var entity =
                await _dbContext.Users_Projects.FindAsync(new object[] { request.ProjectId, request.UserIdToDelete });

            if (entity == null)
                throw new NotFoundException(nameof(User_Project), request.UserId);

            _dbContext.Users_Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
