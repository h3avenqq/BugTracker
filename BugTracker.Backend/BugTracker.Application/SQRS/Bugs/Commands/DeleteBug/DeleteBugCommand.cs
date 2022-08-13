using System;
using MediatR;

namespace BugTracker.Application.SQRS.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
    }
}
