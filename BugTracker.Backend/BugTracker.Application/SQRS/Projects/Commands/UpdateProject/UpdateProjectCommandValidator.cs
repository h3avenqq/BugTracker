using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.ProjectName).NotEmpty().MaximumLength(250);
        }
    }
}
