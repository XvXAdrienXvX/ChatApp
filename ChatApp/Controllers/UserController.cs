using ChatApp.Application.User.Command.CreateUser;
using ChatApp.Application.User.Command.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
