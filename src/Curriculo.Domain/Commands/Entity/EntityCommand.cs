using Curriculo.Domain.Core.Commands;
using System;

namespace Curriculo.Domain.Commands.Entity
{
    public abstract class EntityCommand : Command
    {
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
