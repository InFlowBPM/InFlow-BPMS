using strict.InFlow.Designer.BODb.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.BODb
{
    public class BODdb : DbContext
    {
        public BODdb()
            : base("DefaultConnection")
        {
        }

        public DbSet<BOD_BO> BOD_BOs { get; set; }

        public DbSet<BOD_Item> BOD_Items { get; set; }

    }
}
