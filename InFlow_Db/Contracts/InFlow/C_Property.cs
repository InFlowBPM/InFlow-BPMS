using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    public class C_Property
    {
        [Key]
        public string Key { get; set; }

        public PropertyTypes Type { get; set; }

        public string Value { get; set; }
    }

   public enum PropertyTypes
   {
       STRING = 1,
       INT = 2,
       BOOL = 3
   }
}
