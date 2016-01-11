using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strICT.InFlow.Db.Store
{
    /// <summary>
    /// Implementation of the Task-Store for SQL-Databases
    /// </summary>
    public class SqlTaskStore : ITaskStore
    {
        InFlowDb db;
        string connectionString = "";

        public SqlTaskStore(string databaseConnectionString)
        {
            db = new InFlowDb(databaseConnectionString);
            connectionString = databaseConnectionString;
        }
        public List<T_Task> getTasksNotSeenByUsername(string name)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            IUserStore userStore = StoreHandler.getUserStore(connectionString);

            List<T_Task> temp = new List<T_Task>();
            var query = from t in db.T_Tasks
                        where t.Seen == false
                        select t;

            foreach (var item in query)
            {
                P_WorkflowInstance i = processStore.getWorkflowInstance(item.WFId);
                //string subjectname = processStore.getProcessSubject(i.ProcessSubject_Id).Name;
                int roleId = processStore.getProcessSubject(i.ProcessSubject_Id).U_Role_Id;
                if (i.Owner.Length > 0)
                {
                    if (i.Owner.Equals(name))
                    {
                        temp.Add(item);
                    }
                }
                else
                {
                    foreach (string us in userStore.getUsernamesForRole(roleId))
                    {
                        if (us.Equals(name))
                        {
                            temp.Add(item);
                        }
                    }
                }
            }

            return temp;
        }

        public List<T_Task> getTasksNotDoneByUsername(string name)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            IUserStore userStore = StoreHandler.getUserStore(connectionString);

            List<T_Task> temp = new List<T_Task>();
            var query = from t in db.T_Tasks 
                        where t.Done == false
                        select t;

            foreach (var item in query)
            {
                P_WorkflowInstance i = processStore.getWorkflowInstance(item.WFId);
                //string subjectname = processStore.getProcessSubject(i.ProcessSubject_Id).Name;
                int roleId = processStore.getProcessSubject(i.ProcessSubject_Id).U_Role_Id;
                if (i.Owner.Length > 0)
                {
                    if (i.Owner.Equals(name))
                    {
                        temp.Add(item);
                    }
                }
                else
                {
                    foreach(string us in userStore.getUsernamesForRole(roleId))
                    {
                        if (us.Equals(name))
                        {
                            temp.Add(item);
                        }
                    }
                }
            }

            return temp;
        }

        public T_Task getTaskById(int taskId)
        {
            var query = from t in db.T_Tasks
                        where t.Id == taskId
                        select t;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }

        public void setTaskAsSeen(int taskId)
        {
            var query = from t in db.T_Tasks
                        where t.Id == taskId
                        select t;

            foreach (var item in query)
            {
                if(item.Done == true)
                    item.Seen = true;
            }
            db.SaveChanges();
        }

        public void setTaskAsDone(int taskId)
        {
            var query = from t in db.T_Tasks
                        where t.Id == taskId
                        select t;

            foreach (var item in query)
            {
                item.Done = true;
            }
            db.SaveChanges();
        }

        public T_Task addTask(T_Task newTask)
        {

            db.T_Tasks.Add(newTask);
            db.SaveChanges();

            return newTask;
        }


        public int getProcessIdForTask(int taskId)
        {
            return db.P_WorkflowInstances.Find(db.T_Tasks.Find(taskId).WFId).ProcessSubject.Process_Id;
        }


        public void setAllTasksForProcessInstanceAsDone(string ProcessInstanceId)
        {
            var query = from t in db.T_Tasks
                        where t.P_ProcessInstance_Id == ProcessInstanceId && t.Done == false
                        select t;

            foreach (var item in query)
            {
                item.Done = true;
            }
            db.SaveChanges();
        }


        public void setTaskStatus(int taskId, string submittedByUser, string submittedEditableParameters, string submittedTaskProperties)
        {
            T_Task task = db.T_Tasks.Find(taskId);

            task.SubmittedByUser = submittedByUser;
            task.SubmittedEditableParameters = submittedEditableParameters;
            task.DateSubmitted = DateTime.Now;
            task.SubmittedTaskProperties = submittedTaskProperties;
            task.Done = true;
            task.Seen = true;

            db.SaveChanges();
        }


        public void setTaskTimeOut(string WFId, int OrderId)
        {
            var query = from t in db.T_Tasks
                        where t.WFId == WFId && t.InternalOrderId == OrderId
                        select t;

            foreach (var task in query)
            {
                task.SubmittedTaskProperties = "TimeOut!";
                task.DateSubmitted = DateTime.Now;
                task.Done = true;
            }     

            db.SaveChanges();
        }



        public T_Task getReceiveTaskForMessageId(int messageId)
        {
            var message = db.M_Messages.Find(messageId);

            var query = from t in db.T_Tasks
                        where t.WFId == message.Recipient_WF_Id && t.Type == "R" && t.Done == false
                        select t;

            List<T_Task> tasks = query.ToList();
            foreach (var task in tasks)
            {
                foreach(var item in task.TaskProperties)
                {
                    if(item.Value.Contains(message.Sender_SubjectName) && item.Value.Contains(message.Message_Type))
                    {
                        return task;
                    }
                }
            }

            return null;
        }


        public List<T_Task> getTasksAnsweredByUsername(string name)
        {
            var query = from t in db.T_Tasks
                        join si in db.P_WorkflowInstances on t.WFId equals si.Id
                        where si.Owner == name && t.Done == true
                        orderby t.DateSubmitted descending
                        select t ;

            List<T_Task> tasks = query.Take(20).ToList();

            return tasks;
        }
    }
}
