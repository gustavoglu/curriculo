using Curriculo.Domain.Validations.ProductTypes;

namespace Curriculo.Domain.Commands.ProductTypes
{
    public class AddProductTypeCommand : ProductTypeCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new AddProductTypeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
