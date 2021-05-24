using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
            //LastModified = lastModified;
        }

    }
}
