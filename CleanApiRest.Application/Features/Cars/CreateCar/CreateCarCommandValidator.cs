
using FluentValidation;

namespace CleanApiRest.Application.Features.Cars.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {

        public CreateCarCommandValidator()
        {
            RuleFor(x => x.CarStoreId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.Brand)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Color)
               .NotNull()
               .NotEmpty();
            RuleFor(x => x.ReleaseDate)
               .NotNull()
               .NotEmpty();

        }
    }
}
