using AutoMapper;
using BugTracker.Application.SQRS.Bugs.Commands.CreateBug;
using BugTracker.Application.SQRS.Bugs.Commands.DeleteBug;
using BugTracker.Application.SQRS.Bugs.Commands.UpdateBug;
using BugTracker.Application.SQRS.Bugs.Queries.GetBugDetails;
using BugTracker.Application.SQRS.Bugs.Queries.GetBugList;
using BugTracker.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BugController : BaseController
    {
        private readonly IMapper _mapper;

        public BugController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BugListVm>> GetAll()
        {
            var query = new GetBugListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BugDetailsVm>> Get(Guid id)
        {
            var query = new GetBugDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBugDto createBugDto)
        {
            var command = _mapper.Map<CreateBugCommand>(createBugDto);
            command.AuthorId = UserId;
            var bugId = await Mediator.Send(command);

            return Ok(bugId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateBugDto updateBugDto)
        {
            var command = _mapper.Map<UpdateBugCommand>(updateBugDto);
            command.AuthorId = UserId;
            await Mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBugCommand
            {
                Id = id,
                AuthorId = UserId
            };
            
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
