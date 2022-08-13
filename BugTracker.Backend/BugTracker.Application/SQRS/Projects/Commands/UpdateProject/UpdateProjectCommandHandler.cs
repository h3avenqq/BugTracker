using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.SQRS.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public UpdateProjectCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity
                = await _dbContext.Projects.FirstOrDefaultAsync(project =>
                    project.Id == request.Id, cancellationToken);

            if (entity == null || entity.AdminId != request.UserId)
                throw new NotFoundException(nameof(Project), request.Id);

            entity.ProjectName = request.ProjectName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
