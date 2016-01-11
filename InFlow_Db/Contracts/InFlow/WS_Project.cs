using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class WS_Project
    {
        [Key]
        public int Id { get; set; }

        public int Folder_Id { get; set; }

        [ForeignKey("Folder_Id")]
        public virtual WS_Folder Folder { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<WS_Subject> Subjects { get; set; }

        public int CurrentVersion { get; set; }

        public virtual ICollection<WS_ModelVersion> ModelVersions { get; set; }

        public bool Deleted { get; set; }

        public WS_Project()
        {
            Deleted = false;
        }
    }

    
}
