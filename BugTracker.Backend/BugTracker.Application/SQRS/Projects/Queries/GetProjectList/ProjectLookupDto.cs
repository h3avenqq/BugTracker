using AutoMapper;
using BugTracker.Application.Common.Mappings;
using BugTracker.Application.SQRS.Projects.Queries.GetProjectDetails;
using BugTracker.Domain;
using System;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid AdminId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>()
                .ForMember(projectVm => projectVm.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectVm => projectVm.ProjectName,
                    opt => opt.MapFrom(project => project.ProjectName))
                .ForMember(projectVm => projectVm.AdminId,
                    opt => opt.MapFrom(project => project.AdminId));
        }
    }
}
