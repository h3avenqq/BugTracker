using BugTracker.Application.Common.Mappings;
using BugTracker.Domain;
using System;
using AutoMapper;

namespace BugTracker.Application.SQRS.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsVm : IMapWith<Project>
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid AdminId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.ProjectName,
                    opt => opt.MapFrom(project => project.ProjectName))
                .ForMember(projectDto => projectDto.AdminId,
                    opt => opt.MapFrom(project => project.AdminId));
        }
    }
}
