using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class WS_Folder
    {
        public int Id { get; set; }

        public int? Parent_Id { get; set; }

        [ForeignKey("Parent_Id")]
        public virtual WS_Folder Parent { get; set; }

        public virtual ICollection<WS_Folder> Children { get; set; }

        public virtual ICollection<WS_Project> Projects { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
