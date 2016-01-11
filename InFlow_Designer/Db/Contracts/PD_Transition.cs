using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace strict.InFlow.Designer.Db.Contracts
{

    public class PD_Transition
    {
        [Column(Order = 0), Key, ForeignKey("PD_Subject")]
        public int PD_Process_Id { get; set; }

        [Column(Order = 1), Key, ForeignKey("PD_Subject")]
        public int PD_Subject_Id { get; set; }
        public virtual PD_Subject PD_Subject { get; set; }

        [Column(Order = 2), Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Source { get; set; }
        public int Target { get; set; }

        public PD_TransitionTypes Type { get; set; }

        public PD_Transition()
        {
        }

        public double LabelPosition { get; set; }
    }

    public class PD_TransitionDTO
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Target { get; set; }
        public PD_TransitionTypes Type { get; set; }
        public String Label { get; set; }

        public PD_TransitionDTO() { }

        public double LabelPosition { get; set; }
    }

    public enum PD_TransitionTypes { RegularTransition, TimeoutTransition, ReceiveTransition };

    public class PD_RegularTransition : PD_Transition
    {
        public string Name { get; set; }

        public PD_RegularTransition()
            : base()
        {
            Type = PD_TransitionTypes.RegularTransition;
        }
    }

    public class PD_TimeoutTransition : PD_Transition
    {
        public string TimeSpan { get; set; }

        public PD_TimeoutTransition()
            : base()
        {
            Type = PD_TransitionTypes.TimeoutTransition;
        }
    }

    public class PD_ReceiveTransition : PD_Transition
    {
        public int Message { get; set; }

        public PD_ReceiveTransition()
            : base()
        {
            Type = PD_TransitionTypes.ReceiveTransition;
        }
    }


}
