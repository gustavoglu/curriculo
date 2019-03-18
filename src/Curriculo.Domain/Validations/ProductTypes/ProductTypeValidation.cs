using Curriculo.Domain.Commands.ProductTypes;
using FluentValidation;

namespace Curriculo.Domain.Validations.ProductTypes
{
    public abstract class ProductTypeValidation<T> : AbstractValidator<T> where T : ProductTypeCommand
    {
        protected void IdValidate()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Id is required");
        }

        protected void NameValidate()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(p => p.Name)
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("Name must be 3 to 20 characters");
        }
    }
}
