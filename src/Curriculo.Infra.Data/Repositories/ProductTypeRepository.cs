using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Domain.Models;
using Curriculo.Infra.Data.Context;

namespace Curriculo.Infra.Data.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
