using Curriculo.Domain.Commands.Products;
using FluentValidation;

namespace Curriculo.Domain.Validations.Products
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
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

        protected void DescriptionValidate()
        {
            RuleFor(p => p.Description)
                .Must(p => p != null && p != string.Empty)
                .MaximumLength(100)
                .WithMessage("Description must have a max 20 characters");
        }
    }
}
