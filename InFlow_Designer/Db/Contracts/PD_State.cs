using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace strict.InFlow.Designer.Db.Contracts
{
    public class PD_Canvas
    {
        public int CanvasWidth { get; set; }

        public int CanvasHeight { get; set; }

        public PD_Canvas() { }

    }
    public class PD_State
    {
        [Column(Order = 0), Key, ForeignKey("PD_Subject")]
        public int PD_Process_Id { get; set; }

        [Column(Order = 1), Key, ForeignKey("PD_Subject")]
        public int PD_Subject_Id { get; set; }
        public virtual PD_Subject PD_Subject { get; set; }

        [Column(Order = 2), Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PD_StateTypes Type { get; set; }
        public string Name { get; set; }
        public bool StartState { get; set; }
        public bool EndState { get; set; }
        public int PositionLeft { get; set; }
        public int PositionTop { get; set; }

        public PD_State()
        {
        }
    }

    public enum PD_StateTypes { FunctionState, SendState, ReceiveState, RefinementState };

    public class PD_FunctionState : PD_State
    {
        public virtual PersistableStringCollection ReadableParameters { get; set; }
        public virtual PersistableStringCollection EditableParameters { get; set; }

        public PD_FunctionState()
            : base()
        {
            Type = PD_StateTypes.FunctionState;
            ReadableParameters = new PersistableStringCollection();
            EditableParameters = new PersistableStringCollection();
        }
    }


    public class PD_RefinementState : PD_FunctionState
    {
       
        public PD_RefinementState()
            : base()
        {
            Type = PD_StateTypes.RefinementState;
            ReadableParameters = new PersistableStringCollection();
            EditableParameters = new PersistableStringCollection();
        }

    }

    public class PD_SendState : PD_State
    {
        public int Message { get; set; }
        public PersistableStringCollection ReadableParameters { get; set; }
        public PersistableStringCollection EditableParameters { get; set; }

        public PD_SendState()
            : base()
        {
            Type = PD_StateTypes.SendState;
            ReadableParameters = new PersistableStringCollection();
            EditableParameters = new PersistableStringCollection();
        }
    }


    public class PD_ReceiveState : PD_State
    {
        public PD_ReceiveState()
            : base()
        {
            Type = PD_StateTypes.ReceiveState;
        }
    }



    public class PD_StateDTO
    {
        public int PD_Process_Id { get; set; }

        public int PD_Subject_Id { get; set; }

        public int Id { get; set; }
        public PD_StateTypes Type { get; set; }
        public string Name { get; set; }

        public bool StartState { get; set; }
        public bool EndState { get; set; }
        public int PositionLeft { get; set; }
        public int PositionTop { get; set; }

        public virtual PersistableStringCollection ReadableParameters { get; set; }
        public virtual PersistableStringCollection EditableParameters { get; set; }

        public int Message { get; set; }

        public PD_StateDTO()
        {
        }
    }
}
