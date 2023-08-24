using MediatR;

namespace CleanApiRest.Application.Cars.CreateCar
{
    public class CreateCarCommand : IRequest<int>
    {
        public int CarStoreId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int ReleaseDate { get; set; }

    }
}
