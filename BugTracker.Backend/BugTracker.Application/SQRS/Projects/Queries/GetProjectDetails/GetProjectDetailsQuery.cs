using System;
using MediatR;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
