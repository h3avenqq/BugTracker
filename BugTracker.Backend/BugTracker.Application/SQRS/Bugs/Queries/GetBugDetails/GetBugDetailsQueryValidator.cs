using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugDetails
{
    public class GetBugDetailsQueryValidator : AbstractValidator<GetBugDetailsQuery>
    {
        public GetBugDetailsQueryValidator()
        {
            RuleFor(getBugDetailsQuery =>
                getBugDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
