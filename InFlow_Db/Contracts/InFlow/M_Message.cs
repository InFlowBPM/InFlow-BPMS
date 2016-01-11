using Microsoft.ServiceBus.Messaging;
using Microsoft.Workflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    /// <summary>
    /// Enity Message
    /// </summary>
    public class M_Message
    {
        public int Id { get; set; }
        public string GlobalProcessName { get; set; }
        public string ProcessInstance_Id { get; set; }
        public string Sender_WF_Id { get; set; }
        public string Sender_SubjectName { get; set; }
        public string Sender_Username { get; set; }
        public int Sender_Role_Id { get; set; }
        public string Recipient_WF_Id { get; set; }
        public string Recipient_SubjectName { get; set; }
        public string Recipient_Username { get; set; }
        public int Recipient_Role_Id { get; set; }
        public string Message_Type { get; set; }
        public string Data { get; set; }
        public bool Received { get; set; }
        public bool Notified { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public M_Message()
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="recipientSubject"></param>
        /// <param name="recipientUsername"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public M_Message(string senderId, string recipientSubject, string recipientUsername, string type, string data)
        {
            this.Sender_WF_Id = senderId;

            this.Recipient_SubjectName = recipientSubject;
            this.Recipient_Username = recipientUsername;
            this.Message_Type = type;
            this.Data = data;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="m">BrokerMessage</param>
        public M_Message(BrokeredMessage m)
        {
            GlobalProcessName = (string)m.Properties["GlobalProcessName"];
            ProcessInstance_Id = (string)m.Properties["ProcessInstanceId"];
            Sender_SubjectName = (string)m.Properties["SenderSubject"];
            Recipient_SubjectName = (string)m.Properties["RecipientSubject"];

            Message_Type = (string)m.Properties["Type"];
            Data = (string)m.Properties["Data"];

            Received = false;
            Notified = false;
        }

        /// <summary>
        /// convert message to workflowNotification
        /// </summary>
        /// <returns></returns>
        public WorkflowNotification toWorkflowNotification()
        {
            return new WorkflowNotification()
            {
                Properties =
                {
                    { "NotificationType" , "NewMessage" }
                },
                Content = new Dictionary<string, object>()
                { 
                    { "SenderId", Sender_WF_Id },
                    { "GlobalProcessName", GlobalProcessName },
                    { "ProcessInstanceId", ProcessInstance_Id },
                    { "SenderSubject", Sender_SubjectName },
                    { "RecipientSubject", Recipient_SubjectName },
                    { "RecipientUsername", Recipient_Username },
                    { "Type", Message_Type },
                    { "Data", Data }
                }
            };
        }

        /// <summary>
        /// convert message to brokeredMessage
        /// </summary>
        /// <returns></returns>
        public BrokeredMessage toBrokeredMessage()
        {
            BrokeredMessage message = new BrokeredMessage(Message_Type + "-Message from " + Sender_SubjectName + " to " + Recipient_SubjectName);

            message.Properties.Add("GlobalProcessName", GlobalProcessName);
            message.Properties.Add("ProcessInstanceId", ProcessInstance_Id);
            message.Properties.Add("SenderSubject", Sender_SubjectName);
            message.Properties.Add("RecipientSubject", Recipient_SubjectName);
            message.Properties.Add("Type", Message_Type);
            message.Properties.Add("Data", Data);

            return message;
        }
    }
}
