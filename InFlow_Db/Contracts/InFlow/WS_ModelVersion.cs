using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class WS_ModelVersion
    {
         [Column(Order = 0), Key, ForeignKey("WS_Project")]
        public int WS_ProjectId { get; set; }

         public virtual WS_Project WS_Project { get; set; }

         [Column(Order = 1), Key]
        public int Version { get; set; }

        public int PD_ProcessId { get; set; }
    }
}
