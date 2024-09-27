using Microsoft.AspNetCore.Mvc;
using NET105_Bai5.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NET105_Bai5.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/cars
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carService.GetCars();
            if (cars == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var car = _carService.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(car);
            }
        }

        // POST api/cars
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            _carService.CreateCar(car);
            return StatusCode(StatusCodes.Status201Created, car);
        }

        // PUT api/cars/5
        [HttpPut]
        public IActionResult Put([FromBody] Car car)
        {
            var carUpdate = _carService.GetCar(car.Id);
            if (carUpdate == null)
            {
                return BadRequest();
            }
            else
            {
                _carService.UpdateCar(car);
                return Ok(carUpdate);
            }
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _carService.DeleteCar(id);
            return Ok();
        }
    }
}
