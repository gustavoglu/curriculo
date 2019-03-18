using Curriculo.Domain.Commands.ProductTypes;

namespace Curriculo.Domain.Validations.ProductTypes
{
    public class DeleteProductTypeValidation : ProductTypeValidation<DeleteProductTypeCommand> 
    {
        public DeleteProductTypeValidation()
        {
            IdValidate();
        }
    }
}
