using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models
{
    public class ViewBOModel
    {
        public int TaskId { get; set; }
        public int BObjectIdentifier { get; set; }
        public string ViewData { get; set; }

        public List<string> BObjectErrors { get; set; }

        public bool ReadOnly { get; set; }
    }
}