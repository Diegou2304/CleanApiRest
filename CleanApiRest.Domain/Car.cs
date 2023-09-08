using CleanApiRest.Domain.Common;

namespace CleanApiRest.Domain
{
    public class Car : BaseDomainModel
    {
        public Car() 
        {
            
        }
        public int CarId { get; set; }
        public Guid ChasisNumber { get;  set; } = Guid.Empty;
        public string Color { get; set; }
        public string Brand { get; set; }
        public int ReleaseDate { get; set; } = DateTime.Now.Year;
        public int CarStoreId { get; set; }
        public CarStore CarStore { get; set; }

    }
}
