using MediatR;

namespace CleanApiRest.Application.Cars.GetCars
{
    public class GetCarsQueryResponse : IRequest<IEnumerable<GetCarsQueryResponse>>
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public int CarStoreId { get; set; }
        public string Color { get; set; }

    }
}
