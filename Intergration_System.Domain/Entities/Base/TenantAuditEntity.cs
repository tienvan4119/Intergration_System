using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Domain.Entities.Base
{
    public class TenantAuditEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public void UpdateAudit(int createdBy, DateTime createdOn)
        {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }
    }
}
