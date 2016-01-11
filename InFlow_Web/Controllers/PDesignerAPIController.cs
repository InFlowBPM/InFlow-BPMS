using strict.InFlow.Designer.Db;
using strict.InFlow.Designer.Db.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor")]
    public class PDesignerAPIController : ApiController
    {

        // Process
        PDesignerDb _db = new PDesignerDb();

        [Route("PDesignerAPI")]
        public IEnumerable<PD_ProcessDTO> GetAllProcesses()
        {
            List<PD_ProcessDTO> processes = new List<PD_ProcessDTO>();
            foreach (var _p in _db.PD_Processes)
            {
                processes.Add(new PD_ProcessDTO() { Id = _p.Id, Name = _p.Name, Locked = _p.Locked, LockedBy = _p.LockedBy });
            }
            return processes.ToArray();
        }

        [Route("PDesignerAPI/{id}")]
        public IHttpActionResult Get(int id)
        {
            var _p = _db.PD_Processes.Find(id);
            return Ok(new PD_ProcessDTO() { Id = _p.Id, Name = _p.Name, Locked = _p.Locked, LockedBy = _p.LockedBy });
        }

        // Subject
        [Route("PDesignerAPI/{id}/Subjects")]
        public IEnumerable<PD_SubjectDTO> GetAllSubjects(int id)
        {
            var _p = _db.PD_Processes.Find(id);
            List<PD_SubjectDTO> subjects = new List<PD_SubjectDTO>();
            foreach (var i in _p.Subjects)
            {
                subjects.Add(new PD_SubjectDTO() { Id = i.Id, Name = i.Name, CanBeStarted = i.CanBeStarted, MultiSubject = i.MultiSubject, ExternalSubject = i.ExternalSubject, PositionLeft = i.PositionLeft, PositionTop = i.PositionTop });
            }
            return subjects.ToArray();
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}")]
        public IHttpActionResult GetSubject(int id, int sid)
        {

            PD_Subject i = _db.PD_Subjects.Find(id, sid);
            return Ok(new PD_SubjectDTO() { Id = i.Id, Name = i.Name, CanBeStarted = i.CanBeStarted, MultiSubject = i.MultiSubject, ExternalSubject = i.ExternalSubject });
        }


        [Route("PDesignerAPI/{id}/Subjects")]
        public HttpResponseMessage PostSubject(PD_SubjectDTO item, int id)
        {

            var _p = _db.PD_Processes.Find(id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_Subject newSubject = new PD_Subject() { Name = "newSubject", PositionTop = item.PositionTop, PositionLeft = item.PositionLeft };
                newSubject.Id = IdHelper.getSubjectId(_db, id);
                _p.Subjects.Add(newSubject);
                _db.SaveChanges();

                var response = Request.CreateResponse<PD_SubjectDTO>(HttpStatusCode.Created, new PD_SubjectDTO { Id = newSubject.Id, Name = newSubject.Name, PositionLeft = newSubject.PositionLeft, PositionTop = newSubject.PositionTop, CanBeStarted = newSubject.CanBeStarted, ExternalSubject = newSubject.CanBeStarted, MultiSubject = newSubject.MultiSubject });

                string uri = Url.Content("Designer" + id + "/Subjects/" + newSubject.Id);
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return null;
            }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}")]
        public void PutSubject(PD_SubjectDTO item, int id, int sid)
        {
            var _p = _db.PD_Processes.Find(id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                PD_Subject i = _db.PD_Subjects.Find(id, sid);

                if (i != null)
                {
                    if (item.Name != null)
                    {
                        i.Name = item.Name;
                    }
                    i.PositionTop = item.PositionTop;
                    i.PositionLeft = item.PositionLeft;
                    _db.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}")]
        public void DeleteSubject(int id, int sid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 //var _p = _db.PD_Processes.Find(id);
                 PD_Subject i = _db.PD_Subjects.Find(id, sid);

                 if (i != null)
                 {

                     var toDelete = _db.PD_Messages.Where(result => result.From == i.Id && result.PD_Process_Id == id || result.To == i.Id && result.PD_Process_Id == id);
                     _db.PD_Messages.RemoveRange(toDelete);

                     var toDelete2 = _db.PD_Transitions.Where(result => result.PD_Process_Id == id && result.PD_Subject_Id == sid);
                     _db.PD_Transitions.RemoveRange(toDelete2);

                     var toDelete3 = _db.PD_States.Where(result => result.PD_Process_Id == id && result.PD_Subject_Id == sid);
                     _db.PD_States.RemoveRange(toDelete3);

                     _db.PD_Subjects.Remove(i);                     
                  
                     /*var subjUpdate = _db.PD_Subjects.Where(result => result.PD_Process_Id == id && result.Id > sid);
                     foreach (PD_Subject j in subjUpdate)
                     {
                         j.Id = j.Id - 1;                                
                     }*/
                     _db.SaveChanges();
                 }
                 else
                 {
                     throw new HttpResponseException(HttpStatusCode.NotFound);
                 }
             }
        }

        //Subject - Global Parameter
        [Route("PDesignerAPI/{id}/Subjects/{sid}/GlobalParameters")]
        public IEnumerable<string> GetAllGlobalParameters(int id, int sid)
        {

            var i = _db.PD_Subjects.Find(id, sid);
            return i.GlobalParameters.ToArray();
        }

        //Subject - State
        [Route("PDesignerAPI/{id}/Subjects/{sid}/States")]
        public IEnumerable<PD_StateDTO> GetAllStates(int id, int sid)
        {
            List<PD_StateDTO> tmp = new List<PD_StateDTO>();
            PD_Subject i = _db.PD_Subjects.Find(id, sid);
            foreach (PD_State s in i.States)
            {
                PD_StateDTO dto = new PD_StateDTO { Id = s.Id, Name = s.Name, EndState = s.EndState, StartState = s.StartState, Type = s.Type, PositionLeft = s.PositionLeft, PositionTop = s.PositionTop };
                if (s.Type == PD_StateTypes.FunctionState)
                {
                    dto.ReadableParameters = ((PD_FunctionState)s).ReadableParameters;
                    dto.EditableParameters = ((PD_FunctionState)s).EditableParameters;
                }
                if (s.Type == PD_StateTypes.SendState)
                {
                    dto.ReadableParameters = ((PD_SendState)s).ReadableParameters;
                    dto.EditableParameters = ((PD_SendState)s).EditableParameters;
                    dto.Message = ((PD_SendState)s).Message;
                }
                tmp.Add(dto);
            }
            return tmp;
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/States/{stid}")]
        public IHttpActionResult GetState(int id, int sid, int stid)
        {
            return Ok(_db.PD_States.Find(id, sid, stid));
        
        }
        [Route("PDesignerAPI/{id}/Subjects/{sid}/Canvas")]
        public IHttpActionResult getCanvas(int id, int sid)
        {
            PD_Canvas c = new PD_Canvas();
            PD_Subject s = _db.PD_Subjects.Find(id, sid);
            c.CanvasWidth = s.CanvasWidth;
            c.CanvasHeight = s.CanvasHeight;
            return Ok(c);
        }

        [Route("PDesignerAPI/{id}/Canvas")]
        public IHttpActionResult getCanvas(int id)
        {
            PD_Canvas c = new PD_Canvas();
            PD_Process s = _db.PD_Processes.Find(id);
            c.CanvasWidth = s.CanvasWidth;
            c.CanvasHeight = s.CanvasHeight;
            return Ok(c);
        }
        [Route("PDesignerAPI/{id}/Subjects/{sid}/Canvas")]
        public void PutCanvas(PD_Canvas item, int id, int sid)
        {
            var _p = _db.PD_Processes.Find(id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {
                var subject = _db.PD_Subjects.Find(id, sid);

                if (subject != null)
                {
                    if(subject.CanvasHeight != item.CanvasHeight && subject.CanvasWidth != item.CanvasWidth)
                    subject.CanvasWidth = item.CanvasWidth;
                    subject.CanvasHeight = item.CanvasHeight;
                    
                    _db.SaveChanges();
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        [Route("PDesignerAPI/{id}/Canvas")]
        public void PutCanvas(PD_Canvas item, int id)
        {
            var _p = _db.PD_Processes.Find(id);
            if (User.Identity.Name.Equals(_p.LockedBy))
            {

                _p.CanvasHeight = item.CanvasHeight;
                _p.CanvasWidth = item.CanvasWidth;
                    _db.SaveChanges();
               
            }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/States")]
        public HttpResponseMessage PostState(PD_State item, int id, int sid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var subject = _db.PD_Subjects.Find(id, sid);
                 PD_State newState = null;
                 if (item.Type == PD_StateTypes.FunctionState)
                 {
                     newState = new PD_FunctionState() { Name = "Function State", EndState = false };
                 }
                 if (item.Type == PD_StateTypes.SendState)
                 {
                     newState = new PD_SendState() { Name = "Send State", EndState = false };
                 }
                 if (item.Type == PD_StateTypes.ReceiveState)
                 {
                     newState = new PD_ReceiveState() { Name = "Receive State", EndState = false };
                 }
                 if (item.Type == PD_StateTypes.RefinementState)
                 {
                     newState = new PD_RefinementState() { Name = "Refinement State", EndState = false };
                 }
                 newState.Id = IdHelper.getStateId(_db, id,sid);

                 newState.PositionLeft = item.PositionLeft;
                 newState.PositionTop = item.PositionTop;

                 newState.StartState = false;
                 if (subject.States.Count == 0)
                 {
                     newState.StartState = true;
                 }

                 subject.States.Add(newState);
                 _db.SaveChanges();
                 var response = Request.CreateResponse<PD_StateDTO>(HttpStatusCode.Created, new PD_StateDTO { Id = newState.Id, Name = newState.Name, PositionLeft = newState.PositionLeft, PositionTop = newState.PositionTop, Type = newState.Type });

                 string uri = Url.Content("Designer" + id + "/Subjects/" + sid + "/States/" + newState.Id);
                 response.Headers.Location = new Uri(uri);
                 return response;
             }
             else
             {
                 return null;
             }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/States/{stid}")]
        public void PutState(PD_State item, int id, int sid, int stid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var state = _db.PD_States.Find(id, sid, stid);

                 if (state != null)
                 {
                     if (item.Name != null)
                     {
                         state.Name = item.Name;
                     }
                     state.PositionTop = item.PositionTop;
                     state.PositionLeft = item.PositionLeft;
                     _db.SaveChanges();
                 }
                 else
                 {
                     throw new HttpResponseException(HttpStatusCode.NotFound);
                 }
             }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/States/{stid}")]
        public void DeleteState(int id, int sid, int stid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 PD_Subject i = _db.PD_Subjects.Find(id, sid);
                 var state = _db.PD_States.Find(id, sid, stid);

                 if (state != null)
                 {
                     var todelete = _db.PD_Transitions.Where(result => result.Source == state.Id && result.PD_Process_Id == id && result.PD_Subject_Id == sid || result.Target == state.Id && result.PD_Process_Id == id && result.PD_Subject_Id == sid);
                     _db.PD_Transitions.RemoveRange(todelete);
                     i.States.Remove(state);
                     _db.SaveChanges();
                 }
                 else
                 {
                     throw new HttpResponseException(HttpStatusCode.NotFound);
                 }
             }
        }


        // Subject - Transition
        [Route("PDesignerAPI/{id}/Subjects/{sid}/Transitions")]
        public IEnumerable<PD_TransitionDTO> GetAllTransitions(int id, int sid)
        {

            PD_Subject i = _db.PD_Subjects.Find(id, sid);
            List<PD_TransitionDTO> t = new List<PD_TransitionDTO>();

            foreach (var tr in i.Transitions)
            {
                var temp = new PD_TransitionDTO() { Id = tr.Id, Source = tr.Source, Target = tr.Target, Type = tr.Type, LabelPosition = tr.LabelPosition };

                if (tr.Type == PD_TransitionTypes.RegularTransition)
                {
                    temp.Label = ((PD_RegularTransition)tr).Name;
                }
                if (tr.Type == PD_TransitionTypes.ReceiveTransition)
                {
                    try
                    {
                        PD_Message m = _db.PD_Messages.Find(id, ((PD_ReceiveTransition)tr).Message);
                        PD_MessageType mt = m.PD_MessageType;
                        PD_Subject s = _db.PD_Subjects.Find(id, m.From);
                        temp.Label = s.Name + "|" + mt.Name;
                    }
                    catch (Exception e)
                    {
                        temp.Label = "Receive";
                    }
                }
                if (tr.Type == PD_TransitionTypes.TimeoutTransition)
                {
                    temp.Label = ((PD_TimeoutTransition)tr).TimeSpan;
                }
                if (temp.Label == null)
                    temp.Label = "EMPTY";
                t.Add(temp);
            }
            return t.ToArray();
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/Transitions/{tid}")]
        public IHttpActionResult GetTransition(int id, int sid, int tid)
        {
            return Ok(_db.PD_Transitions.Find(id, sid, tid));
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/Transitions")]
        public HttpResponseMessage PostTransition(PD_TransitionDTO item, int id, int sid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var subject = _db.PD_Subjects.Find(id, sid);
                 PD_Transition newTransition = null;
                 if (item.Type == PD_TransitionTypes.RegularTransition)
                 {
                     var from = _db.PD_States.Find(id, sid, item.Source);
                     var to = _db.PD_States.Find(id, sid, item.Target);
                     if (from.Type == PD_StateTypes.SendState && to.Type == PD_StateTypes.ReceiveState)
                     {                        
                        var state = _db.PD_SendStates.Find(id, sid, item.Source);
                        var messages = _db.PD_Messages.Where(result => result.PD_Process_Id == id && result.From == sid).ToList();
                        foreach (var message in messages)
                        {
                            if (state.Message == message.Id)
                            {
                                newTransition = new PD_RegularTransition() { Name = message.PD_MessageType.Name.ToString() };
                            }
                        }
                        if (newTransition == null) { newTransition = new PD_RegularTransition() { Name = "No message used" }; }
                     }
                     else
                     {

                         PD_State s = _db.PD_States.Find(id, sid, item.Source);
                         if (s.Type == PD_StateTypes.SendState) { 
                             var state = _db.PD_SendStates.Find(id, sid, item.Source);

                             var messages = _db.PD_Messages.Where(result => result.PD_Process_Id == id && result.From == sid).ToList();
                             if (messages.Count() > 0){
                                 var name = messages.Find(result => result.Id == state.Message).PD_MessageType.Name;
                                 newTransition = new PD_RegularTransition() { Name = name };
                             }
                             else
                             {
                                 newTransition = new PD_RegularTransition() { Name = "Transition" };
                             }
                         }
                         else{
                             newTransition = new PD_RegularTransition() { Name = "Transition" };
                         }
                     }
                 }
                 if (item.Type == PD_TransitionTypes.ReceiveTransition)
                 {
                     newTransition = new PD_ReceiveTransition() { Message = -1 };
                 }
                 if (item.Type == PD_TransitionTypes.TimeoutTransition)
                 {
                     newTransition = new PD_TimeoutTransition() { TimeSpan = "dd:hh:mm" };
                 }

                 newTransition.Id = IdHelper.getTransitionId(_db, id, sid);

                 newTransition.Source = item.Source;
                 newTransition.Target = item.Target;
                 newTransition.LabelPosition = item.LabelPosition;
                 subject.Transitions.Add(newTransition);
                 _db.SaveChanges();
                 var response = Request.CreateResponse<PD_TransitionDTO>(HttpStatusCode.Created, new PD_TransitionDTO() { Id = newTransition.Id, Source = newTransition.Source, Target = newTransition.Target, Type = newTransition.Type, Label = "Transition" + newTransition.Type });

                 string uri = Url.Content("Designer" + id + "/Subjects/" + sid + "/States/" + newTransition.Id);
                 response.Headers.Location = new Uri(uri);
                 return response;
             }
             else
             {
                 return null;
             }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/Transitions/{tid}")]
        public void PutTransition(PD_TransitionDTO item, int id, int sid, int tid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var transition = _db.PD_Transitions.Find(id, sid, tid);

                 if (transition != null)
                 {
                     transition.Source = item.Source;
                     transition.Target = item.Target;
                     transition.LabelPosition = item.LabelPosition;
                     _db.SaveChanges();
                 }
                 else
                 {
                     throw new HttpResponseException(HttpStatusCode.NotFound);
                 }
             }
        }

        [Route("PDesignerAPI/{id}/Subjects/{sid}/Transitions/{tid}")]
        public void DeleteTransition(int id, int sid, int tid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 var transition = _db.PD_Transitions.Find(id, sid, tid);

                 if (transition != null)
                 {
                     _db.PD_Transitions.Remove(transition);
                     _db.SaveChanges();
                 }
             }
        }

        // Message
        [Route("PDesignerAPI/{id}/Messages")]
        public IEnumerable<PD_MessageDTO> GetAllMessages(int id)
        {
            var _p = _db.PD_Processes.Find(id);
            List<PD_MessageDTO> tmp = new List<PD_MessageDTO>();
            foreach (PD_Message m in _p.Messages)
            {
                PD_MessageDTO dto = new PD_MessageDTO { Id = m.Id, From = m.From, To = m.To };
                if (m.EndPoints != null)
                {
                    dto.EndPoints = new double[4];
                    dto.EndPoints[0] = Convert.ToDouble(m.EndPoints.Split('|')[0]);
                    dto.EndPoints[1] = Convert.ToDouble(m.EndPoints.Split('|')[1]);
                    dto.EndPoints[2] = Convert.ToDouble(m.EndPoints.Split('|')[2]);
                    dto.EndPoints[3] = Convert.ToDouble(m.EndPoints.Split('|')[3]);
                }
                if (m.PD_MessageType != null)
                {
                    dto.TypeName = m.PD_MessageType.Name;
                }
                else
                {
                    dto.TypeName = "newMessage";
                }
                tmp.Add(dto);
            }
            return tmp.ToArray();
        }

        [Route("PDesignerAPI/{id}/Messages/{mid}")]
        public IHttpActionResult GetMessage(int id, int mid)
        {
            return Ok(_db.PD_Messages.Find(id, mid));
        }

        [Route("PDesignerAPI/{id}/Messages")]
        public HttpResponseMessage PostMessage(PD_MessageDTO item, int id)
        {
             //if (item.EndPoints[0] == 0.0 && item.EndPoints[1] == 0.0) return null; //older versions
             //else if (item.EndPoints.Length == 2) return null;
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 foreach (var i in _p.Messages) //this foreach shouldnt be necessary, by doing a simple update via javascript, but doesn't seem to be working
                 {
                     if (i.EndPoints != null)//for older versions
                     {
                         var source1 = Convert.ToDouble(i.EndPoints.Split('|')[0]);
                         var source2 = Convert.ToDouble(i.EndPoints.Split('|')[1]);
                         if (source1 == item.EndPoints[0] && source2 == item.EndPoints[1])
                         {
                             i.EndPoints = (item.EndPoints[0]).ToString() + "|" + (item.EndPoints[1]).ToString() + "|" + (item.EndPoints[2]).ToString() + "|" + (item.EndPoints[3]).ToString();
                             i.To = item.To;
                             _db.SaveChanges();
                             return null;
                         }
                     }
                 }
                 
                 
                 PD_Message m = new PD_Message() { From = item.From, To = item.To };
                 m.Id = IdHelper.getMessageId(_db, id);
                 if (item.EndPoints.Length == 2){//si me da igual, algo hay q guardar simplemente
                     m.EndPoints = (item.EndPoints[0]).ToString() + "|" + (item.EndPoints[1]).ToString() + "|0|0";                                             
                 }else{
                     m.EndPoints = (item.EndPoints[0]).ToString() + "|" + (item.EndPoints[1]).ToString() + "|" + (item.EndPoints[2]).ToString() + "|" + (item.EndPoints[3]).ToString();                                             
                 }                 
                 //m.EndPoints = item.EndPoints;
                 _p.Messages.Add(m);                 
                 _db.SaveChanges();
                 var response = Request.CreateResponse<PD_MessageDTO>(HttpStatusCode.Created, new PD_MessageDTO() { Id = m.Id, From = m.From, To = m.To, TypeName = "newMessage", EndPoints = item.EndPoints });
                 
                 string uri = Url.Content("Designer" + id + "/Messages/" + m.Id);
                 response.Headers.Location = new Uri(uri);
                 return response;
             }
             else
             {
                 return null;
             }
        }

        [Route("PDesignerAPI/{id}/Messages/{mid}")]
        public void PutMessage(PD_MessageDTO item, int id, int mid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 PD_Message m = _db.PD_Messages.Find(id, mid);

                 if (m != null)
                 {
                     m.From = item.From;
                     m.To = item.To;
                     _db.SaveChanges();
                 }
                 else
                 {
                     throw new HttpResponseException(HttpStatusCode.NotFound);
                 }
             }
        }

        [Route("PDesignerAPI/{id}/Messages/{mid}")]
        public void DeleteTransition(int id, int mid)
        {
             var _p = _db.PD_Processes.Find(id);
             if (User.Identity.Name.Equals(_p.LockedBy))
             {
                 PD_Message m = _db.PD_Messages.Find(id, mid);

                 if (m != null)
                 {
                     _p.Messages.Remove(m);                     
                     //_db.PD_States.Where(result => result.PD_Process_Id == id && result.Message == mid).ToList(); must be deleted too or exceptions will appear
                     if (m.PD_MessageType_Id != null)
                     {
                         var mesName = _db.PD_MessageTypes.Find(id, m.PD_MessageType_Id);
                         
                         var subj = _db.PD_Subjects.Find(id, m.From);
                         var subj2 = _db.PD_Subjects.Find(id, m.To);
                         
                         var outgoing = _db.PD_Messages.Where(a => a.From == subj.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         var incoming = _db.PD_Messages.Where(a => a.To == subj.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         if (outgoing == 1 && incoming == 0) //for the strange case the user makes 2 or more messages with the very same type from the very same subject
                         {
                             foreach (string x in mesName.Parameters.ToList())
                             {
                                 subj.GlobalParameters.Remove(x);        //with this, the function states will not load the parameters from the deleted message
                             }
                         }
                         outgoing = _db.PD_Messages.Where(a => a.From == subj2.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         incoming = _db.PD_Messages.Where(a => a.To == subj2.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         if (outgoing == 0 && incoming == 1) //for the strange case the user makes 2 or more messages with the very same type from the very same subject
                         {
                             foreach (string x in mesName.Parameters.ToList())
                             {
                                 subj2.GlobalParameters.Remove(x);        //with this, the function states will not load the parameters from the deleted message
                             }
                         }/*
                         var outgoing = _db.PD_Messages.Where(a => a.From == subj.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         var incoming = _db.PD_Messages.Where(a => a.To == subj.Id && a.PD_Process_Id == id && a.PD_MessageType_Id == mesName.Id).Count();
                         if (outgoing == 1 && incoming == 0 || outgoing == 0 && incoming == 1) //for the strange case the user makes 2 or more messages with the very same type from the very same subject
                         {
                             foreach (string x in mesName.Parameters.ToList())
                             {
                                 subj.GlobalParameters.Remove(x);        //with this, the function states will not load the parameters from the deleted message
                             }
                         }*/
                     }
                     _db.SaveChanges();
                 }
             }
        }

        // Message - Message Type
        [Route("PDesignerAPI/{id}/MessageTypes")]
        public IEnumerable<PD_MessageTypeDTO> GetAllMessageTypes(int id)
        {
            List<PD_MessageTypeDTO> tmp = new List<PD_MessageTypeDTO>();
            _db.PD_Processes.Find(id).MessageTypes.ToList().ForEach(m => tmp.Add(new PD_MessageTypeDTO() { Id = m.Id, Name = m.Name, Parameters = m.Parameters, PD_Process_Id = m.PD_Process_Id }));

            return tmp.ToArray();
        }

        [Route("PDesignerAPI/{id}/MessageTypes/{mtid}")]
        public IHttpActionResult GetMessageType(int id, int mtid)
        {

            return Ok(_db.PD_MessageTypes.Find(id, mtid));
        }

    }
}
