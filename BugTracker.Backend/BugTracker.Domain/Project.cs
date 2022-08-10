using System;

namespace BugTracker.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid AdminId { get; set; }

    }
}
