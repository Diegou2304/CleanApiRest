

using MediatR;

namespace CleanApiRest.Application.Cars.GetCarById
{
    public class GetCarByIdResult
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public int CarStoreId { get; set; }
        public string Color { get; set; }
    }
}
