using Curriculo.Domain.Validations.ProductTypes;

namespace Curriculo.Domain.Commands.ProductTypes
{
    public class DeleteProductTypeCommand : ProductTypeCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteProductTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
