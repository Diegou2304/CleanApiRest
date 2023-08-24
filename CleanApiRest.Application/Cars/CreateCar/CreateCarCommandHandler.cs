using AutoMapper;
using CleanApiRest.Application.Contracts;
using CleanApiRest.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace CleanApiRest.Application.Cars.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarStoreRepository _carStoreRepository;
        private readonly IMapper _mapper;

        public CreateCarCommandHandler(ICarRepository respository, IMapper mapper, ICarStoreRepository carStoreRepository)
        {
            _carRepository = respository;
            _mapper = mapper;
            _carStoreRepository = carStoreRepository;
        }
        public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {

            var car = _mapper.Map<Car>(request);

            var carStore = await _carStoreRepository.GetCarStoreById(car.CarStoreId);

            if (carStore is null) return 0;


            car.ChasisNumber = Guid.NewGuid();
            var result = await _carRepository.AddAsync(car);

            return result.CarId;


        }
    }
}
