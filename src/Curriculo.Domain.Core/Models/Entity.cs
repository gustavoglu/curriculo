using System;

namespace Curriculo.Domain.Core.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string DeleteBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
