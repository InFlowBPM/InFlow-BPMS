using strict.InFlow.Designer.BODb;
using strict.InFlow.Designer.BODb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Helpers.BO
{
    public class Model2JSON
    {

        #region schemadefiniton
        private string _schema =
@"{{
    ""description"": ""{0}"",
    ""type"": ""object"",
	""properties"":
	{{
           {1}
    }}
}}";

        private string _propertysimple =
@" ""{0}"": {{""type"":""{1}""}},
";

        private string _array =
@" ""{0}"": {{
		""type"": ""array"",
		""items"": {{ {1} }}
		}},
";

        private string _arrayItemSimple =
@" ""type"":""{0}"" ";


        private string _arrayItemObject =
@" ""type"" : ""object"",
				""properties"" : {{
				{0}
				}}
";

        private string _object =
@" ""{0}"": {{
			""type"":""object"",
			""properties"":{{
			{1}
			}}
		}},
";
        #endregion schemadefinition

        #region defaultdata

        private string _data = @" ""{0}"":{1}, ";

        private string _dataArray = @" ""{0}"":[{1}], ";

        private string _dataObject = @" ""{0}"":{{ {1} }}, ";

        #endregion defaultdata

        private int BOid;
        private BODdb db;

        private BOD_Item root;
        private BOD_BO bo;

        private string schema;

        public Model2JSON(int id)
        {
            this.BOid = id;
            db = new BODdb();

            bo = db.BOD_BOs.Find(id);
            root = db.BOD_Items.Where(r => r.BOD_BO_Id == id && r.ParentItem == null).First();


        }


        #region defaultdata

        public string getDefaultData()
        {
            string data = "{" + createDataObjectItems(root) + "}";



            return data;
        }

        private string createDataObjectItems(BOD_Item item)
        {
            string data = "";
            foreach (var i in item.ChildItems)
            {
                if (i.Type == POD_DataTypes._array)
                {
                    data = data + createDataArray(i);
                }
                else if (i.Type == POD_DataTypes._object)
                {
                    data = data + createDataObject(i);
                }
                else
                {
                    data = data + string.Format(_data, i.Name, getDefaultValue(i));
                }


            }
            return data;
        }

        private string getDefaultValue(BOD_Item i)
        {
            if (i.Type == POD_DataTypes._boolean)
            {
                return "true";
            }
            else if (i.Type == POD_DataTypes._integer)
            {
                return "0";
            }
            else if (i.Type == POD_DataTypes._number)
            {
                return "0.0";
            }
            else
            {
                return @"""abc""";
            }
        }



        private string createDataArray(BOD_Item i)
        {

            string data = "";

            if (i.ChildItems.First().Type == POD_DataTypes._object)
            {
                data = string.Format(_dataArray, i.Name, "{" + createDataObjectItems(i.ChildItems.First()) + "}");
            }
            else if( i.ChildItems.First().Type == POD_DataTypes._array)
            {
                data = data + createDataArray(i.ChildItems.First());
            }
            else
            {
                data = string.Format(_dataArray, i.Name, getDefaultValue(i));
            }

            return data;
        }

        private string createDataObject(BOD_Item item)
        {
            string data = string.Format(_dataObject, item.Name, createDataObjectItems(item));

            return data;
        }

        #endregion defaultdata

        #region schema

        public string getSchema()
        {

            string rootitems = "";


            rootitems = createPropertyList(root);

            schema = string.Format(_schema, bo.Name, rootitems);

            return schema;
        }


        private string createPropertyList(BOD_Item item)
        {
            string list = "";

            foreach (var i in item.ChildItems)
            {
                if (i.Type == POD_DataTypes._object)
                {
                    list = list + createPropertyObject(i);
                }
                else if (i.Type == POD_DataTypes._array)
                {
                    list = list + createPropertyArray(i);
                }
                else
                {
                    list = list + createPropertySimple(i);
                }
            }

            return list;
        }

        private string createPropertyObject(BOD_Item item)
        {
            string prop;

            prop = string.Format(_object, item.Name, createPropertyList(item));

            return prop;
        }


        private string createPropertyArray(BOD_Item item)
        {
            string prop;

            string items;

            var itemsdef = item.ChildItems.First();

            if (itemsdef.Type == POD_DataTypes._object)
            {
                items = string.Format(_arrayItemObject, createPropertyList(itemsdef));
            }
            else
            {
                items = string.Format(_arrayItemSimple, bod_Type_toString(itemsdef.Type));
            }


            prop = string.Format(_array, item.Name, items);

            return prop;
        }

        private string createPropertySimple(BOD_Item item)
        {
            string prop;

            prop = string.Format(_propertysimple, item.Name, bod_Type_toString(item.Type));

            return prop;
        }

        private string bod_Type_toString(POD_DataTypes type)
        {

            if (type == POD_DataTypes._string)
            {
                return "string";

            }
            else if (type == POD_DataTypes._integer)
            {
                return "integer";
            }
            else if (type == POD_DataTypes._number)
            {
                return "number";
            }
            else if (type == POD_DataTypes._boolean)
            {
                return "boolean";
            }
            else if (type == POD_DataTypes._array)
            {
                return "array";
            }

            return "object";

        }

        #endregion schema

    }
}