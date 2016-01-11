using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Utilities
{
    public class NotificationHelper
    {
        string cfgSQLConnectionString;
        string baseURL;
        string templatepath;
        IConfigStore configStore;
        ITaskStore taskStore;
        IProcessStore processStore;
        IMailUtils mail;
        IUserStore userStore;
        IMessageStore messageStore;
        P_WorkflowInstance instance;
        MailBodyHelper helper;

        private const string Email_Notifications_Tasks = "Email_Notifications_Tasks";
        private const string Email_Notifications_Messages = "Email_Notifications_Messages";
        private const string BaseURL = "BaseURL";
        private const string Email_NotificationTemplate = "Email_NotificationTemplate";

        public void createNotificationForTask(int TaskId, string cfgSQLConnectionString)
        {
            this.cfgSQLConnectionString = cfgSQLConnectionString;
            configStore = StoreHandler.getConfigStore(cfgSQLConnectionString);
            baseURL = configStore.getString(BaseURL);
            templatepath = configStore.getString(Email_NotificationTemplate);

            taskStore = StoreHandler.getTaskStore(cfgSQLConnectionString);
            T_Task task = taskStore.getTaskById(TaskId);
            helper = new MailBodyHelper();
            processStore = StoreHandler.getProcessStore(cfgSQLConnectionString);
            instance = processStore.getWorkflowInstance(task.WFId);
            mail = new SmtpUtils(configStore);
            if (task.Type.Equals("F") || task.Type.Equals("S"))
            {
                if (configStore.getBool(Email_Notifications_Tasks))
                {
                    string content = helper.getStateBody(task, baseURL, templatepath);



                    List<string> recipients = new List<string>();

                    if (String.IsNullOrEmpty(instance.Owner))
                    {
                        var subject = processStore.getProcessSubjectForWFId(task.WFId);
                        userStore = StoreHandler.getUserStore(cfgSQLConnectionString);
                        recipients.AddRange(userStore.getUsernamesForRole(subject.U_Role_Id));
                    }
                    else
                    {
                        recipients.Add(instance.Owner);
                    }

                    foreach (string user in recipients)
                    {
                        mail.sendMail(user, "InFlow: " + task.Name + " #" + task.Id, content);
                    }
                }
            }
            if (task.Type.Equals("R"))
            {
                if (configStore.getBool(Email_Notifications_Messages))
                {
                    messageStore = StoreHandler.getMessageStore(cfgSQLConnectionString);
                    var messages = messageStore.getMessagesForReceiveStateTask(task.WFId, task.getTaskPropertiesAsListOfString());

                    foreach (var i in messages)
                    {
                        createReceiveNotification(i, task);
                    }
                }
            }

        }

        public void createNotificationForMessage(int MessageId, string cfgSQLConnectionString)
        {
            this.cfgSQLConnectionString = cfgSQLConnectionString;
            configStore = StoreHandler.getConfigStore(cfgSQLConnectionString);
            baseURL = configStore.getString(BaseURL);
            templatepath = configStore.getString(Email_NotificationTemplate);

            if (configStore.getBool(Email_Notifications_Messages))
            {
                taskStore = StoreHandler.getTaskStore(cfgSQLConnectionString);
                T_Task task = taskStore.getReceiveTaskForMessageId(MessageId);
                if (task != null)
                {
                    
                    messageStore = StoreHandler.getMessageStore(cfgSQLConnectionString);
                    mail = new SmtpUtils(configStore);
                    processStore = StoreHandler.getProcessStore(cfgSQLConnectionString);
                    instance = processStore.getWorkflowInstance(task.WFId);
                    M_Message message = messageStore.getMessageBymsgId(MessageId);
                    createReceiveNotification(message, task);
                }
            }
        }

        private void createReceiveNotification(M_Message message, T_Task task)
        {

            if (message.Notified == false)
            {
                helper = new MailBodyHelper();
                string content = helper.getReceiveStateBody(message, task, baseURL, templatepath);

                List<string> recipients = new List<string>();

                if (String.IsNullOrEmpty(instance.Owner))
                {
                    var subject = processStore.getProcessSubjectForWFId(task.WFId);
                    userStore = StoreHandler.getUserStore(cfgSQLConnectionString);
                    recipients.AddRange(userStore.getUsernamesForRole(subject.U_Role_Id));
                }
                else
                {
                    recipients.Add(instance.Owner);
                }

                foreach (string user in recipients)
                {
                    mail.sendMail(user, "InFlow: " + task.Name + " #" + task.Id + "|" + message.Id, content);
                }

                messageStore.markMessageAsNotified(message.Id);
            }
        }
    }
}
