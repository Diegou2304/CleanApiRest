
namespace CleanApiRest.Application.Features.Cars.CreateCar
{
    public class CreateCarCommand
    {
        public int CarStoreId { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int ReleaseDate { get; set; }

    }
}
