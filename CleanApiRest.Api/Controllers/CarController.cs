using AutoMapper;
using CleanApiRest.Application.Contracts;
using CleanApiRest.Application.Cars.CreateCar;
using CleanApiRest.Application.Cars.GetCars;
using CleanApiRest.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanApiRest.Application.Cars.GetCarById;

namespace CleanApiRest.Api.Controllers
{
    [ApiController]
  
    public class CarController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
           
            _mediator = mediator;

        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<IEnumerable<GetCarsQueryResult>>> Get([FromQuery] string? color)
        {
            var query = new GetCarsQueryResult
            {
                Color = color,
            };

            var cars = await _mediator.Send(query);

            return Ok(cars);
            
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<IEnumerable<GetCarsQueryResult>>> GetCarById([FromRoute] int id)
        {
            var query = new GetCarByIdRequest
            {
                CarId = id,
            };

            var car = await _mediator.Send(query);

            return Ok(car);

        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarCommand createCar)
        {

            return await _mediator.Send(createCar);
        }
    }
}
