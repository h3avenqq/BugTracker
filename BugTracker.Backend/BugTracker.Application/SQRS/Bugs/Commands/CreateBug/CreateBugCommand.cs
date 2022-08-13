using System;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.SQRS.Bugs.Commands.CreateBug
{
    public class CreateBugCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
