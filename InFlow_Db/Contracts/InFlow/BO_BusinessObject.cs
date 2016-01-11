using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class BO_BusinessObject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        //public string VirtualPath { get; set; }

        public string ViewData { get; set; }

        public string JsonSchema { get; set; }

        public string DefaultData { get; set; }
    }
}
