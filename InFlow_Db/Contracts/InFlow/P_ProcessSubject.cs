using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    
    /// <summary>
    /// Entity ProcessSubject
    /// </summary>
    public class P_ProcessSubject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Process_Id { get; set; }

        [ForeignKey("Process_Id")]
        public virtual P_Process Process { get; set; }

        public bool CanBeStarted { get; set; }

        public string WFM_WFName { get; set; } //Name of the corresponding WF

        public int U_Role_Id { get; set; }

        public bool MultiSubject { get; set; }


        [ForeignKey("U_Role_Id")]
        public virtual U_Role U_Role { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public P_ProcessSubject() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="subjectName">name of the processsubject</param>
        /// <param name="canBeStarted">this subjects can start the process?</param>
        /// <param name="wfName">Name of the workflow within workflow manager</param>
        public P_ProcessSubject(string subjectName, bool canBeStarted, string wfName, int RoleId, bool multiSubject)
        {
            Name = subjectName;
            CanBeStarted = canBeStarted;
            WFM_WFName = wfName;
            U_Role_Id = RoleId;
            MultiSubject = multiSubject;
        }
    }
}
