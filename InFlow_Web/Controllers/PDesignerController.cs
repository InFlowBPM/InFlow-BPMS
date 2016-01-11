using strict.InFlow.Designer.Db;
using strict.InFlow.Designer.Db.Contracts;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Models.PDesignerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor")]
    public class PDesignerController : Controller
    {
        PDesignerDb _db = new PDesignerDb();
        InFlowDb _idb = new InFlowDb();
        //
        // GET: /Designer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProcess(int processid, int edit)
        {
            ViewBag.ProcessId = processid;

            var modelversion = _idb.WS_ModelVersions.First(result => result.PD_ProcessId == processid);

            ViewBag.Name = modelversion.WS_Project.Name;
            ViewBag.Version = modelversion.Version;
            ViewBag.Edit = 0;
            ViewBag.ProjectId = modelversion.WS_ProjectId;

            if (edit == 1)
            {
                var processmodel = _db.PD_Processes.Find(processid);
                if (processmodel.LockedBy == null)
                {
                    processmodel.LockedBy = User.Identity.Name;
                    _db.SaveChanges();
                    ViewBag.Edit = 1;
                }else if(processmodel.LockedBy.Equals(User.Identity.Name))
                {
                    ViewBag.Edit = 1;
                }   
            }

            return View();
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditMessageTypesList(int processid, int edit)
        {
            List<PD_MessageTypeDTO_ViewModel> Model = new List<PD_MessageTypeDTO_ViewModel>();

            var msgtypes = _db.PD_MessageTypes.Where(result => result.PD_Process_Id == processid).ToList();
            foreach (var i in msgtypes)
            {
                var type = new PD_MessageTypeDTO_ViewModel() { Id = i.Id, PD_Process_Id = i.PD_Process_Id, Name = i.Name };
                Model.Add(type);
            }
            ViewBag.ProcessId = processid;
            ViewBag.Edit = edit;
          
            return PartialView(Model);
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditMessageType(int processid, int id, int edit)
        {
            PD_MessageTypeDTO_ViewModel model;
            if (id > 0)
            {
                var i = _db.PD_MessageTypes.Find(processid, id);

                model = new PD_MessageTypeDTO_ViewModel() { Id = i.Id, PD_Process_Id = i.PD_Process_Id, Name = i.Name, Parameters = new List<PD_Parameter_ViewModel>() };

                model.Parameters = listofStringParametersToViewModel(processid, i.Parameters);
            }
            else
            {
                model = new PD_MessageTypeDTO_ViewModel() { PD_Process_Id = processid, Name = "New", Parameters = new List<PD_Parameter_ViewModel>() };
            }

            ViewBag.Edit = edit;
            model.newName = model.Name;
            return PartialView(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditMessageType(PD_MessageTypeDTO_ViewModel model)
        {
             var _p = _db.PD_Processes.Find(model.PD_Process_Id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 PD_MessageType type;
                 if (model.Id >= 0)
                 {
                     type = _db.PD_MessageTypes.Find(model.PD_Process_Id, model.Id);
                 }
                 else
                 {
                     type = new PD_MessageType() { PD_Process_Id = model.PD_Process_Id };
                     type.Id = IdHelper.getMessageTypeId(_db, model.PD_Process_Id);
                 }
                 type.Name = model.newName;
                 
                 /*
                 string[] para = model.Parameters.Split(',');
                 type.Parameters = new PersistableStringCollection();
                 para.ToList().ForEach(i => type.Parameters.Add(i));*/

                 if (model.Id < 0)
                 {
                     _db.PD_MessageTypes.Add(type);
                 }
                 else
                 {
                     var messages = _db.PD_Messages.Where(result => result.PD_MessageType_Id == type.Id && result.PD_Process_Id == type.PD_Process_Id);
                     messages.ToList().ForEach(i => updateGlobalparameters(i));
                 }

                 _db.SaveChanges();

                 return RedirectToAction("ViewProcess", new { processid = model.PD_Process_Id , edit = 1});
             }
             else
             {
                 return null;
             }
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _DeleteMessageType(int processid, int id)
        {
             var _p = _db.PD_Processes.Find(processid);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var type = _db.PD_MessageTypes.Find(processid, id);                 
                 _db.PD_MessageTypes.Remove(type);
                 //var message = _db.PD_Messages.Find(processid);
                 try
                 {           
                     var subjects = _db.PD_Subjects.Where(x => x.PD_Process_Id == processid).ToList();
                     var messageTypes = _db.PD_MessageTypes.Where(x => x.PD_Process_Id == processid).ToList();
                     int repeatedTimes = 0;
                     foreach(var i in type.Parameters){
                         foreach(var j in messageTypes){
                             if(j.Parameters.Contains(i))repeatedTimes++;
                         }
                         if(repeatedTimes==1){
                             var param = _db.PD_Parameters.Find(processid, i);
                             _db.PD_Parameters.Remove(param);
                             foreach(var j in subjects){
                                 if(j.GlobalParameters.Contains(i)) j.GlobalParameters.Remove(i);
                             }
                         }
                         repeatedTimes = 0;
                     }                     
                     _db.SaveChanges();
                 }
                 catch
                 {
                     string x = "$('#myModalErrorMessage').modal('toggle'); $('#myModalErrorMessage').modal('show');";                     
                     return JavaScript(x);
                 }
                 ViewBag.Edit = 1;
                 return RedirectToAction("_EditMessageTypesList", new { processid = processid , edit = 1});
             }
             else
             {
                 return null;
             }
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _DeleteAllMessageTypes(int processid)
        {
            var _p = _db.PD_Processes.Find(processid);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var toDelete = _db.PD_MessageTypes.Where(result => result.PD_Process_Id == processid);
                _db.PD_MessageTypes.RemoveRange(toDelete);
                //var message = _db.PD_Messages.Find(processid);
                try
                {
                    _db.SaveChanges();
                }
                catch
                {
                    string x = "$('#myModalErrorMessage').modal('toggle'); $('#myModalErrorMessage').modal('show');";
                    return JavaScript(x);
                }
                ViewBag.Edit = 1;
                return RedirectToAction("_EditMessageTypesList", new { processid = processid, edit = 1 });
            }
            else
            {
                return null;
            }
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditSubject(int processid, int subjectid, int edit)
        {
            var subject = _db.PD_Subjects.Find(processid, subjectid);
            PD_Subject_ViewModel model = new PD_Subject_ViewModel() { PD_Process_Id = subject.PD_Process_Id, Id = subject.Id, Name = subject.Name, MultiSubject = subject.MultiSubject, ExternalSubject = subject.ExternalSubject, CanBeStarted = subject.CanBeStarted };
            if (subject.ExternalSubject)
            {
                
                List<ES_ViewModel> sList = new List<ES_ViewModel>();

             //   List<P_ProcessSubject> PSList = _idb.P_ProcessSubjects.Where(x => x.Process_Id != processid && x.ExternalSubject == 0).ToList<P_ProcessSubject>();

                List<PD_Subject> PSList = _db.PD_Subjects.Where(x => x.PD_Process_Id != processid && x.ExternalSubject == false).ToList<PD_Subject>();
                try
                {
                    PSList.ForEach(x => sList.Add(new ES_ViewModel(x.PD_Process_Id + "|" + x.Id, x.PD_Process.Name + " - " + x.Name)));
                    model.ExternalSources = sList;
                    int pid = Int32.Parse(subject.ExternalSubjectId.Split('|')[0]);
                    int sid = Int32.Parse(subject.ExternalSubjectId.Split('|')[1]);
                    PD_Subject es = _db.PD_Subjects.Where(x => x.Id == sid && x.PD_Process_Id == pid).FirstOrDefault();
                    model.ExternalSubjectSource = new ES_ViewModel(subject.ExternalSubjectId, es.PD_Process.Name + " - " + es.Name);
                }
                catch (Exception e) { }
            }
            
            ViewBag.Edit = edit;
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditSubject(PD_Subject_ViewModel model)
        {
             var _p = _db.PD_Processes.Find(model.PD_Process_Id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var subject = _db.PD_Subjects.Find(model.PD_Process_Id, model.Id);
                 subject.Name = model.Name;
                 subject.MultiSubject = model.MultiSubject;
                 subject.ExternalSubject = model.ExternalSubject;
                 subject.CanBeStarted = model.CanBeStarted;


                 _db.SaveChanges();

                 return RedirectToAction("ViewProcess", new { processid = model.PD_Process_Id, edit = 1 });
             }
             else
             {
                 return null;
             }
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditMessage(int processid, int messageid, int edit)
        {
            var message = _db.PD_Messages.Find(processid, messageid);
            PD_Message_ViewModel model;
            if (message != null)
            {
                model = new PD_Message_ViewModel() { PD_Process_Id = message.PD_Process_Id, Id = message.Id };
            }
            else
            {
                model = null;
            }
            List<SelectListItem> availableTypes = new List<SelectListItem>();

            _db.PD_MessageTypes.Where(result => result.PD_Process_Id == processid).ToList().ForEach(mt => availableTypes.Add(new SelectListItem() { Value = "" + mt.Id, Text = mt.Name }));

            //if (message.From == message.To) a = 1;

            if (message.PD_MessageType != null)
            {
                model.SelectedMessageType = "" + message.PD_MessageType.Id;
                availableTypes.Find(result => result.Value == model.SelectedMessageType).Selected = true;
            }
            
            model.AvailableMessageTypes = availableTypes;

            ViewBag.Edit = edit;
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditMessage(PD_Message_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var message = _db.PD_Messages.Find(model.PD_Process_Id, model.Id);
                message.PD_MessageType_Process_Id = model.PD_Process_Id;
                message.PD_MessageType_Id = Int16.Parse(model.SelectedMessageType);

                _db.SaveChanges();

                updateGlobalparameters(message);

                return RedirectToAction("ViewProcess", new { processid = model.PD_Process_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }

        private void updateGlobalparameters(PD_Message message)
        {
            //check parameters in from and to 
            //START
            List<string> messagetypeparameters = message.PD_MessageType.Parameters.ToList();

            var from = _db.PD_Subjects.Find(message.PD_Process_Id, message.From);

            List<string> frompara = from.GlobalParameters.ToList();
            List<string> toAdd = messagetypeparameters.Except(frompara).ToList();
            toAdd.ForEach(item => from.GlobalParameters.Add(item));

            var to = _db.PD_Subjects.Find(message.PD_Process_Id, message.To);
            List<string> topara = to.GlobalParameters.ToList();
            List<string> toAddTo = messagetypeparameters.Except(topara).ToList();
            toAddTo.ForEach(item => to.GlobalParameters.Add(item));
            //END
            _db.SaveChanges();
        }

        public ActionResult ViewSubject(int processid, int subjectid, int edit)
        {
            ViewBag.ProcessId = processid;
            ViewBag.SubjectId = subjectid;

            ViewBag.Name = _db.PD_Subjects.Find(processid, subjectid).Name;

            ViewBag.Edit = 0;

            if (edit == 1)
            {
                var processmodel = _db.PD_Processes.Find(processid);
                if (processmodel.LockedBy == null)
                {
                    processmodel.LockedBy = User.Identity.Name;
                    _db.SaveChanges();
                    ViewBag.Edit = 1;
                }
                else if (processmodel.LockedBy.Equals(User.Identity.Name))
                {
                    ViewBag.Edit = 1;
                }
            }

            return View();
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditState(int processid, int subjectid, int stateid, int edit)
        {
            var state = _db.PD_States.Find(processid, subjectid, stateid);

            if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_StateTypes.FunctionState)
                return RedirectToAction("_EditFunctionState", new { processid = processid, subjectid = subjectid, stateid = stateid, edit = edit });

            else if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_StateTypes.SendState)
                return RedirectToAction("_EditSendState", new { processid = processid, subjectid = subjectid, stateid = stateid, edit = edit });

            else if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_StateTypes.ReceiveState)
                return RedirectToAction("_EditReceiveState", new { processid = processid, subjectid = subjectid, stateid = stateid, edit = edit });
            else if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_StateTypes.RefinementState)
                return RedirectToAction("_EditRefinementState", new { processid = processid, subjectid = subjectid, stateid = stateid, edit = edit });

            else
                return null;
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditFunctionState(int processid, int subjectid, int stateid, int edit)
        {
            var state = _db.PD_FunctionStates.Find(processid, subjectid, stateid);
            PD_FunctionState_ViewModel Model = new PD_FunctionState_ViewModel() { PD_Process_Id = state.PD_Process_Id, PD_Subject_Id = state.PD_Subject_Id, Id = state.Id, Name = state.Name, EndState = state.EndState , StartState = state.StartState};

            List<SelectListItem> AvailableParameters = new List<SelectListItem>();
            List<SelectListItem> SelectedEditableParameters2 = new List<SelectListItem>();
            List<SelectListItem> SelectedReadableParameters2 = new List<SelectListItem>();

            var parameters = _db.PD_Subjects.Find(processid, subjectid).GlobalParameters;
            List<String> parametersMod = new List<String>();
            foreach (var i in parameters)
            {
                if(!parametersMod.Contains(i))parametersMod.Add(i);
            }
            foreach (var i in parametersMod)
            {                
                AvailableParameters.Add(new SelectListItem() { Value = i, Text = i });

                var eNewSelectItem = new SelectListItem() { Value = i, Text = i, Selected = false };
                var rNewSelectItem = new SelectListItem() { Value = i, Text = i, Selected = false };
                AvailableParameters.Add(new SelectListItem() { Value = i, Text = i, Selected = true });
                foreach (var f in state.ReadableParameters.ToList()) { if (f == i) rNewSelectItem.Selected = true; }
                foreach (var g in state.EditableParameters.ToList()) { if (g == i) eNewSelectItem.Selected = true; }
                SelectedReadableParameters2.Add(rNewSelectItem);
                SelectedEditableParameters2.Add(eNewSelectItem);                
            }

            Model.AvailableEditableParameters = SelectedEditableParameters2;
            Model.AvailableReadableParameters = SelectedReadableParameters2;

            ViewBag.Edit = edit;
            return PartialView(Model);
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditRefinementState(int processid, int subjectid, int stateid, int edit)
        {


            /*
             * 
             * 
 {
  "ProcessParameter": "",
  "Description": "wat",
  "RefinementParameter": "wat"
}
 
             * 
             * */


            var state = _db.PD_RefinementStates.Find(processid, subjectid, stateid);
           
         


            PD_RefinementState_ViewModel Model = new PD_RefinementState_ViewModel() { PD_Process_Id = state.PD_Process_Id, PD_Subject_Id = state.PD_Subject_Id, Id = state.Id, Name = state.Name, EndState = state.EndState, StartState = state.StartState };
            Model.RefinementParameters = new List<PD_RefinementState_ParameterLink>();
            List<SelectListItem> AvailableParameters = new List<SelectListItem>();
      

           var parameters = _db.PD_Subjects.Find(processid, subjectid).GlobalParameters;
            foreach (var i in parameters)
            {
                AvailableParameters.Add(new SelectListItem() { Value = i, Text = i });

            }


            List<PD_RefinementState_ParameterLink> refparams = new List<PD_RefinementState_ParameterLink>();

            PD_RefinementState_ParameterLink parl = new PD_RefinementState_ParameterLink();


            JavaScriptSerializer js = new JavaScriptSerializer();
            foreach (var param in state.ReadableParameters)
            {

              
                var c = js.Deserialize<PD_RefinementState_ParameterLink>(param);
                Model.RefinementParameters.Add(c);


            }
            

            Model.AvailableEditableParameters = AvailableParameters;



            ViewBag.Edit = edit;
            return PartialView(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditRefinementState(PD_RefinementState_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_FunctionState state = _db.PD_FunctionStates.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                state.Name = model.Name;
                state.EndState = model.EndState;
                state.StartState = model.StartState;
                model.SelectedEditableParameters = new List<string>();
                foreach (var i in model.AvailableEditableParameters)
                {
                    if (i.Selected == true) model.SelectedEditableParameters.Add(i.Value);
                }
                model.SelectedReadableParameters = new List<string>();
                foreach (var i in model.AvailableReadableParameters)
                {
                    if (i.Selected == true) model.SelectedReadableParameters.Add(i.Text);
                }
                state.ReadableParameters = new PersistableStringCollection();
                if (model.SelectedReadableParameters != null)
                {
                    model.SelectedReadableParameters.ForEach(item => state.ReadableParameters.Add(item));
                }


                state.EditableParameters = new PersistableStringCollection();
                if (model.SelectedEditableParameters != null)
                {
                    model.SelectedEditableParameters.ForEach(item => state.EditableParameters.Add(item));
                }


                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditFunctionState(PD_FunctionState_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_FunctionState state = _db.PD_FunctionStates.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                state.Name = model.Name;
                state.EndState = model.EndState;
                state.StartState = model.StartState;
                _db.SaveChanges();
                if (model.AvailableEditableParameters == null) return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
                model.SelectedEditableParameters = new List<string>();
                foreach (var i in model.AvailableEditableParameters)
                {
                    if (i.Selected == true) model.SelectedEditableParameters.Add(i.Value);
                }
                model.SelectedReadableParameters = new List<string>();
                foreach (var i in model.AvailableReadableParameters)
                {
                    if (i.Selected == true) model.SelectedReadableParameters.Add(i.Text);
                }



                state.ReadableParameters = new PersistableStringCollection();
                if (model.SelectedReadableParameters != null)
                {
                    model.SelectedReadableParameters.ForEach(item => state.ReadableParameters.Add(item));
                }


                state.EditableParameters = new PersistableStringCollection();
                if (model.SelectedEditableParameters != null)
                {
                    model.SelectedEditableParameters.ForEach(item => state.EditableParameters.Add(item));
                }


                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditSendState(int processid, int subjectid, int stateid, int edit)
        {
            var state = _db.PD_SendStates.Find(processid, subjectid, stateid);
            PD_SendState_ViewModel Model = new PD_SendState_ViewModel() { PD_Process_Id = state.PD_Process_Id, PD_Subject_Id = state.PD_Subject_Id, Id = state.Id, Name = state.Name, EndState = state.EndState, SelectedMessage = "" + state.Message, StartState = state.StartState };
            var messages = _db.PD_Messages.Where(result => result.PD_Process_Id == processid && result.From == subjectid).ToList();
            var j = 0; var mtid = "";
            foreach (var message in messages)
            {
                if (message.PD_MessageType_Id != null)
                {
                    var to = _db.PD_Subjects.Find(processid, message.To);
                    Model.AvailableMessages.Add(new SelectListItem() { Value = "" + message.Id, Text = to.Name + "|" + message.PD_MessageType.Name });
                    if (Model.SelectedMessage == "0" && j == 0) { 
                        Model.SelectedMessage = message.Id.ToString(); }                    
                    j++;
                }
            }
             
            try
            {
                Model.AvailableMessages.Find(result => result.Value == Model.SelectedMessage).Selected = true;
            }
            catch (Exception e) { }

            List<SelectListItem> AvailableParameters = new List<SelectListItem>();
            List<SelectListItem> SelectedEditableParameters2 = new List<SelectListItem>();
            List<SelectListItem> SelectedReadableParameters2 = new List<SelectListItem>();
            //List<string> SelectedEditableParameters = new List<string>();
            //List<string> SelectedReadableParameters = new List<string>();            
            var parameters = _db.PD_Subjects.Find(processid, subjectid).GlobalParameters;
            try
            {
                bool exists = false;
                foreach(var am in Model.AvailableMessages){
                    if(Model.SelectedMessage == am.Value) exists = true;
                }
                if (exists) { mtid = _db.PD_Messages.Find(processid, Int32.Parse(Model.SelectedMessage)).PD_MessageType.Name; }
                else { mtid = _db.PD_Messages.Find(processid, Int32.Parse(Model.AvailableMessages[0].Value)).PD_MessageType.Name; }
                //mtid = messages[Int32.Parse(Model.SelectedMessage)-1].PD_MessageType.Name;
                var patch = _db.PD_MessageTypes.Where(result => result.Name == mtid && result.PD_Process_Id == processid);
                foreach (var a in patch){ j = a.Id;}  //there is only 1...
                var parameters2 = _db.PD_MessageTypes.Find(processid, j).Parameters;
                foreach (var i in parameters2)
                {
                    var eNewSelectItem = new SelectListItem() { Value = i, Text = i, Selected = false };
                    var rNewSelectItem = new SelectListItem() { Value = i, Text = i, Selected = false };
                    AvailableParameters.Add(new SelectListItem() { Value = i, Text = i, Selected=true });
                    foreach (var f in state.ReadableParameters.ToList()) { if (f == i) rNewSelectItem.Selected = true; }
                    foreach (var g in state.EditableParameters.ToList()) { if (g == i) eNewSelectItem.Selected = true; }
                    SelectedReadableParameters2.Add(rNewSelectItem);
                    SelectedEditableParameters2.Add(eNewSelectItem);
                }
            }catch(Exception e){}            
            
            //state.EditableParameters.ToList().ForEach(e => SelectedEditableParameters.Add(e));
            Model.AvailableEditableParameters = SelectedEditableParameters2;
            //Model.SelectedEditableParameters = SelectedEditableParameters;

            //state.ReadableParameters.ToList().ForEach(e => SelectedReadableParameters.Add(e));
            Model.AvailableReadableParameters = SelectedReadableParameters2;
            //Model.SelectedReadableParameters = SelectedReadableParameters;

            ViewBag.Edit = edit;
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditSendState(PD_SendState_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_SendState state = _db.PD_SendStates.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                state.Name = model.Name;
                state.EndState = model.EndState;
                state.StartState = model.StartState;
                state.Message = Int32.Parse(model.SelectedMessage);
                _db.SaveChanges();
                if (model.AvailableEditableParameters == null) return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
                model.SelectedEditableParameters = new List<string>();
                foreach (var i in model.AvailableEditableParameters)
                {
                    if (i.Selected == true) model.SelectedEditableParameters.Add(i.Value);
                }
                model.SelectedReadableParameters = new List<string>();
                foreach (var i in model.AvailableReadableParameters)
                {
                    if (i.Selected == true) model.SelectedReadableParameters.Add(i.Text);
                }

                state.ReadableParameters = new PersistableStringCollection();
                if (model.SelectedReadableParameters != null)
                {
                    model.SelectedReadableParameters.ForEach(item => state.ReadableParameters.Add(item));
                }
                state.EditableParameters = new PersistableStringCollection();
                if (model.SelectedEditableParameters != null)
                {
                    model.SelectedEditableParameters.ForEach(item => state.EditableParameters.Add(item));
                }

                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditReceiveState(int processid, int subjectid, int stateid, int edit)
        {
            var state = _db.PD_ReceiveStates.Find(processid, subjectid, stateid);
            PD_ReceiveState_ViewModel Model = new PD_ReceiveState_ViewModel() { PD_Process_Id = state.PD_Process_Id, PD_Subject_Id = state.PD_Subject_Id, Id = state.Id, Name = state.Name, EndState = state.EndState, StartState = state.StartState };

            ViewBag.Edit = edit;
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditReceiveState(PD_ReceiveState_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_ReceiveState state = _db.PD_ReceiveStates.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                state.Name = model.Name;
                state.EndState = model.EndState;
                state.StartState = model.StartState;

                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditTransition(int processid, int subjectid, int transitionid, int edit)
        {
            var state = _db.PD_Transitions.Find(processid, subjectid, transitionid);

            if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_TransitionTypes.RegularTransition)
                return RedirectToAction("_EditRegularTransition", new { processid = processid, subjectid = subjectid, transitionid = transitionid, edit = edit});

            else if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_TransitionTypes.ReceiveTransition)
                return RedirectToAction("_EditReceiveTransition", new { processid = processid, subjectid = subjectid, transitionid = transitionid, edit = edit });

            else if (state.Type == strict.InFlow.Designer.Db.Contracts.PD_TransitionTypes.TimeoutTransition)
                return RedirectToAction("_EditTimeoutTransition", new { processid = processid, subjectid = subjectid, transitionid = transitionid, edit = edit });

            else
                return null;
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditRegularTransition(int processid, int subjectid, int transitionid, int edit)
        {
            var transition = _db.PD_RegularTransitions.Find(processid, subjectid, transitionid);
            PD_RegularTransition_ViewModel Model = new PD_RegularTransition_ViewModel() { PD_Process_Id = transition.PD_Process_Id, PD_Subject_Id = transition.PD_Subject_Id, Id = transition.Id, Name = transition.Name };

            ViewBag.Edit = edit;
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditRegularTransition(PD_RegularTransition_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var transition = _db.PD_RegularTransitions.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                transition.Name = model.Name;

                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditTimeoutTransition(int processid, int subjectid, int transitionid, int edit)
        {
            var transition = _db.PD_TimeoutTransitions.Find(processid, subjectid, transitionid);
            PD_TimeoutTransition_ViewModel Model = new PD_TimeoutTransition_ViewModel() { PD_Process_Id = transition.PD_Process_Id, PD_Subject_Id = transition.PD_Subject_Id, Id = transition.Id, TimeSpan = transition.TimeSpan };

            ViewBag.Edit = edit;
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditTimeoutTransition(PD_TimeoutTransition_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var transition = _db.PD_TimeoutTransitions.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);
                transition.TimeSpan = model.TimeSpan;

                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditReceiveTransition(int processid, int subjectid, int transitionid, int edit)
        {
            var transition = _db.PD_ReceiveTransitions.Find(processid, subjectid, transitionid);
            PD_ReceiveTransition_ViewModel Model = new PD_ReceiveTransition_ViewModel() { PD_Process_Id = transition.PD_Process_Id, PD_Subject_Id = transition.PD_Subject_Id, Id = transition.Id };

            if (transition.Message != null)
            {
                Model.SelectedMessage = "" + transition.Message;
            }

            var messages = _db.PD_Messages.Where(result => result.PD_Process_Id == processid && result.To == subjectid);
            foreach (var message in messages)
            {
                var from = _db.PD_Subjects.Find(processid, message.From);
                Model.AvailableMessages.Add(new SelectListItem() { Value = "" + message.Id, Text = from.Name + "|" + message.PD_MessageType.Name });
            }
            try
            {
                Model.AvailableMessages.Find(result => result.Value == Model.SelectedMessage).Selected = true;
            }
            catch (Exception e) { }


            ViewBag.Edit = edit;
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditReceiveTransition(PD_ReceiveTransition_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var transition = _db.PD_ReceiveTransitions.Find(model.PD_Process_Id, model.PD_Subject_Id, model.Id);

                transition.Message = Int32.Parse(model.SelectedMessage);

                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }
        private string RefParamsToJSON(string RefParam, string Desc)
        {
            string ret = "{ ";
            ret += "\"ProcessParameter\": \"\", ";
            ret += "\"Description\": \"" + Desc + "\", ";
            ret += "\"RefinementParameter\": \"" + RefParam + "\"";
            ret += " }|";
            return ret;
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _AddRefinement(int processid, int subjectid, int edit)
        {

           // var i = _db.PD_Subjects.Find(processid, subjectid).GlobalParameters;

            var model = new PD_Refinements_ViewModel() { PD_Process_Id = processid, PD_Subject_Id = subjectid };


            PD_Refinement_ViewModel r = new PD_Refinement_ViewModel();
            r.Name = "Dynamics NAV Add Purchase Order";
            r.System = "Microsoft Dynamics NAV 2014";
            r.Description = "Add Purchase Order refinement for Microsoft Dynamics NAV 2014.";
            r.Parameters = RefParamsToJSON("Buy_From_Vendor_No", "The vendor number in Dynamics NAV.");
            r.Parameters += RefParamsToJSON("Purchaser_Code", "The Dynamics NAV purchaser code of the person who makes the purchase.");
            r.Parameters += RefParamsToJSON("Item_Number", "The Dynamics NAV item number of the item you want to purchase.");
            r.Parameters += RefParamsToJSON("Quantity", "The quantity of the item number you want to purchase.");


            model.Refinements.Add(r);

            r = new PD_Refinement_ViewModel();
            r.Name = "Dynamics NAV Add Sales Order";
            r.System = "Microsoft Dynamics NAV 2014";
            r.Description = "Add Sales Order refinement for Microsoft Dynamics NAV 2014.";
            r.Parameters = RefParamsToJSON("Sell_to_Customer_No", "The customer number in Dynamics NAV.");
            r.Parameters += RefParamsToJSON("Salesperson_Code", "The Dynamics NAV salesperson code.");
            r.Parameters += RefParamsToJSON("Requested_Delivery_Date", "The Dynamics NAV requested delivery date of the order. Format dd.mm.yyyy");


            model.Refinements.Add(r);
   


            ViewBag.Edit = edit;
            return PartialView(model);
        }

        public ActionResult AddRefinementTo (int processid, int subjectid, string parameters, string name)
        {

            PD_RefinementState state = new PD_RefinementState();

            state.PD_Process_Id = processid;
            state.Name = name;
            state.PD_Subject_Id = subjectid;
            state.PositionLeft = 100;
            state.PositionTop = 100;
            state.ReadableParameters = new PersistableStringCollection();
            List<string> refparams = parameters.Split('|').ToList<string>();
            foreach (string s in refparams)
            {
                if (s.Length > 0)
                {
                    state.ReadableParameters.Add(s);
                }
            }
            state.Type = PD_StateTypes.RefinementState;
            _db.PD_States.Add(state);
            _db.SaveChanges();
             return RedirectToAction("ViewSubject", new { processid = processid, subjectid = subjectid, edit = 1 });

        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditGlobalParameters(int processid, int subjectid, int edit)
        {

            var i = _db.PD_Subjects.Find(processid, subjectid).GlobalParameters;

            var model = new PD_GlobalParameters_ViewModel() { PD_Process_Id = processid, PD_Subject_Id = subjectid};


            model.Parameters = listofStringParametersToViewModel(processid, i);

            ViewBag.Edit = edit;
            return PartialView(model);
        }

        private List<PD_Parameter_ViewModel> listofStringParametersToViewModel(int processid ,ICollection<string> parameters)
        {
            List<PD_Parameter_ViewModel> list = new List<PD_Parameter_ViewModel>();
            foreach (string parameter in parameters)
            {
                var pc = _db.PD_Parameters.Find(processid, parameter);
                var cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(pc.Config);

                PD_Parameter_ViewModel pvm = new PD_Parameter_ViewModel() { Name = pc.Name, Type = cfg.Type, DefaultValue = cfg.Value.ToString() };

                list.Add(pvm);
            }

            return list;
        }


         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditMessageParameter(int processid, int messagetypeId, string parameter, int edit, string messageName)
        {
             PD_MessageParameter_ViewModel pvm;
             PD_Parameter pc = new PD_Parameter(){ PD_Process_Id = processid};
             if (parameter != null)
             {
                 pc = _db.PD_Parameters.Find(processid, parameter);

                 var cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(pc.Config);


                 pvm = new PD_MessageParameter_ViewModel() { Name = pc.Name, Type = cfg.Type, DefaultValue = cfg.Value.ToString(), Process_Id = processid, Message_Type_Id = messagetypeId, previousName = parameter, messageName = messageName };
             }
             else
             {
                 pvm = new PD_MessageParameter_ViewModel() { Process_Id = processid, Message_Type_Id = messagetypeId, Type = "string" , DefaultValue = "0", messageName = messageName };
             }
             ViewBag.Edit = edit;
             return PartialView(pvm);
        }

         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
         public ActionResult _EditParameter(int processid, int subjectid, string parameter, int edit)
         {
             PD_Parameter_ViewModel pvm;
             PD_Parameter pc = new PD_Parameter() { PD_Process_Id = processid };
             if (parameter != null)
             {
                 pc = _db.PD_Parameters.Find(processid, parameter);

                 var cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(pc.Config);
                 //_DeleteParameter(processid, subjectid, parameter);
                  //_EditMessageParameter(int processid, int messagetypeId, string parameter, int edit, string messageName)
                 //_db.PD_Parameters.Add(pc);


                 pvm = new PD_Parameter_ViewModel() { Name = pc.Name, Type = cfg.Type, DefaultValue = cfg.Value.ToString(), Process_Id = processid, Subject_Id = subjectid };
             }
             else
             {
                 pvm = new PD_Parameter_ViewModel() { Process_Id = processid, Subject_Id = subjectid, Type = "string" , DefaultValue = "0" };
             }
             ViewBag.Edit = edit;
             return PartialView(pvm);
         }

         public ActionResult _DeleteParameter(int processid, int subjectid, string parameter)
         {
             var _p = _db.PD_Processes.Find(processid);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 List<PD_Subject> mylist = _db.PD_Subjects.Where(x => x.PD_Process_Id == processid).ToList<PD_Subject>();
                 foreach (var i in mylist)
                 {
                     i.GlobalParameters.Remove(parameter);
                 }
                 _db.PD_Parameters.Remove(_db.PD_Parameters.Find(processid, parameter));
                 List<PD_MessageType> mylist2 = _db.PD_MessageTypes.Where(x => x.PD_Process_Id == processid).ToList<PD_MessageType>();
                 foreach (var i in mylist2)
                 {
                     i.Parameters.Remove(parameter);
                 }
                 _db.SaveChanges();
                 return RedirectToAction("_EditGlobalParameters", new { processid = processid, subjectid = subjectid, edit = 1 });
             }
             return null;
         }

         public ActionResult _DeleteMessageParameter(int processid, int messagetypeId, string parameter)
         {
             var _p = _db.PD_Processes.Find(processid);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var list = _db.PD_MessageTypes.Where(x => x.PD_Process_Id == processid).ToList<PD_MessageType>();                 
                 int count = 0;
                 foreach(var i in list){
                     if (i.Parameters.Contains(parameter)) count++;
                 }
                 if (count == 1) { var param = _db.PD_Parameters.Find(processid, parameter); _db.PD_Parameters.Remove(param); }

                 _db.PD_MessageTypes.Find(processid, messagetypeId).Parameters.Remove(parameter);

                 List<PD_Subject> mylist = _db.PD_Subjects.Where(x => x.PD_Process_Id == processid).ToList<PD_Subject>();    
                 foreach (var i in mylist){
                     i.GlobalParameters.Remove(parameter);
                 }
                _db.SaveChanges();
                return RedirectToAction("_EditMessageType", new { processid = processid, id = messagetypeId, edit = 1 });
                 
             }
             return null;
         }

        public ActionResult _GetParameterValueEditor(string type, string value)
        {
            Dictionary<string,string> model = new Dictionary<string,string>();
                model.Add("type",type);
                model.Add("value",value);

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditParameter(PD_Parameter_ViewModel model)
         {
             var _p = _db.PD_Processes.Find(model.Process_Id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 PD_Parameter p = _db.PD_Parameters.Find(model.Process_Id, model.Name);
                 if (p == null)
                 {
                     string val = model.DefaultValue;
                     if (model.Type.Equals("string"))
                     {
                         val = "\"" + val + "\"";
                     }
                     string cfg = "{\"Type\":\"" + model.Type +"\",\"Value\":" + val + "}";
                     p = new PD_Parameter() { PD_Process_Id = model.Process_Id, Name = model.Name, Config = cfg };
                     _db.PD_Parameters.Add(p);
                 }
                 else
                 {
                     try
                     {
                         model.DefaultValue = checkDefaultValue(model.Type, model.DefaultValue);
                     }
                     catch (Exception e)
                     {
                         return RedirectToAction("ViewSubject", new { processid = model.Process_Id, subjectid = model.Subject_Id, edit = 1 });
                     }
                     string val = model.DefaultValue;
                     if (model.Type.Equals("string"))
                     {
                         val = "\"" + val + "\"";
                     }
                     p.Config = "{\"Type\":\"" + model.Type + "\",\"Value\":" + val + "}";
                 }
                 var item = _db.PD_Subjects.Find(model.Process_Id, model.Subject_Id);

                 if (!item.GlobalParameters.Contains(model.Name))
                 {
                     item.GlobalParameters.Add(model.Name);
                 }
                 _db.SaveChanges();

                 return RedirectToAction("ViewSubject", new { processid = model.Process_Id, subjectid = model.Subject_Id, edit = 1 });
             }
             else
             {
                 return null;
             }
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditMessageParameter(PD_MessageParameter_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            //_p.MessageTypes[].Parameter.Results View
            {
                PD_Parameter p = _db.PD_Parameters.Find(model.Process_Id, model.Name);
                if (p == null)     
                {
                    if (model.previousName != null)
                    {
                        _DeleteMessageParameter(model.Process_Id, model.Message_Type_Id, model.previousName);
                    }
                    string val = model.DefaultValue;
                    if (model.Type.Equals("string"))
                    {
                        val = "\"" + val + "\"";
                    }
                    string cfg = "{\"Type\":\"" + model.Type + "\",\"Value\":" + val + "}";
                    p = new PD_Parameter() { PD_Process_Id = model.Process_Id, Name = model.Name, Config = cfg };
                    _db.PD_Parameters.Add(p);

                }else          
                {                         
                    try
                    {
                       model.DefaultValue = checkDefaultValue(model.Type, model.DefaultValue);
                    }catch(Exception e)
                    {
                        return RedirectToAction("ViewProcess", new { processid = model.Process_Id, edit = 1 });
                    }
                    string val = model.DefaultValue;
                    if (model.Type.Equals("string"))
                    {
                        val = "\"" + val + "\"";
                    }
                    p.Config = "{\"Type\":\"" + model.Type + "\",\"Value\":" + val + "}";
                }
                var item = _db.PD_MessageTypes.Find(model.Process_Id, model.Message_Type_Id);
                if (item == null)
                {
                    item = new PD_MessageType() { PD_Process_Id = model.Process_Id };
                    item.Name = model.messageName;                    
                    item.Id = IdHelper.getMessageTypeId(_db, model.Process_Id);
                    _db.PD_MessageTypes.Add(item);
                }
                if (!item.Parameters.Contains(model.Name))
                {
                    item.Parameters.Add(model.Name);
                }


                List<PD_Subject> mylist = _db.PD_Subjects.Where(x => x.PD_Process_Id == model.Process_Id).ToList<PD_Subject>();
                foreach (var i in mylist)
                {
                    //i.GlobalParameters.SerializedValue.Replace(parameter,"");
                    i.GlobalParameters.Remove(model.previousName);
                    if(model.Name!=null)i.GlobalParameters.Add(model.Name);
                }
                _db.SaveChanges();
                //need via AJAX or rewrite this all
                return RedirectToAction("ViewProcess", new { processid = model.Process_Id, edit = 1 });    //original, working

                //return View(model);
                //return RedirectToAction("_EditMessageType", new { processid = model.Process_Id, id = item.Id, edit = 1 });      //first way, not working, 
                
                //var model2 = new PD_MessageTypeDTO_ViewModel() { Id = model.Process_Id, PD_Process_Id = item.Id, Name = item.Name, Parameters = new List<PD_Parameter_ViewModel>() }; //second way, not working
                //model2.Parameters = listofStringParametersToViewModel(model.Process_Id, item.Parameters);
                //return View(_EditMessageType(model.Process_Id,item.Id,1));

                //var model2  = new PD_MessageParameter_ViewModel() { Name = pc.Name, Type = cfg.Type, DefaultValue = cfg.Value.ToString(), Process_Id = processid, Message_Type_Id = messagetypeId, previousName = parameter, messageName = messageName };
                //var model2 = new PD_MessageParameter_ViewModel() {};
                //return PartialView(model2);

                //return RedirectToAction("_EditMessageParameter", new { processid = model.Process_Id, messagetypeId = item.Id,  edit = 1 }); 

            }
            else
            {
                return null;
            }
        }


        public ActionResult _EditMessageParameterNoSubmit(int processid, string name, string previousName, int messageTypeId, string defaultv, string type, string messageName, bool ft)
        {
            
            if(type=="bobasic")defaultv = "{\"bo\": " + defaultv + ",  \"boi\": -1}";
            var _p = _db.PD_Processes.Find(processid);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_Parameter p = _db.PD_Parameters.Find(processid, name);
                if (p == null)//it didn't exist before
                {
                    if (previousName != null)//it had previous name, meaning the name was changed from a previous name
                    {
                        _DeleteMessageParameter(processid, messageTypeId, previousName); 
                    }
                    string val = defaultv;
                    if (type.Equals("string"))
                    {
                        val = "\"" + val + "\"";
                    }
                    string cfg = "{\"Type\":\"" + type + "\",\"Value\":" + val + "}";
                    p = new PD_Parameter() { PD_Process_Id = processid, Name = name, Config = cfg };
                    _db.PD_Parameters.Add(p);
                }
                else //it did exist already
                {
                    //List<PD_MessageType> mylist2 = _db.PD_MessageTypes.Where(x => x.PD_Process_Id == processid && x.Parameters.ToList().Contains(previousName)).ToList<PD_MessageType>();                    
                    
                    List<PD_MessageType> mylist2 = _db.PD_MessageTypes.Where(x => x.PD_Process_Id == processid && x.Id != messageTypeId).ToList<PD_MessageType>();                    
                    foreach (var i in mylist2)//check if exists in some other messageTypeId first
                    {
                        if (i.Parameters.Contains(name) && ft) return JavaScript("$('#changeRepeated').modal('show');");
                    } 

                    try
                    {
                        defaultv = checkDefaultValue(type, defaultv);
                    }
                    catch (Exception e)
                    {
                        return RedirectToAction("ViewProcess", new { processid = processid, edit = 1 });
                    }
                    string val = defaultv;
                    if (type.Equals("string"))
                    {
                        val = "\"" + val + "\"";
                    }
                    p.Config = "{\"Type\":\"" + type + "\",\"Value\":" + val + "}";
                }
                var item = _db.PD_MessageTypes.Find(processid, messageTypeId);
                if (item == null)
                {
                    item = new PD_MessageType() { PD_Process_Id = processid };
                    item.Name = messageName;
                    item.Id = IdHelper.getMessageTypeId(_db, processid);
                    _db.PD_MessageTypes.Add(item);
                }
                if (!item.Parameters.Contains(name))
                {
                    item.Parameters.Add(name);
                }

                List<PD_Subject> mylist = _db.PD_Subjects.Where(x => x.PD_Process_Id == processid).ToList<PD_Subject>();
                foreach (var i in mylist)
                {
                    i.GlobalParameters.Remove(previousName);
                    if (name != null) i.GlobalParameters.Add(name);
                }
                _db.SaveChanges();
                return RedirectToAction("_EditMessageType", new { processid = processid, id = item.Id, edit = 1 });  
            }
            else
            {
                return null;
            }
        }

        private string checkDefaultValue(string type, string value)
        {
            if (type.Equals("boolean"))
            {
                if (!(value.Equals("true") | value.Equals("false")))
                    throw new Exception("bool not valid");

                return value;
            }
            else if (type.Equals("integer"))
            {
                return Int32.Parse(value).ToString();
            }
            else if (type.Equals("number"))
            {
                value = value.Replace(',', '.');
                return Double.Parse(value).ToString();
            }

            return value;
        }

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _EditGlobalParameters(PD_GlobalParameters_ViewModel model)
        {
            var _p = _db.PD_Processes.Find(model.PD_Process_Id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var item = _db.PD_Subjects.Find(model.PD_Process_Id, model.PD_Subject_Id);

                string[] para = model.Parameters.Split(',');
                item.GlobalParameters = new PersistableStringCollection();
                para.ToList().ForEach(i => item.GlobalParameters.Add(i));


                _db.SaveChanges();

                return RedirectToAction("ViewSubject", new { processid = model.PD_Process_Id, subjectid = model.PD_Subject_Id, edit = 1 });
            }
            else
            {
                return null;
            }
        }*/


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditImportedProcesses(int processid, int edit)
        {

            var processes = _db.PD_Processes.Where(result => result.Id != processid).ToList();
            var processes2 = processes.OrderBy(result => result.Name).ToList();
            var aux = 0;
            List<PD_MessageTypeDTO_ViewModel> Model = new List<PD_MessageTypeDTO_ViewModel>();
            foreach (var i in processes2)
            {
                var p = _idb.WS_ModelVersions.Where(result => result.PD_ProcessId == i.Id);
                foreach (var j in p) { aux = j.Version; }//patch
                var type = new PD_MessageTypeDTO_ViewModel() { PD_Process_Id = i.Id, Name = i.Name, newName = aux.ToString() };
                Model.Add(type);
            }
            ViewBag.ProcessId = processid;
            ViewBag.Edit = edit;

            return PartialView(Model);
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditImportedSubjects(int processidNew, int processidOld, int edit)
        {

            var subjects = _db.PD_Subjects.Where(result => result.PD_Process_Id == processidNew).ToList();
            
            List<PD_MessageTypeDTO_ViewModel> Model = new List<PD_MessageTypeDTO_ViewModel>();
            foreach (var i in subjects)
            {
                var type = new PD_MessageTypeDTO_ViewModel() { PD_Process_Id = i.PD_Process_Id, Name = i.Name, Id = i.Id };
                Model.Add(type);
            }
            ViewBag.ProcessId = processidOld;
            ViewBag.Edit = edit;

            return PartialView(Model);
        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _EditLoadImportedSubject(int processidNew, int subjId, int processidOld, int edit)
        {

            var _p = _db.PD_Processes.Find(processidOld);
            PD_Subject subject = _db.PD_Subjects.Find(processidNew, subjId);
            Random rand = new Random();
            PD_Subject newSubject = new PD_Subject() { Name = subject.Name, PositionTop = rand.Next(0, 800), PositionLeft = rand.Next(0, 555), ExternalSubject = false, CanvasWidth = subject.CanvasWidth, CanvasHeight = subject.CanvasHeight };
            newSubject.Id = IdHelper.getSubjectId(_db, processidOld);
            _p.Subjects.Add(newSubject);
            _db.SaveChanges();
            

            //messages
            var messages = _db.PD_Messages.Where(result => result.PD_Process_Id == processidNew && result.From == subject.Id || result.PD_Process_Id == processidNew && result.To == subject.Id).ToList();
            List<int> messageIds = new List<int>();
            foreach (var x in messages) { messageIds.Add((int)x.PD_MessageType_Id); }
            messageIds = messageIds.Distinct().ToList();
            foreach (var y in messageIds)
            {
               var newMes = new PD_MessageType() { PD_Process_Id = processidOld };
               newMes.Id = IdHelper.getMessageTypeId(_db, processidOld);
               newMes.Name = _db.PD_MessageTypes.Find(processidNew, y).Name;
               newMes.Parameters = _db.PD_MessageTypes.Find(processidNew, y).Parameters;
               var Names= _db.PD_MessageTypes.Where(result => result.PD_Process_Id == processidOld && result.Name == newMes.Name);
               if (Names.Count() == 0)
               {
                   _db.PD_MessageTypes.Add(newMes);
                   foreach (var z in _db.PD_MessageTypes.Find(processidNew, y).Parameters) //parameters
                   {
                       var param = _db.PD_Parameters.Find(processidNew, z);
                       var checkParamName = _db.PD_Parameters.Find(processidOld, param.Name);
                       //var paramNames = _db.PD_Parameters.Where(result => result.PD_Process_Id == processidNew && result.Name == param.Name);
                       if (checkParamName == null)
                       {
                           PD_Parameter paramNew = new PD_Parameter() { PD_Process_Id = processidOld };
                           paramNew.Name = param.Name;
                           paramNew.Config = param.Config;
                           _db.PD_Parameters.Add(paramNew);
                       }
                   }
               }
               _db.SaveChanges();
            }
            

            //state && transitions            
            var states = _db.PD_States.Where(result => result.PD_Process_Id == processidNew && result.PD_Subject_Id == subject.Id).ToList();
            var i = 1;
            foreach (var x in states)
            {
                PD_State newState = null;
                
                if (x.Type == PD_StateTypes.FunctionState) 
                {
                    newState = new PD_FunctionState() { Name = "Function State", EndState = false };
                }
                if (x.Type == PD_StateTypes.SendState)
                {
                    newState = new PD_SendState() { Name = "Send State", EndState = false };
                    //((PD_SendState)newState).ReadableParameters = ((PD_SendState)x).ReadableParameters;
                    //((PD_SendState)newState).EditableParameters = ((PD_SendState)x).EditableParameters;
                }
                if (x.Type == PD_StateTypes.ReceiveState)
                {
                    newState = new PD_ReceiveState() { Name = "Receive State", EndState = false };
                } 
                //newState.PD_Subject = x.PD_Subject;
                //newState.PD_Subject_Id = newSubject.Id;
                //newState.Id = IdHelper.getStateId(_db, processidOld, subjId);
                //newState.Id = IdHelper.getStateId(_db, _p.Id, newSubject.Id);
                //newState.PD_Process_Id = processidOld;
                //newState.Id = i;
                newState.Id = x.Id;
                i++;
                
                newState.Name = x.Name;
                newState.PositionLeft = x.PositionLeft;
                newState.PositionTop = x.PositionTop;
                newState.StartState = x.StartState;
                newState.EndState = x.EndState;
                newSubject.States.Add(newState);            
            }
            _db.SaveChanges();

            i = 1;
            var transitions = _db.PD_Transitions.Where(result => result.PD_Process_Id == processidNew && result.PD_Subject_Id == subject.Id).ToList();
            foreach (var x in transitions)
            {
                 PD_Transition newTransition = null;

                 var temp = new PD_TransitionDTO() { Id = x.Id, Source = x.Source, Target = x.Target, Type = x.Type, LabelPosition = x.LabelPosition };
                 
                 if (x.Type == PD_TransitionTypes.RegularTransition)
                 {
                     temp.Label = ((PD_RegularTransition)x).Name;
                     newTransition = new PD_RegularTransition() { Name = temp.Label };                     
                 }
                 if (x.Type == PD_TransitionTypes.ReceiveTransition)
                 {
                      newTransition = new PD_ReceiveTransition() { Message = -1 };
                 }
                 if (x.Type == PD_TransitionTypes.TimeoutTransition)
                 {
                     temp.Label = ((PD_TimeoutTransition)x).TimeSpan;
                     newTransition = new PD_TimeoutTransition() { TimeSpan = temp.Label };
                 }

                 //newTransition.Id = IdHelper.getTransitionId(_db, processidOld, subjId);
                 //newTransition.Id = i;
                 newTransition.Id = x.Id;
                 i++;
                 newTransition.PD_Process_Id = processidOld;
                 newTransition.Source = x.Source;
                 newTransition.Target = x.Target;
                 newTransition.LabelPosition = x.LabelPosition;
                 newSubject.Transitions.Add(newTransition);
            }
            _db.SaveChanges();
            
            string a = "location.reload();";
            string b = "imprt('" + subject.Name + "','" + newSubject.Id + "','" + newSubject.PositionLeft + "','" + newSubject.PositionTop + "','" + processidOld + "')";
            return JavaScript(b);
            //return null;
        }


    }
}