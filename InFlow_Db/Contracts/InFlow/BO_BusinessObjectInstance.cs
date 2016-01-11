using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class BO_BusinessObjectInstance
    {
        [Key]
        public int Id { get; set; }


        public int BusinessObjectId { get; set; }

        [ForeignKey("BusinessObjectId")]
        public virtual BO_BusinessObject BusinessObject { get; set; }

        public string Data { get; set; }
    }
}
