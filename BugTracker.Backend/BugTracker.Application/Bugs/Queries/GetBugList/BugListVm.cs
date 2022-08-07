using System.Collections.Generic;

namespace BugTracker.Application.Bugs.Queries.GetBugList
{
    public class BugListVm
    {
        public IList<BugLookupDto> Bugs { get; set; }
    }
}
