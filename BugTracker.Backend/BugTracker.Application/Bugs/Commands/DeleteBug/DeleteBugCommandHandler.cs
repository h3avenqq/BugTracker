using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommandHandler : IRequestHandler<DeleteBugCommand>
    {
        private readonly IBugsDbContext _dbContext;

        public DeleteBugCommandHandler(IBugsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteBugCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Bugs
                .FindAsync(new object[] { request.Id });

            if (entity == null || entity.AuthorId != request.AuthorId)
                throw new NotFoundException(nameof(Bug), request.Id);

            _dbContext.Bugs.Remove(entity);   
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
