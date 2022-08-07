using System;
using MediatR;

namespace BugTracker.Application.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }

    }
}
