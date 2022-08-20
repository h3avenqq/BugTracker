using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectDetails
{
    public class GetProjectDetailsQueryValidation : AbstractValidator<GetProjectDetailsQuery>
    {
        public GetProjectDetailsQueryValidation()
        {
            RuleFor(getProjectDetailsQuery =>
                getProjectDetailsQuery.Id).NotEqual(Guid.Empty);
            RuleFor(getProjectDetailsQuery =>
                getProjectDetailsQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
