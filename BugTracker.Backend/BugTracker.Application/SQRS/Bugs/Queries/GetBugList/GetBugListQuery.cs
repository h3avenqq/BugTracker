using MediatR;
using System;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugList
{
    public class GetBugListQuery : IRequest<BugListVm>
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
    }
}
