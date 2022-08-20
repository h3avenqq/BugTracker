using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Threading;
using BugTracker.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler :
        IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly IBugTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(IBugTrackerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Find all projects where user is admin
        public async Task<ProjectListVm> Handle(GetProjectListQuery request, 
            CancellationToken cancellationToken)
        {
            var projectsQuery =
                await _dbContext.Projects
                    .Where(project => project.AdminId == request.UserId)
                    .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new ProjectListVm() { Projects = projectsQuery };
        }
    }
}
