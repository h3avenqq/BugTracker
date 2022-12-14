using MediatR;
using System;

namespace BugTracker.Application.SQRS.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string ProjectName { get; set; }
        public Guid UserId { get; set; }
    }
}
