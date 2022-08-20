using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugList
{
    public class GetBugListQueryValidator : AbstractValidator<GetBugListQuery>
    {
        public GetBugListQueryValidator()
        {
            RuleFor(getBugList =>
                getBugList.UserId).NotEqual(Guid.Empty);
            RuleFor(getBugList =>
                getBugList.ProjectId).NotEqual(Guid.Empty);
        }
    }
}
