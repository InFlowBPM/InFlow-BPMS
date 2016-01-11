using strICT.InFlow.Db.Contracts.InFlow;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.DataContexts
{
    public class BODb : DbContext
    {
        public BODb()
            : base("DefaultConnection")
        {

        }

        public BODb(string connString)
            : base(connString)
        {}

        public DbSet<BO_BusinessObject> BusinessObjects { get; set; }

        public DbSet<BO_BusinessObjectInstance> BusinessObjectInstances { get; set; }
    }
}
