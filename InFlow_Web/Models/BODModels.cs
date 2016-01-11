using strict.InFlow.Designer.BODb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Models
{
    public class BOD_Item_Model
    {
        public int boid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }

        private POD_DataTypes _Type;
        public POD_DataTypes Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;

                if (_Type == POD_DataTypes._string)
                {
                    Type_String = "string";

                }
                else if (_Type == POD_DataTypes._integer)
                {
                    Type_String = "integer";
                }
                else if (_Type == POD_DataTypes._number)
                {
                    Type_String = "number";
                }
                else if (_Type == POD_DataTypes._boolean)
                {
                    Type_String = "boolean";
                }
                else if (_Type == POD_DataTypes._array)
                {
                    Type_String = "array";
                }
                else if (_Type == POD_DataTypes._object)
                {
                    Type_String = "object";
                }

                Types.Where(r => r.Value == Type_String).First().Selected = true;
            }
        }


        public string Type_String { get; set; }



        public List<BOD_Item_Model> ChildItems { get; set; }


        public List<SelectListItem> Types { get; set; }

        private bool _IsArray;
        public bool IsArray { 
            get
            {
                return _IsArray;
            }
            set
            {
                _IsArray = value;
                Types = new List<SelectListItem>();

            Types.Add(new SelectListItem() { Selected = false, Text = "string", Value = "string" });
            Types.Add(new SelectListItem() { Selected = false, Text = "integer", Value = "integer" });
            Types.Add(new SelectListItem() { Selected = false, Text = "number", Value = "number" });
            Types.Add(new SelectListItem() { Selected = false, Text = "boolean", Value = "boolean" });
            Types.Add(new SelectListItem() { Selected = false, Text = "object", Value = "object" });

            if(!value)
                Types.Add(new SelectListItem() { Selected = false, Text = "array", Value = "array" });
        }
        }


        public BOD_Item_Model()
        {
        }

    }
}