using Curriculo.Domain.Commands.ProductTypes;

namespace Curriculo.Domain.Validations.ProductTypes
{
    public class UpdateProductTypeValidation : ProductTypeValidation<UpdateProductTypeCommand>
    {
        public UpdateProductTypeValidation()
        {
            IdValidate();
            NameValidate();
        }
    }
}
