using System;
using FluentValidation;

namespace BugTracker.Application.Bugs.Commands.CreateBug
{
    public class CreateBugCommandValidator : AbstractValidator<CreateBugCommand>
    {
        public CreateBugCommandValidator()
        {
            RuleFor(createBugCommand =>
                createBugCommand.AuthorId).NotEqual(Guid.Empty);
            RuleFor(createBugCommand =>
                createBugCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createBugCommand =>
                createBugCommand.Description).NotEmpty().MaximumLength(1000);
            
        }
    }
}
