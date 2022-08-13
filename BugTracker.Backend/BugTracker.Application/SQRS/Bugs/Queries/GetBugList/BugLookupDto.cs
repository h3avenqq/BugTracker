using System;
using AutoMapper;
using BugTracker.Application.Common.Mappings;
using BugTracker.Domain;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugList
{
    public class BugLookupDto : IMapWith<Bug>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Guid Excecutor { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bug, BugLookupDto>()
                .ForMember(bugDto => bugDto.Id,
                    opt => opt.MapFrom(bug => bug.Id))
                .ForMember(bugDto => bugDto.Title,
                    opt => opt.MapFrom(bug => bug.Title))
                .ForMember(bugDto => bugDto.Priority,
                    opt => opt.MapFrom(bug => bug.Priority))
                .ForMember(bugDto => bugDto.Status,
                    opt => opt.MapFrom(bug => bug.Status))
                .ForMember(bugDto => bugDto.Excecutor,
                    opt => opt.MapFrom(bug => bug.ExecutorId));
        }
    }
}
