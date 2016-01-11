using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using strICT.InFlow.Db.Contracts.Tenant;

namespace strICT.InFlow.Db.DataContexts
{
    public class TenantDb : DbContext
    {
        public TenantDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<IssuingAuthorityKey> IssuingAuthorityKeys { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
