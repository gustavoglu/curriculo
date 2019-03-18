using Curriculo.Domain.Commands.Entity;
using Curriculo.Domain.Models;
using System.Collections.Generic;

namespace Curriculo.Domain.Commands.ProductTypes
{
    public abstract class ProductTypeCommand : EntityCommand
    {
        public string Name { get; private set; }
        public List<Product> Products { get; set; }
    }
}
