using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectName).NotEmpty().MaximumLength(250);
        }
    }
}
