using AutoMapper;
using CleanApiRest.Application.Contracts;
using CleanApiRest.Application.Features.Cars.CreateCar;
using CleanApiRest.Application.Features.Cars.GetCars;
using CleanApiRest.Domain;
using Microsoft.AspNetCore.Mvc;


namespace CleanApiRest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarStoreRepository _carStoreRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository respository, IMapper mapper, ICarStoreRepository carStoreRepository)
        {
            _carRepository = respository;
            _mapper = mapper;
            _carStoreRepository = carStoreRepository;

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
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var car = _mapper.Map<Car>(createCar);

            var carStore = await _carStoreRepository.GetCarStoreById(car.CarStoreId);

            if(carStore is null) return BadRequest();

            
            car.ChasisNumber = Guid.NewGuid();
            var result = await _carRepository.AddAsync(car);

            return Ok(result.CarId);
        }
    }
}
