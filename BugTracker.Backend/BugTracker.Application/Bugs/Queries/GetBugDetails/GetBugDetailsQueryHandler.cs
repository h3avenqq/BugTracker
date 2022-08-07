using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Threading;
using BugTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using BugTracker.Application.Common.Exceptions;

namespace BugTracker.Application.Bugs.Queries.GetBugDetails
{
    public class GetBugDetailsCommandHandler
        : IRequestHandler<GetBugDetailsCommand, BugDetailsVm>
    {
        private readonly IBugsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBugDetailsCommandHandler(IBugsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BugDetailsVm> Handle(GetBugDetailsCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Bugs.FirstOrDefaultAsync(bug =>
                    bug.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Bugs), request.Id);

            return _mapper.Map<BugDetailsVm>(entity);
        }
    }
}
