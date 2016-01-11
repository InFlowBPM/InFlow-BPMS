using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_MessageType
    {
        [Column(Order = 0), Key, ForeignKey("PD_Process")]
        public int PD_Process_Id { get; set; }
        public virtual PD_Process PD_Process { get; set; }

        [Column(Order = 1), Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual PersistableStringCollection Parameters { get; set; }

        public PD_MessageType()
        {
            Parameters = new PersistableStringCollection();
        }
    }

    public class PD_MessageTypeDTO
    {
        public int PD_Process_Id { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual PersistableStringCollection Parameters { get; set; }

        public PD_MessageTypeDTO()
        {
            Parameters = new PersistableStringCollection();
        }
    }
}
