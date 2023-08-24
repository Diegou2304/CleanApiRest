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
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CarController(ICarRepository respository, IMapper mapper, IMediator mediator)
        {
            _carRepository = respository;
            _mapper = mapper;
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IEnumerable<GetCarsQueryResponse>> Get([FromQuery] string? color)
        {
            if (color == null)
            {
                var temp = await _carRepository.GetAll();

                return _mapper.Map<IEnumerable<GetCarsQueryResponse>>(temp); 
            }
            
            var cars = await _carRepository.GetCarByColor(color);

            return _mapper.Map<IEnumerable<GetCarsQueryResponse>>(cars);
            
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCar([FromBody] CreateCarCommand createCar)
        {

            return await _mediator.Send(createCar);
        }
    }
}
