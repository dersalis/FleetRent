using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetRent.Api.Commands.User;
using FleetRent.Api.Entities;
using FleetRent.Api.Services;
using FleetRent.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService = new();

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<UserDto> GetById([FromRoute] Guid id)
        {
            var user = _userService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreateUser command)
        {
            var userId = _userService.Create(command);
            
            return userId is not null 
                ? CreatedAtAction(nameof(GetById), new { id = userId }, null)
                : BadRequest();
        }

        [HttpPut("{id:guid}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] UpdateUser command)
        {
            var isUpdated = _userService.Update(command with { UserId = id });

            return isUpdated 
                ? NoContent() 
                : BadRequest();
        }

        [HttpPut("{id:guid}/deactivate")]
        public ActionResult Deactivate([FromRoute] Guid id)
        {
            var isUpdated = _userService.Deactivate(id);

            return isUpdated 
                ? NoContent() 
                : BadRequest();
        }
    }
}