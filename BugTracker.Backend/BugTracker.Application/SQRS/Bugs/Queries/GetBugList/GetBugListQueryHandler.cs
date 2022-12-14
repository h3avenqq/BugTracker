using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BugTracker.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugList
{
    public class GetBugListQueryHandler
        : IRequestHandler<GetBugListQuery, BugListVm>
    {
        private readonly IBugTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBugListQueryHandler(IBugTrackerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BugListVm> Handle(GetBugListQuery request, 
            CancellationToken cancellationToken)
        {
            var bugsQuery =
                await _dbContext.Bugs.AsQueryable()
                    .ProjectTo<BugLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new BugListVm { Bugs = bugsQuery };
        }
    }
}
