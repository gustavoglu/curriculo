using Curriculo.Domain.Core.Models;
using System;

namespace Curriculo.Domain.Models
{
    public class Product : Entity
    {
        protected Product() { }
        public Product(string name, string productTypeId, string description = null, decimal? price = null)
        {
            Name = name;
            Description = description;
            ProductTypeId = productTypeId;
            Price = price ?? 0;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProductTypeId { get; set; }
        public decimal? Price { get; private set; }

        public ProductType ProductType { get; set; }

        public static class ProductFactory
        {
            public static Product Full(string id, string name, string productTypeId,string createBy,DateTime? createAt,
                                        string updateBy,DateTime? updateAt,string deleteBy,DateTime? deleteAt,
                                        bool isDeleted, string description = null, decimal? price = null)
            {
                return new Product(name, productTypeId, description, price)
                {
                    Id = id,
                    CreateAt = createAt,
                    CreateBy = createBy,
                    UpdateAt = updateAt,
                    UpdateBy = updateBy,
                    DeleteAt = deleteAt,
                    DeleteBy = deleteBy,
                    IsDeleted = isDeleted
                };
            }
        }
    }
}
