using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Bugs.Commands.UpdateBug
{
    public class UpdateBugCommandValidator : AbstractValidator<UpdateBugCommand>
    {
        public UpdateBugCommandValidator()
        {
            RuleFor(updateBugCommand =>
                updateBugCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateBugCommand =>
                updateBugCommand.AuthorId).NotEqual(Guid.Empty);
            RuleFor(updateBugCommand =>
                updateBugCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateBugCommand =>
                updateBugCommand.Description).NotEmpty().MaximumLength(1000);
        }
    }
}
