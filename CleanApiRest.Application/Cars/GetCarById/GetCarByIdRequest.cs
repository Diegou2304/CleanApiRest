

using MediatR;

namespace CleanApiRest.Application.Cars.GetCarById
{
    public class GetCarByIdRequest : IRequest<GetCarByIdResult>
    {
        public int CarId { get; set; }
    }
}
