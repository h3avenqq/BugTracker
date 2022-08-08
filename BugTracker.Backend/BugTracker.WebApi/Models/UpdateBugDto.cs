using AutoMapper;
using BugTracker.Application.Bugs.Commands.UpdateBug;
using BugTracker.Application.Common.Mappings;
using BugTracker.Domain;

namespace BugTracker.WebApi.Models
{
    public class UpdateBugDto : IMapWith<UpdateBugCommand>
    {
        public Guid Id { get; set; }
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBugDto, UpdateBugCommand>()
                .ForMember(bugCommand => bugCommand.Id,
                    opt => opt.MapFrom(bugDto => bugDto.Id))
                .ForMember(bugCommand => bugCommand.ExecutorId,
                    opt => opt.MapFrom(bugDto => bugDto.ExecutorId))
                .ForMember(bugCommand => bugCommand.Title,
                    opt => opt.MapFrom(bugDto => bugDto.Title))
                .ForMember(bugCommand => bugCommand.Description,
                    opt => opt.MapFrom(bugDto => bugDto.Description))
                .ForMember(bugCommand => bugCommand.Priority,
                    opt => opt.MapFrom(bugDto => bugDto.Priority))
                .ForMember(bugCommand => bugCommand.Status,
                    opt => opt.MapFrom(bugDto => bugDto.Status));
        }
    }
}
