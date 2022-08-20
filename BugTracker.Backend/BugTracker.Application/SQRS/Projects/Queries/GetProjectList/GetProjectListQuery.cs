using System;
using MediatR;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<ProjectListVm>
    {
        public Guid UserId { get; set; }
    }
}
