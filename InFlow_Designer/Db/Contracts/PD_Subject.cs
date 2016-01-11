using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_Subject
    {
        [Column(Order = 0), Key, ForeignKey("PD_Process")]
        public int PD_Process_Id { get; set; }
        public virtual PD_Process PD_Process { get; set; }

        [Column(Order = 1), Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool MultiSubject { get; set; }
        public bool ExternalSubject { get; set; }
        public bool CanBeStarted { get; set; }
        public virtual ICollection<PD_State> States { get; set; }
        public virtual ICollection<PD_Transition> Transitions { get; set; }
        public PersistableStringCollection GlobalParameters { get; set; }
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }

        public string ExternalSubjectId { get; set; }

        public int CanvasWidth { get; set; }
        public int CanvasHeight { get; set; }

        public PD_Subject()
        {
            States = new List<PD_State>();
            Transitions = new List<PD_Transition>();
            GlobalParameters = new PersistableStringCollection();
            CanBeStarted = false;
            ExternalSubject = false;
            MultiSubject = false;
        }
    }

    public class PD_SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool MultiSubject { get; set; }
        public bool ExternalSubject { get; set; }
        public bool CanBeStarted { get; set; }
        public int PositionTop { get; set; }
        public int PositionLeft { get; set; }
    }
}
