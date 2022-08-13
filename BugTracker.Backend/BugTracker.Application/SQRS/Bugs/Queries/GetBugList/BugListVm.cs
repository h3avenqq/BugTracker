using System.Collections.Generic;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugList
{
    public class BugListVm
    {
        public IList<BugLookupDto> Bugs { get; set; }
    }
}
