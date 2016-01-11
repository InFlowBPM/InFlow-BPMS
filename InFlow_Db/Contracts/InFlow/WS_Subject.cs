using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class WS_Subject
    {
        [Key]
        public int Id { get; set; }

        public int Project_Id { get; set; }

        [ForeignKey("Project_Id")]
        public virtual WS_Project Project { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Xaml_Data { get; set; }
        
        public int U_Role_Id { get; set; }

        public bool CanBeStarted { get; set; }

        public bool MultiSubject { get; set; }
    }
}
