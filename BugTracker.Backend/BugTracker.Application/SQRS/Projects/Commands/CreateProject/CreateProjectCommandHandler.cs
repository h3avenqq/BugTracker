using System;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.SQRS.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IBugTrackerDbContext _dbContext;

        public CreateProjectCommandHandler(IBugTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                AdminId = request.UserId
            };

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
