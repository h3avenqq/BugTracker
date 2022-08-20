using System;
using MediatR;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.CreateUserProject
{
    public class CreateUserProjectCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
