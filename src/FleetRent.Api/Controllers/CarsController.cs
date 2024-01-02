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
        public IActionResult GetAll()
        {
            IEnumerable<CarDto> cars = _carService.GetAll();
            return Ok(cars);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            CarDto car = _carService.GetById(id);
            if (car is null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCar command)
        {
            Guid? id = _carService.Create(command);
            if (id is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById ), new { id = id }, null);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateCar command)
        {
            command = command with { Id = id };

            bool isUpdated = _carService.Update(command);
            if (!isUpdated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            SetCarInactive command = new SetCarInactive(id);

            bool isDeleted = _carService.Deactivate(command);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("start-hire")]
        public IActionResult StartHire([FromBody] StartHire command)
        {
            bool isStarted = _carService.StartHire(command);
            if (!isStarted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("end-hire")]
        public IActionResult EndHire([FromBody] EndHire command)
        {
            bool isEnded = _carService.EndHire(command);
            if (!isEnded)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("remove-hire")]
        public IActionResult RemoveHire([FromBody] RemoveHire command)
        {
            bool isRemoved = _carService.RemoveHire(command);
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("start-reservation")]
        public IActionResult StartReservation([FromBody] StartReservation command)
        {
            bool isStarted = _carService.StartReservation(command);
            if (!isStarted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("end-reservation")]
        public IActionResult EndReservation([FromBody] EndReservation command)
        {
            bool isEnded = _carService.EndReservation(command);
            if (!isEnded)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("remove-reservation")]
        public IActionResult RemoveReservation([FromBody] RemoveReservation command)
        {
            bool isRemoved = _carService.RemoveReservation(command);
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}