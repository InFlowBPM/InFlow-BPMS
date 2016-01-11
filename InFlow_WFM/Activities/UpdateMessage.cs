using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;

namespace strICT.InFlow.WFM.Activities
{
    /// <summary>
    /// Update message from internal subject
    /// </summary>
    public sealed class UpdateMessage : CodeActivity
    {
        [RequiredArgument]
        public OutArgument<string> GlobalProcessName { get; set; }
        [RequiredArgument]
        public OutArgument<string> ProcessInstanceId { get; set; }
        [RequiredArgument]
        public InArgument<string> SenderId { get; set; }
        [RequiredArgument]
        public OutArgument<string> SenderSubject { get; set; }
        [RequiredArgument]
        public OutArgument<string> SenderUsername { get; set; }
        [RequiredArgument]
        public OutArgument<string> RecipientId { get; set; }
        [RequiredArgument]
        public InArgument<string> RecipientUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> RecipientSubject { get; set; }
        [RequiredArgument]
        public OutArgument<int> RecipientProcessSubjectId { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }
        [RequiredArgument]
        public OutArgument<int> Recipient_Role_Id { get; set; }
        
        public OutArgument<bool> IsMessageForExternalSubject { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(context.GetValue(cfgSQLConnectionString));
            P_WorkflowInstance senderInstance = processStore.getWorkflowInstance(context.GetValue(SenderId));
            P_ProcessSubject senderProcessSubject = processStore.getProcessSubject(senderInstance.ProcessSubject_Id);
            P_Process process = processStore.getProcess(senderProcessSubject.Process_Id);
            P_ProcessSubject recipientProcessSubject = processStore.getProcessSubject(senderProcessSubject.Process_Id, context.GetValue(RecipientSubject));

            //check if message is for internal subject
            if (recipientProcessSubject.WFM_WFName != null)
            {
                
                string recipientuser = context.GetValue(RecipientUsername);
                if(recipientuser != null)
                {
                    if(recipientuser.Length == 0)
                    {
                        recipientuser = null;
                    }
                }

                P_WorkflowInstance recipientInstance = processStore.getWorkflowInstance(recipientProcessSubject.Id, senderInstance.ProcessInstance_Id, recipientuser);
                if (recipientInstance != null)
                {
                    //update recipient workflow id
                    context.SetValue(RecipientId, recipientInstance.Id);
                }
                //message is for internal subject
                context.SetValue(IsMessageForExternalSubject, false);
                //update recipient processsubjectId
                context.SetValue(RecipientProcessSubjectId, recipientProcessSubject.Id);
            }
            else
            {
                //message is for external subject
                context.SetValue(IsMessageForExternalSubject, true);
            }

            
            context.SetValue(GlobalProcessName, process.GlobalProcessName);
            context.SetValue(ProcessInstanceId, senderInstance.ProcessInstance_Id);
            context.SetValue(SenderSubject, senderProcessSubject.Name);
            context.SetValue(SenderUsername, senderInstance.Owner);
            context.SetValue(Recipient_Role_Id, recipientProcessSubject.U_Role_Id);

            
        }
    }
}
