using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class U_Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<U_FunctionGroup> FunctionGroups { get; set; }

        public U_Role()
        {
            FunctionGroups = new HashSet<U_FunctionGroup>();
        }

    }
}
