using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(deleteProjectCommand =>
                deleteProjectCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteProjectCommand =>
                deleteProjectCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
