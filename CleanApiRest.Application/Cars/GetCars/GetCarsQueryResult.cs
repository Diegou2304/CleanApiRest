using MediatR;

namespace CleanApiRest.Application.Cars.GetCars
{
    public class GetCarsQueryResult : IRequest<IEnumerable<GetCarsQueryResult>>
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public int CarStoreId { get; set; }
        public string Color { get; set; }

    }
}
