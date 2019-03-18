using Curriculo.Domain.Validations.Products;

namespace Curriculo.Domain.Commands.Products
{
    public class UpdateProductCommand : ProductCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
