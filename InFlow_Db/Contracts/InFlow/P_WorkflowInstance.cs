using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    /// <summary>
    /// Entity WorkflowInstance
    /// </summary>
    public class P_WorkflowInstance
    {
        public string Id { get; set; }

        public string ProcessInstance_Id { get; set; }

        public int ProcessSubject_Id { get; set; }

        [ForeignKey("ProcessSubject_Id")]
        public virtual P_ProcessSubject ProcessSubject { get; set; }

        public string Owner { get; set; }

        public bool IsInEndState { get; set; }

        public DateTime? DateEndState { get; set; }

        public DateTime? DateStarted { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public P_WorkflowInstance()
        {
            IsInEndState = false;
            DateStarted = DateTime.Now;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="processInstanceId"></param>
        /// <param name="guid">workflow instance id</param>
        /// <param name="processSubjectId"></param>
        /// <param name="owner"></param>
        public P_WorkflowInstance(string processInstanceId, string guid, int processSubjectId, string owner)
        {
            this.Id = guid;
            this.ProcessInstance_Id = processInstanceId;
            this.ProcessSubject_Id = processSubjectId;
            this.Owner = owner;
            DateStarted = DateTime.Now;
            IsInEndState = false;
        }
    }
}
