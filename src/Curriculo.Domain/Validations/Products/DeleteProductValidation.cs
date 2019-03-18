using Curriculo.Domain.Commands.Products;

namespace Curriculo.Domain.Validations.Products
{
    public class DeleteProductValidation : ProductValidation<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            IdValidate();
        }
    }
}
