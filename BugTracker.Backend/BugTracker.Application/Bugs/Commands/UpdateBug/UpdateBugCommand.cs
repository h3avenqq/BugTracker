using System;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
