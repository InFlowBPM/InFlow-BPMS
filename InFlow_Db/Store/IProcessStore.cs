using strICT.InFlow.Db.Contracts.InFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
   /// <summary>
    /// Interface Process-Store
    /// </summary>
    public interface IProcessStore
    {
        /// <summary>
        /// add new process
        /// </summary>
        /// <param name="p"></param>
        void addNewProcess(P_Process p);

        /// <summary>
        /// List all processes that can be started by a given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<P_ProcessSubject> getStartProcessSubjectsForUser(string username);

        /// <summary>
        /// add new workflow instance (with new processInstanceId)
        /// </summary>
        /// <param name="processSubjectId"></param>
        /// <param name="guid"></param>
        /// <param name="owner"></param>
        void addWorkflowInstance(int processSubjectId, string guid, string owner);

        /// <summary>
        /// add new workflow instance (with existing processInstanceId)
        /// </summary>
        /// <param name="processSubjectId"></param>
        /// <param name="processInstanceId"></param>
        /// <param name="guid"></param>
        /// <param name="owner"></param>
        void addWorkflowInstance(int processSubjectId, string processInstanceId, string guid, string owner);

        /// <summary>
        /// get process by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        P_Process getProcess(int id);

        /// <summary>
        /// get Process by name
        /// </summary>
        /// <param name="globalprocessname">name of the process</param>
        /// <returns></returns>
        P_Process getProcess(string globalprocessname);

        /// <summary>
        /// get processSubject by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        P_ProcessSubject getProcessSubject(int id);

        /// <summary>
        /// get users who represent a given processsubject instance
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="subjectname"></param>
        /// <returns></returns>
        List<string> getUsersForProcessSubjectGuid(string guid, int roleId);

        /// <summary>
        /// get processSubject for workflow instance id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        P_ProcessSubject getProcessSubjectForWFId(string guid);

        /// <summary>
        /// get workflowInstance by Id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        P_WorkflowInstance getWorkflowInstance(string guid);

        /// <summary>
        /// get processSubject by processId and subjectName
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        P_ProcessSubject getProcessSubject(int processId, string subjectName);

        /// <summary>
        /// get workflowInstance by processSubjectId, processInstanceId and owner
        /// </summary>
        /// <param name="processSubjectId"></param>
        /// <param name="processInstanceId"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        P_WorkflowInstance getWorkflowInstance(int processSubjectId, string processInstanceId, string owner);

        /// <summary>
        /// get owner or possible owners of a workflowInstance
        /// </summary>
        /// <param name="processSubjectId"></param>
        /// <param name="processInstanceId"></param>
        /// <returns></returns>
        List<string> getWorkflowInstanceOwnersForMultisubjects(int processSubjectId, string processInstanceId);

        /// <summary>
        /// set Owner of a workflowInstance
        /// </summary>
        /// <param name="id">wfInstaneid</param>
        /// <param name="owner"></param>
        void setWorkflowInstanceOwner(string id, string owner);

        /*
        /// <summary>
        /// delete entire process from store
        /// </summary>
        /// <param name="companyScope"></param>
        /// <param name="processScope"></param>
        void deleteProcess(string companyScope, string processScope);

        /// <summary>
        /// delete entire company inkl. processes from store
        /// </summary>
        /// <param name="companyScope"></param>
        void deleteCompany(string companyScope);
        */

        void addNewProcessInstanceInfo(string processinstanceid, int P_Process_Id, int StartedBySubject_Id, string StartedByUser);

        void markProcessInstanceAsEnded(string processinstanceid, int EndedBySubject_Id, string EndedByUser);

        void updateWorkflowInstanceEndState(string instanceId, bool endState);

        bool hasProcessEnded(string processInstanceId);

        List<string> getWFInstanceIdsForProcessInstance(string processInstanceId);
    }
}
