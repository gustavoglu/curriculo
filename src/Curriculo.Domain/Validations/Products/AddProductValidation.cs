using Curriculo.Domain.Commands.Products;

namespace Curriculo.Domain.Validations.Products
{
    public class AddProductValidation : ProductValidation<AddProductCommand>
    {
        public AddProductValidation()
        {
            NameValidate();
            DescriptionValidate();
        }
    }
}
