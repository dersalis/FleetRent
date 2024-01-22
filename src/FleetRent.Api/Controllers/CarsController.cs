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

        [HttpPut("{id:guid}/deactivate")]
        public IActionResult Deactivate([FromRoute] Guid id)
        {
            SetCarInactive command = new SetCarInactive(id);

            bool isDeleted = _carService.Deactivate(command);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/start-hire")]
        public IActionResult StartHire([FromRoute] Guid id, [FromBody] StartHire command)
        {
            bool isStarted = _carService.StartHire(command with { CarId = id });
            if (!isStarted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/end-hire")]
        public IActionResult EndHire([FromRoute] Guid id, [FromBody] EndHire command)
        {
            bool isEnded = _carService.EndHire(command with { CarId = id });
            if (!isEnded)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/remove-hire")]
        public IActionResult RemoveHire([FromRoute] Guid id, [FromBody] RemoveHire command)
        {
            bool isRemoved = _carService.RemoveHire(command with { CarId = id });
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}/start-reservation")]
        public IActionResult StartReservation([FromRoute] Guid id, [FromBody] StartReservation command)
        {
            bool isStarted = _carService.StartReservation(command with { CarId = id });
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
        public IActionResult RemoveReservation([FromRoute] Guid id, [FromBody] RemoveReservation command)
        {
            bool isRemoved = _carService.RemoveReservation(command with { CarId = id });
            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}