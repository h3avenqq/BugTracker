using System;
using MediatR;

namespace BugTracker.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid UserId { get; set; }
    }
}
