using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Activities;
using strICT.InFlow.WF.Helper;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.Store;
using Microsoft.Workflow.Client;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// create a new Message
    /// </summary>
    public sealed class CreateMessage : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> recipient { get; set; }
        [RequiredArgument]
        public InArgument<string> type { get; set; }
        [RequiredArgument]
        public InArgument<string> parameters { get; set; }

        [RequiredArgument]
        public InArgument<DynamicValue> globalVariables { get; set; }
        [RequiredArgument]
        public InArgument<string> globalWFId { get; set; }

        [RequiredArgument]
        public InArgument<string> cfgProcessScopeAddress { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMPassword { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(context.GetValue(cfgWFMUsername), context.GetValue(cfgWFMPassword));

            DynamicValue variables = context.GetValue(globalVariables);

            //set message data
            DynamicValue data = new DynamicValue();
            foreach (string i in SbpmActivityHelper.convertCSVtoListofString(context.GetValue(parameters)))
            {
                if (variables.ContainsKey(i))
                {
                    DynamicValue value = new DynamicValue();
                    variables.TryGetValue(i, out value);
                    data.Add(i, value);
                }
            }

            List<string> recipients = new List<string>(context.GetValue(recipient).Split(','));
            List<M_Message> messages = new List<M_Message>();

            
            if (recipients.Count == 1)
            {
                List<string> usernames = new List<string>();
                IUserStore userStore = StoreHandler.getUserStore(context.GetValue(cfgSQLConnectionString));
                string[] recipientArray = recipients[0].Split('|');
                string recipientSubject = recipientArray[0];

                IProcessStore processStore = StoreHandler.getProcessStore(context.GetValue(cfgSQLConnectionString));
                P_ProcessSubject senderSubject = processStore.getProcessSubjectForWFId(context.GetValue(globalWFId));
                P_WorkflowInstance senderinstance = processStore.getWorkflowInstance(context.GetValue(globalWFId));
                P_ProcessSubject recipientSubjet = processStore.getProcessSubject(senderSubject.Process_Id, recipientSubject);

                if (recipientSubjet.MultiSubject && recipientArray.Length == 1)//If multisubject
                {
                    P_WorkflowInstance recipientInstance = processStore.getWorkflowInstance(recipientSubjet.Id, senderinstance.ProcessInstance_Id, null);
                    //Check if Recipientinstance already Exists
                    if (recipientInstance != null)
                    {
                        //recipients are only existing processsubjectinstances
                        usernames = processStore.getWorkflowInstanceOwnersForMultisubjects(recipientInstance.ProcessSubject_Id, recipientInstance.ProcessInstance_Id);
                    }
                    else
                    {   
                        //recipients are all users who represent the processsubject
                       // usernames = subjectStore.getUsernamesForSubjectName(recipientArray[0]);
                        usernames = userStore.getUsernamesForRole(recipientSubjet.U_Role_Id);
                    }

                    foreach (string user in usernames)
                    {
                        M_Message m = new M_Message(context.GetValue(globalWFId), recipientSubject, user, context.GetValue(type), data.ToString());
                        messages.Add(m);
                    }
                }
                else
                { //simple Subject
                    
                    string recipientUsername = "";

                    if (recipientArray.Length > 1)
                    {
                        recipientUsername = recipientArray[1];
                    }

                    M_Message m = new M_Message(context.GetValue(globalWFId), recipientSubject, recipientUsername, context.GetValue(type), data.ToString());
                    messages.Add(m);
                }
            }
            else //multisubject
            {
                foreach (string rec in recipients)
                {
                    string[] recipientArray = rec.Split('|');
                    string recipientSubject = recipientArray[0];
                    string recipientUsername = "";

                    if (recipientArray.Length > 1)
                    {
                        recipientUsername = recipientArray[1];
                    }
                    M_Message m = new M_Message(context.GetValue(globalWFId), recipientSubject, recipientUsername, context.GetValue(type), data.ToString());
                    messages.Add(m);
                }
            }

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(context.GetValue(cfgProcessScopeAddress)), credentials);
            messages.ForEach(m => client.PublishNotification(m.toWorkflowNotification()));
        }
    }
}
