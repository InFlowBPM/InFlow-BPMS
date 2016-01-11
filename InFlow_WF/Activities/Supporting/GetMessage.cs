using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Activities;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Db.Contracts.InFlow;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// receive a message from the message-store
    /// </summary>
    public sealed class GetMessage : CodeActivity
    {
        [RequiredArgument]
        public InArgument<DynamicValue> Data { get; set; }
        [RequiredArgument]
        public InOutArgument<DynamicValue> GlobalVariables { get; set; }
        [RequiredArgument]
        public InOutArgument<string> GlobalTransition { get; set; }
        [RequiredArgument]
        public InOutArgument<string> cfgSQLConnectionString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DynamicValue taskdata = context.GetValue(this.Data);

            DynamicValue MessageId = new DynamicValue();
            taskdata.TryGetValue("MessageId", out MessageId);

            IMessageStore messageStore = strICT.InFlow.Db.StoreHandler.getMessageStore(context.GetValue(cfgSQLConnectionString));
            M_Message message = messageStore.getMessageBymsgId(Convert.ToInt32(MessageId.ToString()));

            //store message-type in GlobalTransition
            context.SetValue(GlobalTransition, message.Sender_SubjectName + "|" + message.Message_Type);


            DynamicValue data = DynamicValue.Parse(message.Data);
            DynamicValue variables = context.GetValue(GlobalVariables);

            //write message data to GlobalVariables
            foreach (string i in data.Keys)
            {
                DynamicValue value = new DynamicValue();
                data.TryGetValue(i, out value);
                if (variables.ContainsKey(i))
                {
                    variables.Remove(i);
                }
                variables.Add(i, value);
            }
            context.SetValue(GlobalVariables, variables);

            //mark message in message-store as received
            messageStore.markMessageAsReceived(message.Id);      
        }
    }
}
