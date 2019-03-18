using Curriculo.Domain.Commands.ProductTypes;

namespace Curriculo.Domain.Validations.ProductTypes
{
    public class AddProductTypeValidation : ProductTypeValidation<AddProductTypeCommand>
    {
        public AddProductTypeValidation()
        {
            NameValidate();
        }
    }
}
