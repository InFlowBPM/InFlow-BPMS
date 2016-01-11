using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_Message
    {
        [Column(Order = 0), Key, ForeignKey("PD_Process")]
        public int PD_Process_Id { get; set; }
        public virtual PD_Process PD_Process { get; set; }

        [Column(Order = 1), Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(Order = 2),ForeignKey("PD_MessageType")]
        public int PD_MessageType_Process_Id { get; set; }

        [Column(Order = 3),ForeignKey("PD_MessageType")]
        public int? PD_MessageType_Id { get; set; }

        public virtual PD_MessageType PD_MessageType { get; set; }

        public int From { get; set; }

        public int To { get; set; }
        
        public PD_Message() {  }

        public String EndPoints { get; set; }
    }

    public class PD_MessageDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public double[] EndPoints { get; set; }
    }

    
}
