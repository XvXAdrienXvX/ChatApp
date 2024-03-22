using AuthGateway.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthGateway.Controllers
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
        public async Task<ActionResult<string>> Create(CreateUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
