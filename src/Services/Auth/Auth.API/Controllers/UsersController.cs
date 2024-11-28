using CommonFiles.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auth.Application.Dtos;
using Auth.Application.UseCases.UserUseCases.Commands.DeleteUser;
using Auth.Application.UseCases.UserUseCases.Commands.GrantAdminRole;
using Auth.Application.UseCases.UserUseCases.Commands.RevokeAdminRole;
using Auth.Application.UseCases.UserUseCases.Commands.UpdateUser;
using Auth.Application.UseCases.UserUseCases.Queries.GetUserById;
using Auth.Application.UseCases.UserUseCases.Queries.GetUsers;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationParams paginationParams)
        {
            var response = await _mediator.Send(new GetUsersQuery(paginationParams));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(Guid id, [FromForm] UserRequestDto userDto)
        {
            var response = await _mediator.Send(new UpdateUserCommand(id, userDto));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut("{id}/assign-admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> GrantAdminRole(Guid id)
        {
            var response = await _mediator.Send(new GrantAdminRoleCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete("{id}/remove-admin")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> RevokeAdminRole(Guid id)
        {
            var response = await _mediator.Send(new RevokeAdminRoleCommand(id));
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
