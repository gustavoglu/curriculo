using Curriculo.Domain.Commands.Entity;
using Curriculo.Domain.Models;

namespace Curriculo.Domain.Commands.Products
{
    public abstract class ProductCommand : EntityCommand
    { 
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProductTypeId { get; set; }
        public decimal? Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}
