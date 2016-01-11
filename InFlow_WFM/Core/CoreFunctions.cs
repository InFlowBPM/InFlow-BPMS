using Microsoft.Activities;
using Microsoft.Workflow.Client;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Core
{
    /// <summary>
    /// core functions for process execution
    /// </summary>
    public class CoreFunctions
    {
        string baseAddress;
        System.Net.NetworkCredential credentials;
        string connectionString;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="wfmBaseAddress"></param>
        /// <param name="wfmUsername"></param>
        /// <param name="wfmPassword"></param>
        /// <param name="connectionString"></param>
        public CoreFunctions(string wfmBaseAddress, string wfmUsername, string wfmPassword, string connectionString)
        {
            this.baseAddress = wfmBaseAddress;
            this.credentials = new System.Net.NetworkCredential(wfmUsername, wfmPassword);
            this.connectionString = connectionString;
        }

        public void terminateSubjectInstance(string workFlowId)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            var instance = processStore.getWorkflowInstance(workFlowId);
            var subject = instance.ProcessSubject;
            var process = subject.Process;

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(baseAddress + process.WFM_RootScope + process.WFM_ProcessScope), credentials);
            client.Instances.Terminate(subject.WFM_WFName, workFlowId, "ProcessEnd");
        }

        /// <summary>
        /// start a new instance of a processsubject with new processinstanceid
        /// </summary>
        /// <param name="subjectProcessId">processsubjectid</param>
        /// <param name="username">owner of new processsubject instance</param>
        public void startNewSubjectProcess(int subjectProcessId, string username)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);

            Console.WriteLine("start " + subjectProcessId + " " + username);
            P_ProcessSubject subject = processStore.getProcessSubject(subjectProcessId);
            P_Process process = processStore.getProcess(subject.Process_Id);

            string adress = baseAddress + process.WFM_RootScope + process.WFM_ProcessScope;
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(adress), credentials);

            string guid = client.Workflows.Start(subject.WFM_WFName);

            processStore.addWorkflowInstance(subject.Id, guid, username);
            processStore.addNewProcessInstanceInfo(guid, process.Id, subject.Id, username);
        }

        /// <summary>
        /// start a new instance of a processsubject with an existing processinstanceid
        /// </summary>
        /// <param name="processInstanceId">existing processinstanceid</param>
        /// <param name="subjectProcessId">id of the processsubject</param>
        /// <param name="username">owner of the new processsubject instance</param>
        /// <returns>id of the new workflow instance</returns>
        public string startNewSubjectProcess(string processInstanceId, int subjectProcessId, string username)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);

            Console.WriteLine("start2 " + subjectProcessId + " " + username);
            P_ProcessSubject subject = processStore.getProcessSubject(subjectProcessId);
            P_Process process = processStore.getProcess(subject.Process_Id);

            string adress = baseAddress + process.WFM_RootScope + process.WFM_ProcessScope;
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(adress), credentials);
            string guid = client.Workflows.Start(subject.WFM_WFName);

            processStore.addWorkflowInstance(subject.Id, processInstanceId, guid, username);
            Console.WriteLine(guid, ConsoleColor.Blue);
            return guid;
        }

        /// <summary>
        /// Set taskanswer for a function-state task
        /// </summary>
        /// <param name="taskId">Id of the task</param>
        /// <param name="transition">choosen transition</param>
        /// <param name="editableParameters">edited parameters</param>
        public void submitFunctionTaskAnswer(int taskId, string transition, string editableParameters, string username)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            ITaskStore taskStore = StoreHandler.getTaskStore(connectionString);

            T_Task openTask = taskStore.getTaskById(taskId);

            //check if task isn't already answered
            if (openTask.Done == false && openTask.Type.Equals("F"))
            {
                P_ProcessSubject processSubject = processStore.getProcessSubjectForWFId(openTask.WFId);
                P_Process process = processStore.getProcess(processSubject.Process_Id);

                DynamicValue val = DynamicValue.Parse(editableParameters);
                val.Add("transition", new DynamicValue(transition));

                submitTaskAnswer(val, process, openTask);

                //set task as answered
               // taskStore.setTaskStatus(taskId, true);
                taskStore.setTaskStatus(taskId, username, editableParameters, transition);
            }
        }


        /// <summary>
        /// Set taskanswer for a send-state task
        /// </summary>
        /// <param name="taskId">Id of the task</param>
        /// <param name="recipientName">choosen recipient/s</param>
        /// <param name="editableParameters">edited parameters</param>
        public void submitSendTaskAnswer(int taskId, string recipientName, string editableParameters, string username)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            ITaskStore taskStore = StoreHandler.getTaskStore(connectionString);

            T_Task openTask = taskStore.getTaskById(taskId);

            //check if task isn't already answered
            if (openTask.Done == false && openTask.Type.Equals("S"))
            {
                P_ProcessSubject processSubject = processStore.getProcessSubjectForWFId(openTask.WFId);
                P_Process process = processStore.getProcess(processSubject.Process_Id);

                DynamicValue val = DynamicValue.Parse(editableParameters);
                val.Add("recipient", new DynamicValue(recipientName));

                submitTaskAnswer(val, process, openTask);

                //set task as answered
                //taskStore.setTaskStatus(taskId, true);
                taskStore.setTaskStatus(taskId, username, editableParameters, recipientName);
            }
        }

        /// <summary>
        /// Set taskanswer for a receive-task
        /// </summary>
        /// <param name="taskId">Id of the task</param>
        /// <param name="messageInstanceId">Id of the choosen message</param>
        /// <param name="username">username</param>
        public void submitReceiveTaskAnswer(int taskId, string messageInstanceId, string username)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(connectionString);
            ITaskStore taskStore = StoreHandler.getTaskStore(connectionString);

            T_Task openTask = taskStore.getTaskById(taskId);

            //check if task isn't already answered
            if (openTask.Done == false && openTask.Type.Equals("R"))
            {
                P_ProcessSubject processSubject = processStore.getProcessSubjectForWFId(openTask.WFId);
                P_Process process = processStore.getProcess(processSubject.Process_Id);

                DynamicValue val = new DynamicValue();
                val.Add("MessageId", new DynamicValue(messageInstanceId));

                submitTaskAnswer(val, process, openTask);

                //set task as answered
                //taskStore.setTaskStatus(taskId, true);
                taskStore.setTaskStatus(taskId, username, "", messageInstanceId);

                //set the owner of the task recipient instance to the user who submitted the taskanswer
                processStore.setWorkflowInstanceOwner(openTask.WFId, username);
            }
        }

        private void submitTaskAnswer(DynamicValue val, P_Process process, T_Task openTask)
        {
            //create and publish notification
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(baseAddress + process.WFM_RootScope + process.WFM_ProcessScope), credentials);
            client.PublishNotification(new WorkflowNotification()
            {
                Properties =
                        {
                            { "NotificationType", "taskAnswer" },
                            { "wfID", openTask.WFId },
                            { "OrderId", openTask.InternalOrderId }
                        },
                Content = new Dictionary<string, object>()
                        {
                            { "data", val }
                        }
            });
        }

    }
}
