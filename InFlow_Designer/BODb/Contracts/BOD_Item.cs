using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace strict.InFlow.Designer.BODb.Contracts
{
    public class BOD_Item
    {
        [Column(Order = 0), Key, ForeignKey("BO")]
        public int BOD_BO_Id { get; set; }

        [Column(Order = 1), Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public POD_DataTypes Type { get; set; }

        [Column(Order = 2), ForeignKey("ParentItem")]
        public int? ParentItem_BOD_Id { get; set; }

        [Column(Order = 3), ForeignKey("ParentItem")]
        public int? ParentItem_Id { get; set; }


        public virtual BOD_BO BO { get; set; }


        public virtual BOD_Item ParentItem { get; set; }

        public virtual ICollection<BOD_Item> ChildItems { get; set; }

        public BOD_Item()
        {
            ChildItems = new List<BOD_Item>();
        }

    }

    public enum POD_DataTypes { _string, _integer, _number, _boolean, _object, _array };
}
