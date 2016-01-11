using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.WFM.BO_Utilities;

namespace strICT.InFlow.WFM.Activities
{
    /// <summary>
    /// store task to the task-store
    /// </summary>
    public sealed class StoreTask : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Type { get; set; }
        [RequiredArgument]
        public InArgument<string> WFId { get; set; }
        [RequiredArgument]
        public InArgument<string> Name { get; set; }
        [RequiredArgument]
        public InArgument<bool> Done { get; set; }
        [RequiredArgument]
        public InArgument<bool> IsEndState { get; set; }
        [RequiredArgument]
        public InArgument<string> ReadableParameters { get; set; }
        [RequiredArgument]
        public InArgument<string> EditableParameters { get; set; }
        [RequiredArgument]
        public InArgument<string> TaskProperties { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }

        [RequiredArgument]
        public OutArgument<int> TaskId { get; set; }

        [RequiredArgument]
        public InArgument<Int32> InternalOrderId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string editableparameters = context.GetValue(EditableParameters);
            string log = "";
            try
            {

                bool toMultiSubject = false;

                ITaskStore taskStore = StoreHandler.getTaskStore(context.GetValue(cfgSQLConnectionString));

                IProcessStore processStore = StoreHandler.getProcessStore(context.GetValue(cfgSQLConnectionString));
                P_WorkflowInstance creatorinstance = null;
                int timer = 1;
                do
                {
                    try
                    {
                        creatorinstance = processStore.getWorkflowInstance(context.GetValue(WFId));
                    }
                    catch (Exception e)
                    {
                        log = log + "[" + timer + ": " + e.Message + "]";
                        creatorinstance = null;
                        System.Threading.Thread.Sleep(500 * timer);
                        timer++;
                    }
                } while (creatorinstance == null && timer < 20);
                log = log + "(Timer: " + timer + ")";

                string taskProperties = context.GetValue(TaskProperties);
                string subjectname = taskProperties.Split('|')[0];

                //check if the task is a send-task
                if (context.GetValue(Type).Equals("S"))
                {

                    P_ProcessSubject creatorSubject = processStore.getProcessSubjectForWFId(context.GetValue(WFId));

                    P_ProcessSubject recipientSubjet = processStore.getProcessSubject(creatorSubject.Process_Id, subjectname);

                    P_WorkflowInstance recipientInstance = processStore.getWorkflowInstance(recipientSubjet.Id, creatorinstance.ProcessInstance_Id, null);

                    if (recipientSubjet.MultiSubject)
                    {
                        toMultiSubject = true;
                    }

                    //Check if Recipientinstance already Exists
                    if (recipientInstance != null)
                    {
                        //Check if recipient is a multisubject
                        if (recipientSubjet.MultiSubject)
                        {
                            //Multisubject
                            List<string> users = processStore.getWorkflowInstanceOwnersForMultisubjects(recipientInstance.ProcessSubject_Id, recipientInstance.ProcessInstance_Id);
                            users.ForEach(user => taskProperties = taskProperties + "," + subjectname + "|" + user);
                        }
                        else
                        {
                            //Normal Subject
                            if (recipientInstance.Owner != null)
                            {
                                if (recipientInstance.Owner.Length > 0)
                                {
                                    taskProperties = subjectname + "|" + recipientInstance.Owner;
                                }
                            }
                        }
                    }
                    else
                    {
                        //If instance doesn't exist
                        IUserStore userStore = StoreHandler.getUserStore(context.GetValue(cfgSQLConnectionString));
                        //List<string> username = subjectStore.getUsernamesForSubjectName(taskProperties.Split('|')[0]);
                        List<string> username = userStore.getUsernamesForRole(recipientSubjet.U_Role_Id);

                        username.ForEach(user => taskProperties = taskProperties + "," + subjectname + "|" + user);
                    }
                }
                if (context.GetValue(Type).Equals("S") || context.GetValue(Type).Equals("F"))
                {
                    if (editableparameters.Length > 0)
                    {
                        IDictionary<string, dynamic> ob = Newtonsoft.Json.JsonConvert.DeserializeObject<IDictionary<string, dynamic>>(editableparameters);

                        foreach (KeyValuePair<string, dynamic> i in ob)
                        {
                            if (ob[i.Key].Type.Value.Equals("bobasic"))
                            {
                                dynamic boconf = ob[i.Key].Value;
                                if (boconf.boi < 0)
                                {
                                    int id = (int)boconf.bo.Value;

                                    int newid = InitializeBO.initializeBO(id, context.GetValue(cfgSQLConnectionString));
                                    ob[i.Key].Value.boi = newid;
                                }
                            }
                        }
                        editableparameters = Newtonsoft.Json.JsonConvert.SerializeObject(ob);
                    }
                }

                //store task
                T_Task newTask = new T_Task(context.GetValue(Type), context.GetValue(WFId), context.GetValue(Name), context.GetValue(Done), false, context.GetValue(IsEndState), context.GetValue(ReadableParameters), editableparameters, taskProperties, context.GetValue(InternalOrderId));//, creatorinstance.ProcessSubject_Id, creatorinstance.Id);
                newTask.ToMultiSubject = toMultiSubject;
                newTask.P_ProcessInstance_Id = creatorinstance.ProcessInstance_Id;
                newTask.P_ProcessSubject_Id = creatorinstance.ProcessSubject_Id;
                var createdTask = taskStore.addTask(newTask);

                context.SetValue(TaskId, createdTask.Id);

            }catch (Exception e)
                {
                    string message = "[ cfgSQLConnectionString: " + context.GetValue(cfgSQLConnectionString);
                    message = message + "| WFId: " + context.GetValue(WFId) + "][" + log + "]";

                    message = message + e.Message;

                    throw new Exception(message);
                }
        }
    }
}
