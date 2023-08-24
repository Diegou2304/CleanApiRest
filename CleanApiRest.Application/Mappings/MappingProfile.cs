using AutoMapper;
using CleanApiRest.Application.Cars.CreateCar;
using CleanApiRest.Application.Cars.GetCarById;
using CleanApiRest.Application.Cars.GetCars;
using CleanApiRest.Domain;

namespace CleanApiRest.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>();
            CreateMap<Car,GetCarsQueryResponse >();
            CreateMap<Car, GetCarByIdResult >();
        }
     
    }
}
