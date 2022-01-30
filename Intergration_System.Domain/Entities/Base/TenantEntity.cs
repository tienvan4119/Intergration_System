using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Domain.Entities.Base
{
    public interface ITenantEntity
    {
        int TenantId { get; }
        void UpdateTenant(int tenantId);
    }

    public abstract class TenantEntity : Entity
    {
        public int TenantId { get; set; }

        public void UpdateTenant(int tenantId)
        {
            TenantId = tenantId;
        }
    }
}
