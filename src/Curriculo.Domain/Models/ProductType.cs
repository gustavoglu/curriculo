using Curriculo.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Curriculo.Domain.Models
{
    public class ProductType : Entity
    {
        protected ProductType() { }
        public ProductType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public List<Product> Products { get; set; }

        public static class ProductTypeFactory
        {
            public static ProductType Full(string id, string name ,string createBy, DateTime? createAt,
                                        string updateBy, DateTime? updateAt, string deleteBy, DateTime? deleteAt,
                                        bool isDeleted)
            {
                return new ProductType(name)
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
