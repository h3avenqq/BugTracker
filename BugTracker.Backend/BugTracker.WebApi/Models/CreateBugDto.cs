using AutoMapper;
using BugTracker.Application.SQRS.Bugs.Commands.CreateBug;
using BugTracker.Application.Common.Mappings;
using BugTracker.Domain;


namespace BugTracker.WebApi.Models
{
    public class CreateBugDto : IMapWith<CreateBugCommand>
    {
        public Guid ExecutorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBugDto, CreateBugCommand>()
                .ForMember(bugCommand => bugCommand.ExecutorId,
                    opt => opt.MapFrom(bugDto => bugDto.ExecutorId))
                .ForMember(bugCommand => bugCommand.Title,
                    opt => opt.MapFrom(bugDto => bugDto.Title))
                .ForMember(bugCommand => bugCommand.Description,
                    opt => opt.MapFrom(bugDto => bugDto.Description))
                .ForMember(bugCommand => bugCommand.Priority,
                    opt => opt.MapFrom(bugDto => bugDto.Priority))
                .ForMember(bugCommand => bugCommand.Status,
                    opt => opt.MapFrom(bugDto => bugDto.Status))
                .ForMember(bugCommand => bugCommand.CreationDate,
                    opt => opt.MapFrom(bugDto => bugDto.CreationDate));
        }
    }
}
