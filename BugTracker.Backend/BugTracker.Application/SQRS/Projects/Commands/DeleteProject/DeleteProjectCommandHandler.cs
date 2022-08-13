using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.SQRS.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public DeleteProjectCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .FindAsync(new object[] { request.Id });

            if (entity == null || entity.AdminId != request.UserId)
                throw new NotFoundException(nameof(Project), request.Id);

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
