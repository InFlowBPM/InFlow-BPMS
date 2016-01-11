using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models.ManageBos
{
    public class BusinessObjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }


    }

    public class BusinessObjectDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ViewData { get; set; }

        public string JsonSchema { get; set; }

        public string DefaultData { get; set; }
    }
}