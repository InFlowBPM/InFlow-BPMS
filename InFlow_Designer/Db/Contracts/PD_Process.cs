using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_Process
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PD_Subject> Subjects { get; set; }
        public virtual ICollection<PD_Message> Messages { get; set; }
        public virtual ICollection<PD_MessageType> MessageTypes { get; set; }
        public virtual ICollection<PD_Parameter> Parameters { get; set; }

        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }
        public bool Locked { get; set; }
        public string LockedBy { get; set; }

        public PD_Process()
        {
            Subjects = new List<PD_Subject>();
            Messages = new List<PD_Message>();
            MessageTypes = new List<PD_MessageType>();
            Parameters = new List<PD_Parameter>();
            Locked = false;
        }
    }

    public class PD_ProcessDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Locked { get; set; }
        public string LockedBy { get; set; }
    }

    
}