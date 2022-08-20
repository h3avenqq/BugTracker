using System;
using FluentValidation;

namespace BugTracker.Application.SQRS.UsersProjects.Commands.DeleteUserProject
{
    public class DeleteUserProjectCommandValidation 
        : AbstractValidator<DeleteUserProjectCommand>
    {
        public DeleteUserProjectCommandValidation()
        {
            RuleFor(deleteUserProject =>
                deleteUserProject.ProjectId).NotEqual(Guid.Empty);
            RuleFor(deleteUserProject =>
                deleteUserProject.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteUserProject =>
                deleteUserProject.UserIdToDelete).NotEqual(Guid.Empty);
        }
    }
}
