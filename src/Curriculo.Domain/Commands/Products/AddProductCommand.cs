using Curriculo.Domain.Validations.Products;

namespace Curriculo.Domain.Commands.Products
{
    public class AddProductCommand : ProductCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new AddProductValidation().Validate(this);
            return ValidationResult.IsValid;

        }
    }
}
 