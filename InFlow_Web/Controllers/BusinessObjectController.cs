using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Helpers;
using strICT.InFlow.Web.Helpers.BO;
using strICT.InFlow.Web.Models;
using strICT.InFlow.WFM.BO_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{


    [Authorize]
    public class BusinessObjectController : Controller
    {
        BODb _db = new BODb();
        InFlowDb _inFlowDb = new InFlowDb();

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult BusinessObject(int id, int taskId)
        {
            bool userhasboright = false;

            JobsHelper jhelper = new JobsHelper();

            var task = _inFlowDb.T_Tasks.Find(taskId);
            var boi = _db.BusinessObjectInstances.Find(id);

            bool readOnly = true;

            bool usercanaccessTask = jhelper.CanUserAccessTask(taskId, User.Identity.Name);

            if (usercanaccessTask)
            {
                if (task.EditableParameters.Contains("{\"Type\":\"bobasic\",\"Value\":{\"bo\":"
                    + boi.BusinessObjectId + ",\"boi\":"
                + boi.Id + "}}"))
                {
                    userhasboright = true;
                    if(task.Done == false)
                    {
                        readOnly = false;
                    }
                }
                else if (task.ReadableParameters.Contains("{\"Type\":\"bobasic\",\"Value\":{\"bo\":"
                    + boi.BusinessObjectId + ",\"boi\":"
                + boi.Id + "}}"))
                {
                    userhasboright = true;
                }
            }


            if (userhasboright)
            {
                BORender bor = new BORender();
                ViewBOModel model = new ViewBOModel();
               // dynamic model = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(boi.Data);
                model.BObjectIdentifier = id;
                //model.BObjectSchema = JObject.Parse(boi.BusinessObject.JsonSchema);
                //model.BObjectErrors = null;
                model.ViewData = bor.createHTML(boi.Data, boi.BusinessObject.JsonSchema , boi.BusinessObject.ViewData);
                model.ReadOnly = readOnly;
                ViewBag.TaskId = taskId;

                return PartialView(model);
            }
            else
            {
                return PartialView("Accessdenied");
            }
        }

        [HttpPost]
        public ActionResult SubmitBusinessObject(int id, int taskId)
        {

            bool userhaseditrights = false;

            JobsHelper jhelper = new JobsHelper();

            var task = _inFlowDb.T_Tasks.Find(taskId);
            var boi = _db.BusinessObjectInstances.Find(id);

            if (!task.Done)
            {
                bool usercanaccessTask = jhelper.CanUserAccessTask(taskId, User.Identity.Name);

                if (usercanaccessTask)
                {
                    if (task.EditableParameters.Contains("{\"Type\":\"bobasic\",\"Value\":{\"bo\":"
                        + boi.BusinessObjectId + ",\"boi\":"
                    + boi.Id + "}}"))
                    {
                        userhaseditrights = true;
                    }
                }
            }

            if (userhaseditrights)
            {
                var schemastring = _db.BusinessObjectInstances.Find(id).BusinessObject.JsonSchema;



                string jsonstring = FlatJson.RequestFormToJsonTree(Request.Form, schemastring);

                JObject data = JObject.Parse(jsonstring);



                JsonSchema schema = JsonSchema.Parse(schemastring);

                IList<string> messages;
                bool valid = data.IsValid(schema, out messages);

                if (valid)
                {
                    ViewBag.BObjectIdentifier = id;
                    ViewBag.Json = jsonstring;

                    boi = _db.BusinessObjectInstances.Find(id);
                    boi.Data = jsonstring;
                    _db.SaveChanges();

                    Dictionary<string, string> model = new Dictionary<string, string>();
                    model.Add("json", jsonstring);

                    return PartialView(model);
                }
                else
                {
                    boi = _db.BusinessObjectInstances.Find(id);
                    BORender bor = new BORender();

                    ViewBOModel model = new ViewBOModel();
                    //dynamic model = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonstring);
                    model.BObjectIdentifier = id;
                   // model.BObjectSchema = JObject.Parse(schemastring);
                    model.BObjectErrors = new List<string>(messages);
                    model.ViewData = bor.createHTML(jsonstring, boi.BusinessObject.JsonSchema , boi.BusinessObject.ViewData);
                    ViewBag.TaskId = taskId;

                    return PartialView("BusinessObject",  model);
                }
            }
            else
            {
                return PartialView("Accessdenied");
            }

        }
    }
}