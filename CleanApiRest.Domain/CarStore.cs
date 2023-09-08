using CleanApiRest.Domain.Common;

namespace CleanApiRest.Domain
{
    public class CarStore : BaseDomainModel
    {
        public int CarStoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string OwnerName { get; set; }
        public string CountryName { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}