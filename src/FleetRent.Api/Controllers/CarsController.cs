// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc; 
// using FleetRent.Api.Services;
// using FleetRent.Api.Entities;

// namespace FleetRent.Api.Controllers
// {
//     [ApiController]
//     [Route("api/cars")]
//     public class CarsController : ControllerBase
//     {
//         private readonly CarService _carService = new();

//         [HttpGet]
//         public async Task<IActionResult> GetAllAsync()
//         {
//             IEnumerable<Car> cars = await _carService.GetAllAsync();
//             return Ok(cars);
//         }

//         [HttpGet("{id:int}")]
//         public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
//         {
//             Car car = await _carService.GetByIdAsync(id);
//             if (car is null)
//             {
//                 return NotFound();
//             }
//             return Ok(car);
//         }

//         [HttpPost]
//         public async Task<IActionResult> CreateAsync([FromBody] Car car)
//         {
//             int? id = await _carService.CreateAsync(car);
//             if (id is null)
//             {
//                 return BadRequest();
//             }
//             return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, null);
//         }

//         [HttpPut("{id:int}")]
//         public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] Car car)
//         {
//             bool isUpdated = await _carService.UpdateAsync(id, car);
//             if (!isUpdated)
//             {
//                 return NotFound();
//             }
//             return NoContent();
//         }

//         [HttpDelete("{id:int}")]
//         public async Task<IActionResult> DeleteAsync([FromRoute] int id)
//         {
//             bool isDeleted = await _carService.DeleteAsync(id);
//             if (!isDeleted)
//             {
//                 return NotFound();
//             }
//             return NoContent();
//         }
//     }
// }