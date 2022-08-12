﻿using System;
using MediatR;

namespace BugTracker.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
