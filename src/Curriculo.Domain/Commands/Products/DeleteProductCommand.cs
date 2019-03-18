using Curriculo.Domain.Validations.Products;

namespace Curriculo.Domain.Commands.Products
{
    public class DeleteProductCommand : ProductCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
