using strICT.InFlow.Db.Contracts.InFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strICT.InFlow.Db.Store
{
    /// <summary>
    /// Interface Task-Store
    /// </summary>
    public interface ITaskStore
    {
        /// <summary>
        /// get open tasks for given username
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<T_Task> getTasksNotSeenByUsername(string name);

        List<T_Task> getTasksNotDoneByUsername(string name);

        /// <summary>
        /// get Task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        T_Task getTaskById(int taskId);

        /// <summary>
        /// set task status
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="done"></param>
        void setTaskAsSeen(int taskId);

        void setTaskAsDone(int taskId);

        void setTaskTimeOut(string WFId, int OrderId);


        void setTaskStatus(int taskId, string submittedByUser, string submittedEditableParameters, string submittedTaskProperties);

        void setAllTasksForProcessInstanceAsDone(string ProcessInstanceId);

        /// <summary>
        /// add task
        /// </summary>
        /// <param name="newTask"></param>
        /// <returns></returns>
        T_Task addTask(T_Task newTask);

        int getProcessIdForTask(int taskId);

        T_Task getReceiveTaskForMessageId(int messageId);

        List<T_Task> getTasksAnsweredByUsername(string name);
    }
}
