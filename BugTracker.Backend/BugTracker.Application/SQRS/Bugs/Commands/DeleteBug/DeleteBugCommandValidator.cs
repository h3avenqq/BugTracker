using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.Bugs.Commands.DeleteBug
{
    public class DeleteBugCommandValidator : AbstractValidator<DeleteBugCommand>
    {
        public DeleteBugCommandValidator()
        {
            RuleFor(deleteBugCommand =>
                deleteBugCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteBugCommand =>
                deleteBugCommand.AuthorId).NotEqual(Guid.Empty);
        }
    }
}
