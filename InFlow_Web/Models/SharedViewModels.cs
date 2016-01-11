using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models.Shared
{

    public class ListViewItemModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
         
        public bool Selected { get; set; }
    }
}