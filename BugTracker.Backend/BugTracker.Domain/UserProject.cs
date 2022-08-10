using System;

namespace BugTracker.Domain
{
    public class UserProject
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsModerator { get; set; }
    }
}
