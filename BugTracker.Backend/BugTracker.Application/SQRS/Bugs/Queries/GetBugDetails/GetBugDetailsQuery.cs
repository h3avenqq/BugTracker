using System;
using MediatR;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugDetails
{
    public class GetBugDetailsQuery : IRequest<BugDetailsVm>
    {
        public Guid Id { get; set; }
        //public Guid AuthorId { get; set; }

    }
}
