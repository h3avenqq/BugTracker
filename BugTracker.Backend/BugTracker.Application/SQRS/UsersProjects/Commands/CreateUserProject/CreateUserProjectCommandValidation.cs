using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.CreateUserProject
{
    public class CreateUserProjectCommandValidation 
        : AbstractValidator<CreateUserProjectCommand>
    {
        public CreateUserProjectCommandValidation()
        {
            RuleFor(createUserProject =>
                createUserProject.ProjectId).NotEqual(Guid.Empty);
            RuleFor(createUserProject =>
                createUserProject.UserId).NotEqual(Guid.Empty);
        }
    }
}
