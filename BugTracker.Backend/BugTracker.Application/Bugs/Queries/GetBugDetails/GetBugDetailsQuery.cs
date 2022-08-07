using System;
using MediatR;

namespace BugTracker.Application.Bugs.Queries.GetBugDetails
{
    public class GetBugDetailsCommand : IRequest<BugDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }

    }
}
