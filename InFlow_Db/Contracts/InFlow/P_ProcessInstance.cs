using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    
    /// <summary>
    /// Entity Process
    /// </summary>
    public class P_ProcessInstance
    {
        public string Id { get; set; }

        public int P_Process_Id { get; set; }

        public DateTime? DateStarted { get; set; }

        public int StartedBySubject_Id { get; set; }

        public string StartedByUser { get; set; }

        public DateTime? DateEnded { get; set; }

        public int EndedBySubject_Id { get; set; }

        public string EndedByUser { get; set; }

        public bool Ended { get; set; }


        /// <summary>
        /// constructor
        /// </summary>
        public P_ProcessInstance(string processinstanceid, int P_Process_Id, int StartedBySubject_Id, string StartedByUser)
        {
            this.Ended = false;
            this.DateStarted = DateTime.Now;

            this.Id = processinstanceid;
            this.P_Process_Id = P_Process_Id;
            this.StartedBySubject_Id = StartedBySubject_Id;
            this.StartedByUser = StartedByUser;
            
        }

        public P_ProcessInstance()
        {
        }

    }
}
