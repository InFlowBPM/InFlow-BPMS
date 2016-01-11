using Newtonsoft.Json.Linq;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Web.Models.JobsViewModels;
using strICT.InFlow.WFM.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Helpers
{
    public class JobsHelper : IJobsHelper
    {
        string connectionString;
        string wfmBaseAddress;
        string wfmUsername;
        string wfmPassword;

        ITaskStore taskStore;
        IProcessStore processStore;
        IUserStore userStore;
        IMessageStore messageStore;

        CoreFunctions core;

        InFlowDb _db;

        private void initService()
        {
            if (connectionString == null)
            {
                connectionString = ConfigurationSettings.AppSettings["repositoryConnectionString"].ToString();

                wfmBaseAddress = ConfigurationSettings.AppSettings["wfmBaseAddress"].ToString();
                wfmUsername = ConfigurationSettings.AppSettings["wfmUsername"].ToString();

                wfmPassword = ConfigurationSettings.AppSettings["wfmPassword"].ToString();

                taskStore = StoreHandler.getTaskStore(connectionString);
                processStore = StoreHandler.getProcessStore(connectionString);
                userStore = StoreHandler.getUserStore(connectionString);
                messageStore = StoreHandler.getMessageStore(connectionString);

                _db = new InFlowDb();
            }
        }

        private void initCore()
        {
            core = new CoreFunctions(wfmBaseAddress, wfmUsername, wfmPassword, connectionString);
        }

        public List<Models.JobsViewModels.TaskListItemViewModel> getOpenTaskListForUser(string username)
        {
            initService();

            List<TaskListItemViewModel> list = new List<TaskListItemViewModel>();
            var tasks = taskStore.getTasksNotSeenByUsername(username);

            if (tasks != null)
            {
                foreach (T_Task t in tasks)
                {
                    if (t.Type.Equals("R"))
                    {
                        if (messageStore.getMessagesForReceiveStateTask(t.WFId, t.getTaskPropertiesAsListOfString()).Count > 0)
                        {
                            list.Add(new TaskListItemViewModel { Id = t.Id, Name = t.Name, Done = t.Done, Type = t.Type, ProcessId = taskStore.getProcessIdForTask(t.Id), OrderId = t.InternalOrderId, DateTime = t.DateCreated.ToString() });
                        }
                    }
                    else
                    {
                        list.Add(new TaskListItemViewModel { Id = t.Id, Name = t.Name, Done = t.Done, Type = t.Type, ProcessId = taskStore.getProcessIdForTask(t.Id), OrderId = t.InternalOrderId, DateTime = t.DateCreated.ToString() });
                    }
                }
            }

            return list;
        }

        public T_Task getTask(int id)
        {
            initService();
            return taskStore.getTaskById(id);
        }
        public Models.JobsViewModels.FunctionTaskViewModel getFunctionTask(int id, string username)
        {
            initService();

            if (CanUserAccessTask(id, username))
            {
                T_Task task = taskStore.getTaskById(id);
                if (task.Type.Equals("F"))
                {

                    var processInstance = _db.P_ProcessInstance.Find(task.P_ProcessInstance_Id);
                    var process = _db.P_Processes.Find(processInstance.P_Process_Id);
                    bool tout = false;
                    if (task.SubmittedTaskProperties != null)
                    {
                        if (task.SubmittedTaskProperties.Equals("TimeOut!"))
                        {
                            tout = true;
                        }
                    }

                    DateTime doneDate = new DateTime();
                    if(task.DateSubmitted != null)
                    {
                        doneDate = task.DateSubmitted.Value;
                    }


                    FunctionTaskViewModel model = new FunctionTaskViewModel() { Id = task.Id, Name = task.Name, Done = task.Done, DoneDate = doneDate, ProcessStartDate = processInstance.DateStarted.Value, StartedByUser = processInstance.StartedByUser, TaskCreatedDate = task.DateCreated.Value, Timedout = tout, Version = process.WS_Project_Version, ProcessName=process.WS_Project.Name, Seen = task.Seen};

                    model.selectedTransiton = "";
                    string editableParametersString = "";
                    if (task.Done)
                    {
                        if (!tout)
                        {
                            model.selectedTransiton = task.SubmittedTaskProperties;

                            editableParametersString = task.SubmittedEditableParameters;
                        }
                    }
                    else
                    {
                        task.TaskProperties.ForEach(tp => model.Transitions.Add(new SelectListItem { Selected = false, Value = tp.Value, Text = tp.Value }));
                        editableParametersString = task.EditableParameters;
                    }
                    /*
                    var readableParameters = Json.Decode<Dictionary<string, JObject>>(task.ReadableParameters);
                    if (readableParameters != null)
                        foreach (var i in readableParameters)
                        {
                            model.ReadableParameters.Add(new TaskParameter(i.Key,i.Value));// { Name = i.Key, Value = i.Value });
                        }

                    var editableParameters = Json.Decode<Dictionary<string, JObject>>(task.EditableParameters);
                    if (editableParameters != null)
                        foreach (var i in Json.Decode<Dictionary<string, JObject>>(task.EditableParameters))
                        {
                            model.EditableParameters.Add(new TaskParameter(i.Key, i.Value));//{ Name = i.Key, Value = i.Value });
                        }*/
                    //var readableParameters = Json.Decode<IDictionary<string, dynamic>>(task.ReadableParameters);
                    IDictionary<string, dynamic> readableParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(task.ReadableParameters);
                    if (readableParameters != null)
                        foreach (var i in readableParameters)
                        {
                            model.ReadableParameters.Add(new TaskParameter(i.Key, i.Value));// { Name = i.Key, Value = i.Value });
                        }

                    if (editableParametersString == null)
                        editableParametersString = "";
                    // var editableParameters = Json.Decode<Dictionary<string, JObject>>(task.EditableParameters);
                    IDictionary<string, dynamic> editableParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(editableParametersString);

                    if (editableParameters != null)
                        foreach (var i in editableParameters)
                        {
                            model.EditableParameters.Add(new TaskParameter(i.Key, i.Value));// { Name = i.Key, Value = i.Value });
                        }

                    return model;
                }
            }
            return null;
        }

        public bool setFunctionTask(FunctionTaskViewModel ftviewmodel, string username)
        {
            initService();
            initCore();
            if (CanUserAccessTask(ftviewmodel.Id, username))
            {
                

                Dictionary<string, dynamic> editableparameters = new Dictionary<string, dynamic>();
                ftviewmodel.EditableParameters.ForEach(tp => editableparameters.Add(tp.Name, tp.Value));

                core.submitFunctionTaskAnswer(ftviewmodel.Id, ftviewmodel.selectedTransiton, encodeEditableParameters(ftviewmodel.Id,editableparameters), username);

                return true;
            }

            return false;
        }


        private string encodeEditableParameters(int taskId, Dictionary<string,dynamic> parameters)
        {
            string origEditPara = _db.T_Tasks.Find(taskId).EditableParameters;

            IDictionary<string, dynamic> ob = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(origEditPara);

            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            foreach (KeyValuePair<string, dynamic> i in parameters)
            {
                if (ob[i.Key].Type.Value.Equals("boolean"))
                {
                    ob[i.Key].Value = Boolean.Parse(i.Value[0]);
                }
                else if (ob[i.Key].Type.Value.Equals("integer"))
                {
    
                    string datastring = i.Value[0];
                    datastring = datastring.Replace(',', '.');

                    double v = double.Parse(datastring, NumberStyles.Any, ci);
                    ob[i.Key].Value = (int)v;
                }
                else if (ob[i.Key].Type.Value.Equals("number"))
                {
                    string datastring = i.Value[0];
                    datastring = datastring.Replace(',', '.');
                    ob[i.Key].Value = double.Parse(datastring, NumberStyles.Any, ci);
                }
                else if (ob[i.Key].Type.Value.Equals("string"))
                {
                    ob[i.Key].Value = (string)i.Value[0];
                }
                else if (ob[i.Key].Type.Value.Equals("bobasic"))
                {
                    
                }
                else
                {
                    ob[i.Key].Value = (string)i.Value;
                }
                //ob[i.Key].Value = i.Value;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ob);
        }



        public Models.JobsViewModels.SendTaskViewModel getSendTask(int id, string username)
        {
            initService();

            if (CanUserAccessTask(id, username))
            {
                T_Task task = taskStore.getTaskById(id);

                if (task.Type.Equals("S"))
                {

                    var processInstance = _db.P_ProcessInstance.Find(task.P_ProcessInstance_Id);
                    var process = _db.P_Processes.Find(processInstance.P_Process_Id);
                    bool tout = false;
                    if(task.SubmittedTaskProperties != null)
                    {
                        if (task.SubmittedTaskProperties.Equals("TimeOut!"))
                        {
                            tout = true;
                        }
                    }

                    DateTime doneDate = new DateTime();
                    if (task.DateSubmitted != null)
                    {
                        doneDate = task.DateSubmitted.Value;
                    }

                    SendTaskViewModel model = new SendTaskViewModel() { Id = task.Id, Name = task.Name, Done = task.Done, DoneDate = doneDate, Seen = task.Seen, ProcessStartDate = processInstance.DateStarted.Value, StartedByUser = processInstance.StartedByUser, TaskCreatedDate = task.DateCreated.Value, Timedout = tout, Version = process.WS_Project_Version, ProcessName = process.WS_Project.Name };

                    model.ToMultiSubject = task.ToMultiSubject;

                    model.selectedRecipient = "";
                    string editableParametersString = "";
                    if (task.Done)
                    {
                        if (!tout)
                        {
                            editableParametersString = task.SubmittedEditableParameters;

                            model.selectedRecipient = task.SubmittedTaskProperties;
                     
                        }
                    }
                    else
                    {
                        editableParametersString = task.EditableParameters;

                        task.TaskProperties.ForEach(tp => model.Recipients.Add(new SelectListItem { Selected = false, Value = tp.Value, Text = tp.Value }));

                        if (model.ToMultiSubject)
                        {
                            foreach (var user in task.TaskProperties)
                            {
                                if (!user.Value.Contains('|'))
                                {
                                    model.selectedRecipient = user.Value;
                                }
                            }
                        }

                    }

                    //var readableParameters = Json.Decode<IDictionary<string, dynamic>>(task.ReadableParameters);
                    IDictionary<string, dynamic> readableParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(task.ReadableParameters);
                    if (readableParameters != null)
                        foreach (var i in readableParameters)
                        {
                            model.ReadableParameters.Add(new TaskParameter(i.Key, i.Value));// { Name = i.Key, Value = i.Value });
                        }

                    if (editableParametersString == null)
                        editableParametersString = "";
                   // var editableParameters = Json.Decode<Dictionary<string, JObject>>(task.EditableParameters);
                    IDictionary<string, dynamic> editableParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(editableParametersString);
                    
                    if (editableParameters != null)
                        foreach (var i in editableParameters)
                        {
                            model.EditableParameters.Add(new TaskParameter(i.Key, i.Value));// { Name = i.Key, Value = i.Value });
                        }

                    return model;
                }
            }

            return null;
        }

        public bool setSendTask(SendTaskViewModel stviewmodel, string username)
        {
            initService();
            initCore();

            if (CanUserAccessTask(stviewmodel.Id, username))
            {
                if (stviewmodel.ToMultiSubject && stviewmodel.SelectedUsers != null)
                {

                    string toAll = null;

                    List<string> recipients = stviewmodel.SelectedUsers.ToList<string>();

                    foreach (string user in recipients)
                    {
                        if (!user.Contains('|'))
                        {
                            toAll = user;

                        }
                    }

                    if (toAll == null)
                    {
                        stviewmodel.selectedRecipient = "";
                        recipients.ForEach(i => stviewmodel.selectedRecipient = stviewmodel.selectedRecipient + i + ",");
                        stviewmodel.selectedRecipient = stviewmodel.selectedRecipient.Remove(stviewmodel.selectedRecipient.Length - 1, 1);
                    }
                    else
                    {
                        stviewmodel.selectedRecipient = toAll;
                    }

                }

                Dictionary<string, dynamic> editableparameters = new Dictionary<string, dynamic>();
                stviewmodel.EditableParameters.ForEach(tp => editableparameters.Add(tp.Name, tp.Value));



                core.submitSendTaskAnswer(stviewmodel.Id, stviewmodel.selectedRecipient, encodeEditableParameters(stviewmodel.Id, editableparameters), username);
                return true;
            }

            return false;
        }

        public Models.JobsViewModels.ReceiveTaskViewModel getReceiveTask(int id, string username)
        {
            initService();
            if (CanUserAccessTask(id, username))
            {


                var task = taskStore.getTaskById(id);

                if (task.Type.Equals("R"))
                {
                    var processInstance = _db.P_ProcessInstance.Find(task.P_ProcessInstance_Id);
                    var process = _db.P_Processes.Find(processInstance.P_Process_Id);
                    bool tout = false;
                    if (task.SubmittedTaskProperties != null)
                    {
                        if (task.SubmittedTaskProperties.Equals("TimeOut!"))
                        {
                            tout = true;
                        }
                    }


                    DateTime doneDate = new DateTime();
                    if (task.DateSubmitted != null)
                    {
                        doneDate = task.DateSubmitted.Value;
                    }
                    ReceiveTaskViewModel model = new ReceiveTaskViewModel() { Id = task.Id, Name = task.Name, Done = task.Done, Seen = task.Seen, DoneDate = doneDate, ProcessStartDate = processInstance.DateStarted.Value, StartedByUser = processInstance.StartedByUser, TaskCreatedDate = task.DateCreated.Value, Timedout = tout, Version = process.WS_Project_Version, ProcessName = process.WS_Project.Name };

                    List<M_Message> mlist = new List<M_Message>();
                    if (task.Done)
                    {
                        if (!tout)
                        {
                            try
                            {
                                mlist.Add(messageStore.getMessageBymsgId(int.Parse(task.SubmittedTaskProperties)));
                            }
                            catch(Exception e)
                            {

                            }
                        }
                    }
                    else
                    {


                        //find to the task related messages
                       mlist = messageStore.getMessagesForReceiveStateTask(task.WFId, task.getTaskPropertiesAsListOfString());
                    }


                        // mlist.ForEach(m => model.Messages.Add(new MessagesViewModel { Message_Id = m.Id, Message_Type = m.Message_Type, Sender_Username = m.Sender_Username, Parameters = Json.Decode<Dictionary<string, string>>(m.Data) }));


                        foreach (var m in mlist)
                        {
                            IDictionary<string, dynamic> editableParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(m.Data);
                            MessagesViewModel mvm = new MessagesViewModel() { Message_Id = m.Id, Message_Type = m.Message_Type, Sender_Username = m.Sender_Username };
                            if (editableParameters != null)
                                foreach (var i in editableParameters)
                                {
                                    mvm.Parameters.Add(new TaskParameter(i.Key, i.Value));// { Name = i.Key, Value = i.Value });
                                }
                            model.Messages.Add(mvm);
                        }
                    
                  
                  //  mlist.ForEach(m => model.Messages.Add(new MessagesViewModel { Message_Id = m.Id, Message_Type = m.Message_Type, Sender_Username = m.Sender_Username, Parameters = new Dictionary<string, string>() }));


                    return model;
                }
            }

            return null;
        }

        public bool setReceiveTask(ReceiveTaskViewModel rtviewmodel, string username)
        {
            initService();
            initCore();
            if (CanUserAccessTask(rtviewmodel.Id, username))
            {
                core.submitReceiveTaskAnswer(rtviewmodel.Id, rtviewmodel.selectedMessages.First(), username);

                return true;
            }
            else
                return false;
        }

        public void setTaskAsSeen(int id, string username)
        {
            initService();
            if (CanUserAccessTask(id, username))
            {

                taskStore.setTaskAsSeen(id);
            }
        }

        public List<StartProcessItemViewModel> getStartProcesses(string username)
        {
            initService();

            List<StartProcessItemViewModel> model = new List<StartProcessItemViewModel>();

            processStore.getStartProcessSubjectsForUser(username).ForEach(sp => model.Add(new StartProcessItemViewModel { Id = sp.Id, Name = sp.Process.WS_Project.Name, Description = sp.Process.WS_Project.Description, Version = sp.Process.WS_Project_Version }));

            return model;
        }

        public bool startProcess(int processSubjectId, string username)
        {
            initService();
            initCore();

            var subject = processStore.getProcessSubject(processSubjectId);
            if (subject.CanBeStarted == true)
            {
                bool ok = false;
                foreach (var role in userStore.getRolesForUser(username))
                {
                    if (role == subject.U_Role_Id)
                        ok = true;
                }

                if (ok)
                {
                    core.startNewSubjectProcess(processSubjectId, username);
                    return true;
                }
            }
            return false;
        }

        public bool CanUserAccessTask(int taskid, string username)
        {
            initService();
            T_Task task;
            P_WorkflowInstance workflowinstance;
            try
            {
                task = taskStore.getTaskById(taskid);

                workflowinstance = processStore.getWorkflowInstance(task.WFId);
            }
            catch (Exception e)
            {
                return false;
            }

            if (String.IsNullOrEmpty(workflowinstance.Owner))
            {
                var subject = processStore.getProcessSubjectForWFId(task.WFId);

                foreach (var role in userStore.getRolesForUser(username))
                {
                    if (role == subject.U_Role_Id)
                        return true;
                }
            }
            else
            {
                if (workflowinstance.Owner.Equals(username))
                    return true;
            }



            return false;
        }


        public List<TaskListItemViewModel> getAnsweredTaskListForUser(string username)
        {
            initService();

            List<TaskListItemViewModel> list = new List<TaskListItemViewModel>();
            var tasks = taskStore.getTasksAnsweredByUsername(username);

            if (tasks != null)
            {
                foreach (T_Task t in tasks)
                {
                    list.Add(new TaskListItemViewModel { Id = t.Id, Name = t.Name, Done = t.Done, Type = t.Type, ProcessId = taskStore.getProcessIdForTask(t.Id), OrderId = t.InternalOrderId, DateTime = t.DateSubmitted.ToString(), DateTimeSubmitted = getDate(t.DateSubmitted) });
                }
            }

            return list;
        }

        private DateTime getDate(DateTime? date)
        {
            if(date == null)
            {
                return DateTime.Now;
            }
            else
            {
                return (DateTime) date;
            }
        }
    }
}