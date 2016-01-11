using strICT.InFlow.Db.Contracts.InFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
    /// <summary>
    /// Interface Message-Store
    /// </summary>
    public interface IMessageStore
    {
        /// <summary>
        /// add message
        /// </summary>
        /// <param name="message"></param>
        int addMessage(M_Message message);

        /// <summary>
        /// get existing message
        /// </summary>
        /// <param name="msgID">MsgId</param>
        /// <returns>result</returns>
        M_Message getMessageBymsgId(int msgID);

        /// <summary>
        /// List all messages related to a receive-task
        /// </summary>
        /// <param name="workflowInstanceGuid">id of the worklfow instance with the receive-task</param>
        /// <param name="messageTypes">messagetypes of the receive-task</param>
        /// <returns>list of messages</returns>
        List<M_Message> getMessagesForReceiveStateTask(string workflowInstanceGuid, List<string> messageTypes);

        /// <summary>
        /// mark a message as received
        /// </summary>
        /// <param name="msgID"></param>
        void markMessageAsReceived(int msgID);

        void markMessageAsNotified(int msgID);
    }
}
