using AutoMapper;
using CleanApiRest.Application.Features.Cars.GetCars;
using CleanApiRest.Domain;

namespace CleanApiRest.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, GetCarsQueryResponse>();
        }
     
    }
}
