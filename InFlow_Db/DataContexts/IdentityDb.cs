using Microsoft.AspNet.Identity.EntityFramework;
using strICT.InFlow.Db.Contracts.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        
        public IdentityDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserLogItem> UserLog  { get; set; }
    }
}
