using strict.InFlow.Designer.BODb;
using strict.InFlow.Designer.BODb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Helpers.BO
{
    public class Model2Html
    {

        #region header

        private string title = @"
<h2>{0}</h2>
";

        #endregion header

        #region formdata

        private string cshtmlForm = @"

    {0}

";

        private string htmlTable = @"
<table>
{0}
</table>
";


        private string htmlTableItem = @"
    <tr>
        <td>#label({0})#</td>
        <td>{1}</td>
    </tr>
";

        private string cshtmlforeach = @"
#foreach({0} in {1}){{
            {2}
        }}#
";

        private string cshtmleditorfor = @"#editor({0})#";

        #endregion formdata


        private int BOid;
        private BODdb db;

        private BOD_Item root;
        private BOD_BO bo;

        public Model2Html(int id)
        {
            this.BOid = id;
            db = new BODdb();

            bo = db.BOD_BOs.Find(id);
            root = db.BOD_Items.Where(r => r.BOD_BO_Id == id && r.ParentItem == null).First();


        }


        public string getcsHTML()
        {
          

           string form = string.Format(title, bo.Name);


            form = form + string.Format(cshtmlForm, createObject(root, root));


            return form;
        }


        private BOD_Item getRoot(BOD_Item item)
        {
            if(item.ParentItem == null)
            {
                return item;
            }
            if(item.ParentItem.Type == POD_DataTypes._array)
            {
                return item;
            }
            return getRoot(item.ParentItem);
        }

        private string createObject(BOD_Item item, BOD_Item root)
        {
            string html = "";

            string items = "";

            

            foreach (var i in item.ChildItems)
            {
                string path = getPath(i, getRoot(i));
                items = items + string.Format(htmlTableItem, path, createHtmlEditor(i, path));
            }

            html = string.Format(htmlTable, items);

            return html;
        }

        private string createHtmlEditor(BOD_Item i, string path)
        {
            string ed = "";

            if (i.Type == POD_DataTypes._object)
            {
                ed = createObject(i, i);
            }
            else if (i.Type == POD_DataTypes._array)
            {
                string p = i.ChildItems.First().Name;

                ed = string.Format(cshtmlforeach, p, path, string.Format(htmlTableItem, p, createHtmlEditor(i.ChildItems.First(), p)));
            }
            else
            {
                ed = string.Format(cshtmleditorfor, path);
            }

            return ed;
        }


        private string getPath(BOD_Item item, BOD_Item root)
        {
         
            string path = "";

            /*if (item.ParentItem == null)
                return "Model." + item.Name;

            else */
            if (item.ParentItem == root)
            {
                if(item.ParentItem.ParentItem == null)
                    return item.Name;
                else
                    return root.Name + "." + item.Name;
            }
            else
            {
                return getPath(item.ParentItem, root) + "." + item.Name;
            }
        }


    }
}