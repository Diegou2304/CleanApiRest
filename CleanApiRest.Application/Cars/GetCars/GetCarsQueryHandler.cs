using AutoMapper;
using CleanApiRest.Application.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanApiRest.Application.Cars.GetCars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQueryResponse, IEnumerable<GetCarsQueryResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;


        public GetCarsQueryHandler(ICarRepository respository, IMapper mapper)
        {
            _carRepository = respository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCarsQueryResponse>> Handle(GetCarsQueryResponse request, CancellationToken cancellationToken)
        {
            if (request.Color == null)
            {
                var temp = await _carRepository.GetAll();

                return _mapper.Map<IEnumerable<GetCarsQueryResponse>>(temp);
            }
            var cars = await _carRepository.GetCarByColor(request.Color);

            return _mapper.Map<IEnumerable<GetCarsQueryResponse>>(cars);
        }
    }
}
