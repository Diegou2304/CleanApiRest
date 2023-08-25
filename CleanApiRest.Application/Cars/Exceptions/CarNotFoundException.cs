
namespace CleanApiRest.Application.Cars.Exceptions
{
    [Serializable]
    public class CarNotFoundException : Exception
    {
        
        public CarNotFoundException()
        {

        }

        public CarNotFoundException(string message)
        : base(message) { }

        public CarNotFoundException(string message, Exception inner)
        : base(message, inner) { }
    }
}
