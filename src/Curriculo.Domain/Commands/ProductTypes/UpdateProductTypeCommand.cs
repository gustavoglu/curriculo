using Curriculo.Domain.Validations.ProductTypes;

namespace Curriculo.Domain.Commands.ProductTypes
{
    public class UpdateProductTypeCommand : ProductTypeCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateProductTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
