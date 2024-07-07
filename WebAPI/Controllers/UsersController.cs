using Application.Features.Users.Commands.Create;
using Application.Features.Users.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
           CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListQueryRequest getListQueryRequest)
        {
            GetListQueryResponse response = await _mediator.Send(getListQueryRequest);
            return Ok(response);
        }
    }
}
