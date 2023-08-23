using AutoMapper;
using CleanApiRest.Application.Contracts;
using CleanApiRest.Domain;
using CleanApiRest.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CleanApiRest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _respository;
    
        public CarController(ICarRepository respository)
        {
            _respository = respository;
         
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> Get([FromQuery] string color = null)
        {
            return await _respository.GetCarByColor(color);
;
        }
    }
}
