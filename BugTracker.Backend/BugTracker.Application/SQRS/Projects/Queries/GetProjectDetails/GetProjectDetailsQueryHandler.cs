using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Application.Common.Exceptions;
using BugTracker.Application.Interfaces;
using BugTracker.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryHandler
        : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsVm>
    {
        private readonly IBugTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectDetailsQueryHandler(IBugTrackerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProjectDetailsVm> Handle(GetProjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Projects.FirstOrDefaultAsync(
                    project => project.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Project), request.Id);

            return _mapper.Map<ProjectDetailsVm>(entity);
        }
    }
}
