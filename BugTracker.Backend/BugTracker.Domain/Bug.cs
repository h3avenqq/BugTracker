using System;

namespace BugTracker.Domain
{
    public enum Status
    {
        Reported,
        Accepted,
        InProgress,
        ToBeValidated,
        Done
    }

    public enum Priority
    {
        Enhancement,
        Trivial,
        Minor,
        Major,
        Critical
    }

    public class Bug
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
