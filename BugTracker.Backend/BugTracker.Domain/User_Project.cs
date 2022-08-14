using System;

namespace BugTracker.Domain
{
    public class User_Project
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }


        public Guid UserId { get; set; }
        //continue with that point
    }
}
