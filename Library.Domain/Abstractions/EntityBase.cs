using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstractions
{
    public abstract class EntityBase
    {
        protected EntityBase() { }

        public Guid Id { get; protected init; } = Guid.NewGuid();
        public DateTime CreatedTime { get; protected init; } = DateTime.UtcNow;

        public Guid? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public User? User { get; set; }
    }
}
