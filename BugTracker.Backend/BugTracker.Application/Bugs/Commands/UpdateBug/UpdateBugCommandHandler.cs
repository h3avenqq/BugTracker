using System;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public UpdateBugCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateBugCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Bugs.FirstOrDefaultAsync(bug =>
                    bug.Id == request.Id, cancellationToken);

            if (entity == null || entity.AuthorId != entity.AuthorId)
                throw new NotFoundException(nameof(Bug), request.Id);

            entity.ExecutorId = request.ExecutorId;
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Priority = request.Priority;
            entity.Status = request.Status;
            entity.EditDate = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
