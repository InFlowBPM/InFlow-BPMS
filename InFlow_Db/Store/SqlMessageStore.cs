using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
    /// <summary>
    /// Implementation of the Message-Store for SQL-Databases
    /// </summary>
    public class SqlMessageStore : IMessageStore
    {
        InFlowDb db;
        string connectionString = "";
        public SqlMessageStore(string databaseConnectionString)
        {
            db = new InFlowDb(databaseConnectionString);
            connectionString = databaseConnectionString;
        }

        public SqlMessageStore(InFlowDb db)
        {
            this.db = db;
        }

        public int addMessage(M_Message message)
        {
            db.M_Messages.Add(message);
            db.SaveChanges();
            return message.Id;
        }

        public M_Message getMessageBymsgId(int msgId)
        {
            var query = from m in db.M_Messages
                        where m.Id == msgId
                        select m;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }


        public List<M_Message> getMessagesForReceiveStateTask(string workflowInstanceGuid, List<string> messageTypes)
        {
            List<M_Message> tmp = new List<M_Message>();
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);

            //string wfOwner = processStore.getWorkflowInstance(workflowInstanceGuid).Owner;

            var query = from m in db.M_Messages
                        where m.Recipient_WF_Id == workflowInstanceGuid & m.Received == false
                        select m;

            foreach (var item in query)
            {
                foreach (String s in messageTypes)
                {
                    String[] sa = s.Split('|');
                    String possibleFromSubject = sa[0];
                    String possibleMessageType = sa[1];


                    if (item.Message_Type.Equals(possibleMessageType) &&
                        item.Sender_SubjectName.Equals(possibleFromSubject))
                    {
                        tmp.Add(item);
                    }
                }
            }


            return tmp;
        }


        public void markMessageAsReceived(int msgID)
        {
            var query = from m in db.M_Messages
                        where m.Id == msgID
                        select m;

            foreach (var item in query)
            {
                item.Received = true;
            }
            db.SaveChanges();
        }


        public void markMessageAsNotified(int msgID)
        {
            var query = from m in db.M_Messages
                        where m.Id == msgID
                        select m;

            foreach (var item in query)
            {
                item.Notified = true;
            }
            db.SaveChanges();
        }
    }
}
