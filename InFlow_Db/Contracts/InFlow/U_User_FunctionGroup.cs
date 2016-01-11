using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class U_User_FunctionGroup
    {
        [Key, Column(Order = 0)]
        public string Username { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("FunctionGroup")]
        public int FunctionGroup_Id { get; set; }

        public virtual U_FunctionGroup FunctionGroup { get; set; }
    }
}
