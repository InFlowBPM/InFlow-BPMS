using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    /// <summary>
    /// Entity TaskProperty
    /// </summary>
    public class T_TaskProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }

        [ForeignKey("T_Task")]
        public int T_Task_Id { get; set; }

        public virtual T_Task T_Task { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public T_TaskProperty()
        { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value"></param>
        public T_TaskProperty(string value)
        {
            this.Value = value;
        }
    }
}
