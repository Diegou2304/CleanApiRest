
using AutoMapper;
using CleanApiRest.Application.Cars.Exceptions;
using CleanApiRest.Application.Contracts;
using MediatR;

namespace CleanApiRest.Application.Cars.GetCarById
{
    public class GetCarByIdHandler : IRequestHandler<GetCarByIdRequest, GetCarByIdResult>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetCarByIdHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetCarByIdResult> Handle(GetCarByIdRequest request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetCarById(request.CarId);

            return car is null
                ? throw new CarNotFoundException($"The car with Id {request.CarId} could not be found")
                : _mapper.Map<GetCarByIdResult>(car);
        }
    }
}
