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
    /// Store message to the message-store
    /// </summary>
    public sealed class StoreMessage : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> GlobalProcessName { get; set; }
        [RequiredArgument]
        public InArgument<string> ProcessInstanceId { get; set; }
        [RequiredArgument]
        public InArgument<string> SenderId { get; set; }
        [RequiredArgument]
        public InArgument<string> SenderSubject { get; set; }
        [RequiredArgument]
        public InArgument<string> SenderUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> RecipientId { get; set; }
        [RequiredArgument]
        public InArgument<string> RecipientSubject { get; set; }
        [RequiredArgument]
        public InArgument<string> RecipientUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> Type { get; set; }
        [RequiredArgument]
        public InArgument<string> Data { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }
        [RequiredArgument]
        public InArgument<int> Recipient_Role_Id { get; set; }

        [RequiredArgument]
        public OutArgument<int> MessageId { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            IMessageStore messageStore = StoreHandler.getMessageStore(context.GetValue(cfgSQLConnectionString));

            M_Message m = new M_Message(context.GetValue(SenderId), context.GetValue(RecipientSubject), context.GetValue(RecipientUsername), context.GetValue(Type), context.GetValue(Data));
            m.GlobalProcessName = context.GetValue(GlobalProcessName);
            m.ProcessInstance_Id = context.GetValue(ProcessInstanceId);
            m.Sender_SubjectName = context.GetValue(SenderSubject); 
            m.Sender_Username = context.GetValue(SenderUsername);
            m.Recipient_WF_Id = context.GetValue(RecipientId);
            m.Recipient_Role_Id = context.GetValue(Recipient_Role_Id);
            m.Received = false;
            m.Notified = false;

            int id = messageStore.addMessage(m);

            context.SetValue(MessageId, id);
        }
    }
}
