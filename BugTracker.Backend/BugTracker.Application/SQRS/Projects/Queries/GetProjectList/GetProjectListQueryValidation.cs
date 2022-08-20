using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryValidation : AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidation()
        {
            RuleFor(getProjectList =>
                getProjectList.UserId).NotEqual(Guid.Empty);
        }
    }
}
