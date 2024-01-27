using FleetRent.Application.Commands.Car;
using FleetRent.Application.Commands.Hire;
using FleetRent.Application.Commands.Reservation;
using FleetRent.Application.Dtos;
using FleetRent.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FleetRent.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService) 
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CarDto> cars = await _carService.GetAllAsync();
            return Ok(cars);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            CarDto car = await _carService.GetByIdAsync(id);
            if (car is null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCar command)
        {
            Guid? id = await _carService.CreateAsync(command);
            if (id is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById ), new { id = id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCar command)
        {
            command = command with { Id = id };

            bool isUpdated = await _carService.UpdateAsync(command);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/deactivate")]
        public async Task<IActionResult> Deactivate([FromRoute] Guid id)
        {
            SetCarInactive command = new SetCarInactive(id);

            bool isDeleted = await _carService.DeactivateAsync(command);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/start-hire")]
        public async Task<IActionResult> StartHire([FromRoute] Guid id, [FromBody] StartHire command)
        {
            bool isStarted = await _carService.StartHireAsync(command with { CarId = id });
            if (!isStarted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/end-hire")]
        public async Task<IActionResult> EndHire([FromRoute] Guid id, [FromBody] EndHire command)
        {
            bool isEnded = await _carService.EndHireAsync(command with { CarId = id });
            if (!isEnded)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/remove-hire")]
        public async Task<IActionResult> RemoveHire([FromRoute] Guid id, [FromBody] RemoveHire command)
        {
            bool isRemoved = await _carService.RemoveHireAsync(command with { CarId = id });
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/start-reservation")]
        public async Task<IActionResult> StartReservation([FromRoute] Guid id, [FromBody] StartReservation command)
        {
            bool isStarted = await _carService.StartReservationAsync(command with { CarId = id });
            if (!isStarted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // [HttpPut("{id:guid}/end-reservation")]
        // public IActionResult EndReservation([FromRoute] Guid id, [FromBody] EndReservation command)
        // {
        //     bool isEnded = _carService.EndReservation(command with { CarId = id });
        //     if (!isEnded)
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }

        [HttpPut("{id:guid}/remove-reservation")]
        public async Task<IActionResult> RemoveReservation([FromRoute] Guid id, [FromBody] RemoveReservation command)
        {
            bool isRemoved = await _carService.RemoveReservationAsync(command with { CarId = id });
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}