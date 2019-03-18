using Curriculo.Domain.Commands.Products;

namespace Curriculo.Domain.Validations.Products
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            IdValidate();
            NameValidate();
            DescriptionValidate();
        }
    }
}
