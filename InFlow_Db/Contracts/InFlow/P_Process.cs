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
    public class P_Process
    {
        public int Id { get; set; }

        [ForeignKey("WS_Project")]
        public int WS_ProjectId { get; set; }

        public virtual WS_Project WS_Project { get; set; }

        public int WS_Project_Version { get; set; }

       // public string Name { get; set; }
        public string ProcessInfo { get; set; }

        public DateTime? PublishDate { get; set; }

        public string GlobalProcessName { get; set; } 

        public string WFM_RootScope { get; set; } //i.e. DPMS-Azure

        public string WFM_ProcessScope { get; set; } //i.e. InternalOrder

        public virtual List<P_ProcessSubject> ProcessSubjects { get; set; }

        public bool Active { get; set; }


        /// <summary>
        /// constructor
        /// </summary>
        public P_Process()
        {
            ProcessSubjects = new List<P_ProcessSubject>();
            PublishDate = DateTime.Now;
            Active = true;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        public P_Process(string processScopeName)
        {
            WFM_ProcessScope = processScopeName;
            ProcessSubjects = new List<P_ProcessSubject>();
            PublishDate = DateTime.Now;
            Active = true;
        }
    }
}
