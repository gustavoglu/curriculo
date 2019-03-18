using Curriculo.Domain.Interfaces.Repositories;
using Curriculo.Domain.Models;
using Curriculo.Infra.Data.Context;

namespace Curriculo.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
