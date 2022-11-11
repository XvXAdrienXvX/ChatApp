using ChatApp.Application.User.DTO;
using ChatApp.Application.User.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("Users")]
        public async Task<ActionResult<UserListDTO>> GetUserList([FromQuery] GetUsersQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
