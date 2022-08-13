using System;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.SQRS.Bugs.Commands.CreateBug
{
    public class CreateBugCommandHandler
        : IRequestHandler<CreateBugCommand, Guid>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public CreateBugCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateBugCommand request, 
            CancellationToken cancellationToken)
        {
            var bug = new Bug
            {
                Id = Guid.NewGuid(),
                AuthorId = request.AuthorId,
                ExecutorId = request.ExecutorId,
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                Status = request.Status,
                CreationDate = DateTime.UtcNow,
                EditDate = null
            };

            await _dbContext.Bugs.AddAsync(bug);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return bug.Id;
        }
    }
}
