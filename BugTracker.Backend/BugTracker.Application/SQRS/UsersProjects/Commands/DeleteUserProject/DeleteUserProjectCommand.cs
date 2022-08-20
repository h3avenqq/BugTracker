using System;
using MediatR;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.DeleteUserProject
{
    public class DeleteUserProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserIdToDelete { get; set; }
    }
}
