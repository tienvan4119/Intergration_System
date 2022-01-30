using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Domain.Entities.Base
{
    public class Entity : Entity<int>
    {
    }

    public class Entity<T> 
    {
        public virtual T Id { get; set; }
    }

    public interface IAuditEntity
    {
        int CreatedBy { get; }
        DateTime CreatedOn { get; }
        void UpdateAudit(int createdBy, DateTime createdOn);
    }

    public class AuditEntity : Entity, IAuditEntity
    {
        public virtual int CreatedBy { get; protected set; }

        public virtual DateTime CreatedOn { get; protected set; }

        public void UpdateAudit(int createdBy, DateTime createdOn)
        {
            CreatedBy = createdBy;
            CreatedOn = createdOn;  
        }
    }
}
