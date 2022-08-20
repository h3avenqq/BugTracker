using System.Collections.Generic;


namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectList
{
    public class ProjectListVm
    {
        public IList<ProjectLookupDto> Projects { get; set; }
    }
}
