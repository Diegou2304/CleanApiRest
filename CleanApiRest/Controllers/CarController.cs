using AutoMapper;
using CleanApiRest.Application.Contracts;
using CleanApiRest.Application.Features.Cars.CreateCar;
using CleanApiRest.Application.Features.Cars.GetCars;
using CleanApiRest.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CleanApiRest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
       
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
           
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarsQueryResponse>>> Get([FromQuery] string? color)
        {
            var query = new GetCarsQueryResponse
            {
                Color = color,
            };

            var cars = await _mediator.Send(query);

            return Ok(cars);

          
            
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarCommand createCar)
        {

            return await _mediator.Send(createCar);
        }
    }
}
