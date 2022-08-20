using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.CreateUserProject
{
    public class CreateUserProjectCommandHandler : IRequestHandler<CreateUserProjectCommand>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public CreateUserProjectCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateUserProjectCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = new User_Project
            {
                UserId = request.UserId,
                ProjectId = request.ProjectId
            };

            await _dbContext.Users_Projects.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
