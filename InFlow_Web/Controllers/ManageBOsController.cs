using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using strict.InFlow.Designer.BODb;
using strict.InFlow.Designer.BODb.Contracts;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Helpers.BO;
using strICT.InFlow.Web.Models;
using strICT.InFlow.Web.Models.ManageBos;
using strICT.InFlow.WFM.BO_Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor")]
    public class ManageBOsController : Controller
    {
        BODb _BOdb = new BODb();
        BODdb _BODdb = new BODdb();


        public ActionResult Index()
        {
            List<BusinessObjectDTO> model = new List<BusinessObjectDTO>();
            _BOdb.BusinessObjects.ToList().ForEach(o => model.Add(new BusinessObjectDTO() { Id = o.Id, Name = o.Name }));


            return View(model);
        }


        public ActionResult deleteBO(int id)
        {
            var bo = _BOdb.BusinessObjects.Find(id);

            if (_BOdb.BusinessObjectInstances.Count(r => r.BusinessObjectId == id) == 0)
            {

               // string path = Server.MapPath("~/" + bo.VirtualPath);

                _BOdb.BusinessObjects.Remove(bo);

                _BOdb.SaveChanges();

                //System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }

        private void cleanBOs()
        {
            var bos = _BODdb.BOD_BOs.ToList();

            List<int> ids = new List<int>();
            bos.Where(r => r.LastChange.AddMinutes(10) < DateTime.Now).ToList().ForEach(i => ids.Add(i.Id));

            ids.ForEach(item => _BODdb.BOD_BOs.Remove(_BODdb.BOD_BOs.Find(item)));

            _BODdb.SaveChanges();
        }

        public ActionResult newBO()
        {

            cleanBOs();


            BOD_BO bo = new BOD_BO() { Name = "NEWBO" };
            _BODdb.BOD_BOs.Add(bo);

            _BODdb.SaveChanges();


            BOD_Item root = new BOD_Item() { BO = bo, Name = "schema1", Type = POD_DataTypes._object, Id = 0 };
            _BODdb.BOD_Items.Add(root);
            _BODdb.SaveChanges();


            return RedirectToAction("ViewBO", new { id = bo.Id });
        }

        public ActionResult generateBO(int id)
        {


            Model2JSON mj = new Model2JSON(id);

            string jsonschema = mj.getSchema();
            string jsondata = mj.getDefaultData();

            Model2Html mh = new Model2Html(id);

            string html = mh.getcsHTML();

            BO_BusinessObject bo = new BO_BusinessObject();

            bo.Name = "new BO" + id;
            bo.DefaultData = jsondata;
            bo.JsonSchema = jsonschema;
            bo.ViewData = html;

            _BOdb.BusinessObjects.Add(bo);
            _BOdb.SaveChanges();

            //bo.VirtualPath = "/Views/BORepository/bo" + bo.Id + ".cshtml";
            _BOdb.SaveChanges();

            //writeViewData(bo.VirtualPath, html);

            _BODdb.BOD_BOs.Remove(_BODdb.BOD_BOs.Find(id));
            _BODdb.SaveChanges();

            return RedirectToAction("Details", new { id = bo.Id });
        }

        #region borawdata
        public ActionResult Details(int id)
        {
            BusinessObjectDetails model;

            if (id > 0)
            {
                var bo = _BOdb.BusinessObjects.Find(id);

                //string viewData = readViewData(bo.VirtualPath);

                model = new BusinessObjectDetails() { Id = bo.Id, Name = bo.Name, JsonSchema = bo.JsonSchema, DefaultData = bo.DefaultData , ViewData = bo.ViewData }; // ,ViewData = viewData };
            }
            else
            {
                model = new BusinessObjectDetails() { Id = -1, Name = "Name", DefaultData = "", JsonSchema = "" , ViewData = "" };  // ,ViewData = viewData };
            }

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Details(BusinessObjectDetails model)
        {
            BO_BusinessObject bo;

            bool writeaccess = false;

            if (model.Id > 0)
            {
                bo = _BOdb.BusinessObjects.Find(model.Id);
                writeaccess = (_BOdb.BusinessObjectInstances.Count(r => r.BusinessObjectId == model.Id) == 0);
            }
            else
            {
                bo = new BO_BusinessObject();
                writeaccess = true;
            }


            if (writeaccess)
            {

                bo.Name = model.Name;
                bo.DefaultData = model.DefaultData;
                bo.JsonSchema = model.JsonSchema;
                bo.ViewData = model.ViewData;



                if (model.Id < 0)
                {
                    _BOdb.BusinessObjects.Add(bo);
                }
                _BOdb.SaveChanges();

                /*if (model.Id < 0)
                {
                    bo.VirtualPath = "/Views/BORepository/bo" + bo.Id + ".cshtml";
                    _BOdb.SaveChanges();
                }*/

                //writeViewData(bo.VirtualPath, model.ViewData);
            }

            return RedirectToAction("Index");
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult PreviewBO(int id)
        {
            var bo = _BOdb.BusinessObjects.Find(id);

            BORender bor = new BORender();


            ViewBOModel model = new ViewBOModel();

            //dynamic model =  new dynamic();// Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(bo.DefaultData);
            model.BObjectIdentifier = id;
            //model.BObjectSchema = JObject.Parse(bo.JsonSchema);
            //model.BObjectErrors = null;



            model.ViewData = bor.createHTML(bo.DefaultData , bo.JsonSchema ,bo.ViewData);

            //return View("~/Views/BusinessObject/BusinessObject.cshtml", "~/Views/BusinessObject/_BOLayout.cshtml", model);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult SubmitBusinessObject(int id)
        {

            var schemastring = _BOdb.BusinessObjects.Find(id).JsonSchema;

         
           // string flat = Request.Form.ToString().Replace("%5b", "[").Replace("%5d", "]");
           // string jsonstring = FlatJson.FlatJsonToJsonTree(flat, schemastring);

            string jsonstring = FlatJson.RequestFormToJsonTree(Request.Form, schemastring);

            JObject data = JObject.Parse(jsonstring);



            JsonSchema schema = JsonSchema.Parse(schemastring);

            IList<string> messages;
            bool valid = data.IsValid(schema, out messages);


            if (valid)
            {
                ViewBag.BObjectIdentifier = id;
                ViewBag.Json = jsonstring;

                Dictionary<string, string> model = new Dictionary<string, string>();
                model.Add("json", jsonstring);

                return PartialView(model);
            }
            else
            {
                BORender bor = new BORender();
                string boview = _BOdb.BusinessObjects.Find(id).ViewData;
                ViewBOModel model = new ViewBOModel();
                //dynamic model = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonstring);
                model.BObjectIdentifier = id;
                // model.BObjectSchema = JObject.Parse(schemastring);
                model.BObjectErrors = new List<string>(messages);
                model.ViewData = bor.createHTML(jsonstring, schemastring ,boview);
               

                return PartialView("PreviewBO", model);
            }

        }

        /*
        private byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str.ToCharArray());
        }

        
        private string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }*/


        private string readViewData(string path)
        {
            path = Server.MapPath("~/" + path);
            StreamReader streamReader = new StreamReader(path);

            string file = streamReader.ReadToEnd();

            streamReader.Close();
            return file;
        }


        private void writeViewData(string path, string data)
        {
            path = Server.MapPath("~/" + path);
            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(data);

                outfile.Close();
            }
        }

        #endregion borawdata

        #region bodesigner
        public ActionResult ViewBO(int id)
        {
            var root = _BODdb.BOD_Items.Where(r => r.ParentItem_Id == null && r.BOD_BO_Id == id).First();

            BOD_Item_Model m = createModel(root);


            return View(m);
        }

        public ActionResult ItemDetail(int boid, int id, int parentId)
        {
            BOD_Item_Model m;

            var parent = _BODdb.BOD_Items.Find(boid, parentId);
            if (id < 0)
            {
                m = new BOD_Item_Model() {IsArray = parent.Type == POD_DataTypes._array ,boid = boid, Id = -1, Name = "", Type = POD_DataTypes._string, ChildItems = new List<BOD_Item_Model>(), ParentId = parentId };
            }
            else
            {
                var item = _BODdb.BOD_Items.Where(r => r.Id == id && r.BOD_BO_Id == boid).First();
                m = new BOD_Item_Model() { IsArray = parent.Type == POD_DataTypes._array, boid = boid, Id = item.Id, Name = item.Name, Type = item.Type, ChildItems = new List<BOD_Item_Model>(), ParentId = item.ParentItem_Id };

            }

            return PartialView(m);
        }

        public ActionResult DeleteItem(int boid, int id)
        {
            var item = _BODdb.BOD_Items.Find(boid, id);


            deleteItemRec(item);

            _BODdb.SaveChanges();
            return RedirectToAction("ViewBO", new { id = boid });
        }

        private void deleteItemRec(BOD_Item item)
        {
            if (item.ChildItems.Count() > 0)
            {
                List<BOD_Item> items = item.ChildItems.ToList();
                foreach (var i in items)
                {
                    deleteItemRec(i);
                }
            }
            _BODdb.BOD_Items.Remove(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemDetail(BOD_Item_Model model)
        {
            int boid;
            if (model.Id < 0)
            {
                var parent = _BODdb.BOD_Items.Find(model.boid, model.ParentId);
                boid = parent.BOD_BO_Id;
                BOD_Item newitem = new BOD_Item() { BO = parent.BO, Type = getType(model.Type_String), ParentItem = parent, Name = model.Name, Id = IdHelper.getBODItemId(_BODdb, model.boid) };

                if (newitem.Type == POD_DataTypes._array)
                {

                    BOD_Item listDefinition = new BOD_Item() { BO = newitem.BO, Type = POD_DataTypes._string, ParentItem = newitem, Name = "item", Id = IdHelper.getBODItemId(_BODdb, model.boid) + 1 };
                    _BODdb.BOD_Items.Add(listDefinition);

                }

                _BODdb.BOD_Items.Add(newitem);

                _BODdb.SaveChanges();
            }
            else
            {
                var item = _BODdb.BOD_Items.Find(model.boid, model.Id);

                var parent = _BODdb.BOD_Items.Find(model.boid, item.ParentItem_Id);

                BOD_Item_Model origm = new BOD_Item_Model() { IsArray = parent.Type == POD_DataTypes._array ,  boid = item.BOD_BO_Id, Id = item.Id, Name = item.Name, Type = item.Type };
                boid = item.BOD_BO_Id;
                item.Name = model.Name;

                if (!origm.Type_String.Equals(model.Type_String))
                {

                    item.Type = getType(model.Type_String);

                    if (item.Type == POD_DataTypes._array)
                    {
                        _BODdb.BOD_Items.RemoveRange(item.ChildItems);
                        BOD_Item listDefinition = new BOD_Item() { BO = item.BO, Type = POD_DataTypes._string, ParentItem = item, Name = "item", Id = IdHelper.getBODItemId(_BODdb, model.boid) };
                        _BODdb.BOD_Items.Add(listDefinition);

                    }
                    else if (item.Type != POD_DataTypes._object)
                    {
                        if (item.ChildItems.Count() > 0)
                        {
                            _BODdb.BOD_Items.RemoveRange(item.ChildItems);
                        }
                    }
                }
                _BODdb.SaveChanges();
            }

            _BODdb.BOD_BOs.Find(model.boid).LastChange = DateTime.Now;
            _BODdb.SaveChanges();

            return RedirectToAction("ViewBO", new { id = boid });
        }


        /*
        public string ViewJsonSchema()
        {
            string m = "";

            Model2JSON mj = new Model2JSON(2);

            m = mj.getSchema();

            return m;
        }

        public string ViewJsonDefault()
        {
            string m = "";

            Model2JSON mj = new Model2JSON(2);

            m = mj.getDefaultData();

            return m;
        }

        public string ViewCSHtml()
        {
            string h = "";

            Model2Html hj = new Model2Html(2);

            h = hj.getcsHTML();

            return h;
        }
        */


        private BOD_Item_Model createModel(BOD_Item item)
        {
            BOD_Item_Model m = new BOD_Item_Model() {IsArray = false, boid = item.BOD_BO_Id, Id = item.Id, Name = item.Name, Type = item.Type, ChildItems = new List<BOD_Item_Model>(), ParentId = item.ParentItem_Id };

            if (item.ChildItems.Count > 0)
            {
                foreach (var child in item.ChildItems)
                {
                    m.ChildItems.Add(createModel(child));
                }
            }


            return m;
        }

        private POD_DataTypes getType(string Type_String)
        {
            if (Type_String == "string")
            {
                return POD_DataTypes._string;
            }
            else if (Type_String == "integer")
            {
                return POD_DataTypes._integer;
            }
            else if (Type_String == "number")
            {
                return POD_DataTypes._number;
            }
            else if (Type_String == "boolean")
            {
                return POD_DataTypes._boolean;
            }
            else if (Type_String == "array")
            {
                return POD_DataTypes._array;
            }

            return POD_DataTypes._object;

        }
        #endregion bodesigner

    }
}