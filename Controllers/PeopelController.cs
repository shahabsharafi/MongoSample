using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using MongoSample.Domains.EmployeeDomain;
using MongoSample.Domains.EmployeeDomain.Models;
using MongoSample.Infrasructure;

namespace MongoSample.Controllers
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
        [EnableQuery]
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
    }
}
