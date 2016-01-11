using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class U_FunctionGroup
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<U_Role> Roles { get; set; }

        public virtual ICollection<U_User_FunctionGroup> Users { get; set; }

        public U_FunctionGroup()
        {
            Roles = new HashSet<U_Role>();

            Users = new List<U_User_FunctionGroup>();
        }
    }
}
