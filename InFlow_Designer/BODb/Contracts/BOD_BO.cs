using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.BODb.Contracts
{
    public class BOD_BO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BOD_Item> Items { get; set; }

        public DateTime LastChange { get; set; }


        public BOD_BO()
        {
            Items = new List<BOD_Item>();
            LastChange = DateTime.Now;
        }
    }
}
