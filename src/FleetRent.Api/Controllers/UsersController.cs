using FleetRent.Application.Commands.User;
using FleetRent.Application.Dtos;
using FleetRent.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUser command)
        {
            var userId = await _userService.CreateAsync(command);
            
            return userId is not null 
                ? CreatedAtAction(nameof(GetById), new { id = userId }, null)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUser command)
        {
            var isUpdated = await _userService.UpdateAsync(command with { UserId = id });

            return isUpdated 
                ? NoContent() 
                : BadRequest();
        }

        [HttpPut("{id:guid}/deactivate")]
        public async Task<ActionResult> Deactivate([FromRoute] Guid id)
        {
            var isUpdated = await _userService.DeactivateAsync(id);

            return isUpdated 
                ? NoContent() 
                : BadRequest();
        }
    }
}