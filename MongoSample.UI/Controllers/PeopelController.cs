using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using MongoSample.Domain;
using MongoSample.Domain.Models;
using MongoSample.Infrastructure;

namespace MongoSample.UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PeopelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [CustomEnableQuery]
        public async Task<IQueryable<PersonDto>> Get()
        {
            return await _mediator.Send(new GetAllPeopelQuery());            
        }

        [HttpGet("details")]
        public async Task<PersonDto> Get(string id)
        {
            return await _mediator.Send(new GetOnePersonQuery() { Id = id });
        }

        [HttpPost("create")]
        public async Task<ActionResult> Post(AddPersonCommand request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();

        }

        [HttpPost("update")]
        public async Task<ActionResult> Post(UpdatePersonCommand request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();

        }

        [HttpPost("delete")]
        public async Task<ActionResult> Post(DeletePersonCommand request, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(request, cancellationToken);
            return Ok();

        }
    }
}
