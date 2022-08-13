using AutoMapper;
using BugTracker.Application.Common.Mappings;
using BugTracker.Domain;
using System;

namespace BugTracker.Application.SQRS.Bugs.Queries.GetBugDetails
{
    public class BugDetailsVm : IMapWith<Bug>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bug, BugDetailsVm>()
                .ForMember(bugVm => bugVm.Id,
                    opt => opt.MapFrom(bug => bug.Id))
                .ForMember(bugVm => bugVm.AuthorId,
                    opt => opt.MapFrom(bug => bug.AuthorId))
                .ForMember(bugVm => bugVm.ExecutorId,
                    opt => opt.MapFrom(bug => bug.ExecutorId))
                .ForMember(bugVm => bugVm.Title,
                    opt => opt.MapFrom(bug => bug.Title))
                .ForMember(bugVm => bugVm.Description,
                    opt => opt.MapFrom(bug => bug.Description))
                .ForMember(bugVm => bugVm.Priority,
                    opt => opt.MapFrom(bug => bug.Priority))
                .ForMember(bugVm => bugVm.Status,
                    opt => opt.MapFrom(bug => bug.Status))
                .ForMember(bugVm => bugVm.CreationDate,
                    opt => opt.MapFrom(bug => bug.CreationDate))
                .ForMember(bugVm => bugVm.EditDate,
                    opt => opt.MapFrom(bug => bug.EditDate));
        }
    }
}
