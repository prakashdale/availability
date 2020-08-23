using System.Threading.Tasks;
using availability.application.commands;
using availability.application.dto;
using availability.application.queries;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace availability.api.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourcesController: ControllerBase{
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ResourcesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{resourceId:guid}")]
        public async Task<ActionResult<ResourceDto>> Get(GetResource query) {
            var resource = await _queryDispatcher.QueryAsync(query);

            if (resource is {}) {
                return resource;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddResource command) {
            await _commandDispatcher.SendAsync(command);
            return Created($"/api/resource/{command.ResourceId}", null);
        }

    }
}