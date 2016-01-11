using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_Parameter
    {
        [Column(Order = 0), Key, ForeignKey("PD_Process")]
        public int PD_Process_Id { get; set; }
        public virtual PD_Process PD_Process { get; set; }

        [Column(Order = 1), Key]
        public string Name { get; set; }

        public string Config { get; set; }

        public PD_Parameter(string name)
        {
            Name = name;
            Config = "{\"Type}\":\"string\",\"Value\":\"\"}";
        }

        public PD_Parameter()
        {

        }
    }
}
