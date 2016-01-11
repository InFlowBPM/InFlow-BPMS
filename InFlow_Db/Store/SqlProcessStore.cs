using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strICT.InFlow.Db.Store
{
    /// <summary>
    /// Implementation of the Process-Store for SQL-Databases
    /// </summary>
    public class SqlProcessStore : IProcessStore
    {
        InFlowDb db;
        string connectionString = "";
        public SqlProcessStore(string databaseConnectionString)
        {
            db = new InFlowDb(databaseConnectionString);
            connectionString = databaseConnectionString;
        }


        public void addNewProcess(P_Process p)
        {
            db.P_Processes.Add(p);
            db.SaveChanges();
        }

        public List<P_ProcessSubject> getStartProcessSubjectsForUser(string username)
        {
            List<P_ProcessSubject> temp = new List<P_ProcessSubject>();

            //ISubjectStore subjectStore = StoreHandler.getSubjectStore(connectionString);
            IUserStore userStore = StoreHandler.getUserStore(connectionString);
            foreach (int role in userStore.getRolesForUser(username))
            {
                var query = from p in db.P_ProcessSubjects
                            join pr in db.P_Processes on p.Process_Id equals pr.Id
                            where p.U_Role_Id == role & p.CanBeStarted == true & pr.Active == true
                            select p;

                foreach (var item in query)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }


        public void addWorkflowInstance(int processSubjectId, string guid, string owner)
        {
            P_WorkflowInstance i = new P_WorkflowInstance(guid, guid, processSubjectId, owner);
            db.P_WorkflowInstances.Add(i);
            db.SaveChanges();
        }

        public void addWorkflowInstance(int processSubjectId, string processInstanceId, string guid, string owner)
        {
            P_WorkflowInstance i = new P_WorkflowInstance(processInstanceId, guid, processSubjectId, owner);
            db.P_WorkflowInstances.Add(i);
            db.SaveChanges();
        }

        public P_Process getProcess(int id)
        {
            var query = from p in db.P_Processes
                        where p.Id == id
                        select p;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }

        public P_ProcessSubject getProcessSubject(int id)
        {
            var query = from p in db.P_ProcessSubjects
                        where p.Id == id
                        select p;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }

        public List<string> getUsersForProcessSubjectGuid(string guid, int roleId)
        {
            List<string> temp = new List<string>();
           // ISubjectStore subjectStore = StoreHandler.getSubjectStore(connectionString);
            IUserStore userStore = StoreHandler.getUserStore(connectionString);

            var query = from w in db.P_WorkflowInstances
                        where w.Id == guid
                        select w;

            foreach (var item in query)
            {
        
               if(item.Owner.Length > 0)
                    {
                    temp.Add(item.Owner);
                }
                else
                {
                   // string subjectname = getProcessSubject(item.ProcessSubjectId).SubjectName;
                    temp.AddRange(userStore.getUsernamesForRole(roleId));
                }
            }
            return temp;
        }


        public P_ProcessSubject getProcessSubjectForWFId(string guid)
        {
            var query = from w in db.P_WorkflowInstances
                        where w.Id == guid
                        select w.ProcessSubject_Id;

            int processSubjectId = -1;
            foreach (var item in query)
            {
                processSubjectId = item;
                break;
            }

            if (processSubjectId >= 0)
            {
                var query2 = from ps in db.P_ProcessSubjects
                             where ps.Id == processSubjectId
                             select ps;

                foreach (var i in query2)
                {
                    return i;
                }
            }

            return null;
        }


        public P_WorkflowInstance getWorkflowInstance(string id)
        {
            var query = from w in db.P_WorkflowInstances
                        where w.Id == id
                        select w;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }


        public P_ProcessSubject getProcessSubject(int processId, string subjectName)
        {
            var query = from p in db.P_ProcessSubjects
                        where p.Process_Id == processId && p.Name == subjectName
                        select p;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }

        public P_WorkflowInstance getWorkflowInstance(int processSubjectId, string processInstanceId, string owner)
        {
            if (owner != null)
            {
                var query = from w in db.P_WorkflowInstances
                            where w.ProcessSubject_Id == processSubjectId && w.ProcessInstance_Id == processInstanceId && w.Owner == owner
                            select w;

                foreach (var item in query)
                {
                    return item;
                }
            }
            else
            {
                var query = from w in db.P_WorkflowInstances
                            where w.ProcessSubject_Id == processSubjectId && w.ProcessInstance_Id == processInstanceId
                            select w;

                foreach (var item in query)
                {
                    return item;
                }
            }

            return null;
        }



        public void setWorkflowInstanceOwner(string id, string owner)
        {
            var query = from w in db.P_WorkflowInstances
                        where w.Id == id
                        select w;

            foreach (var item in query)
            {
                item.Owner = owner;
                break;
            }
            db.SaveChanges();
        }

        public P_Process getProcess(string globalprocessname)
        {
            var query = from p in db.P_Processes
                        where p.GlobalProcessName.Equals(globalprocessname)
                        select p;

            foreach (var item in query)
            {
                return item;
            }
            return null;
        }


        public List<string> getWorkflowInstanceOwnersForMultisubjects(int processSubjectId, string processInstanceId)
        {
            List<string> usernames = new List<string>();

            var query = from w in db.P_WorkflowInstances
                        where w.ProcessSubject_Id == processSubjectId && w.ProcessInstance_Id == processInstanceId
                        select w.Owner;

            foreach (var item in query)
            {
                usernames.Add(item);
            }

            return usernames;
        }


        public void addNewProcessInstanceInfo(string processinstanceid, int P_Process_Id, int StartedBySubject_Id, string StartedByUser)
        {
            P_ProcessInstance pi = new P_ProcessInstance(processinstanceid, P_Process_Id, StartedBySubject_Id, StartedByUser);
            db.P_ProcessInstance.Add(pi);
            db.SaveChanges();
        }


        public void updateWorkflowInstanceEndState(string instanceId, bool endState)
        {
            var inst =  db.P_WorkflowInstances.Find(instanceId);
            inst.IsInEndState = endState;
            if (endState)
                inst.DateEndState = DateTime.Now;
           
            db.SaveChanges();
        }


        public bool hasProcessEnded(string processInstanceId)
        {
            var query = from p in db.P_WorkflowInstances
                        where p.ProcessInstance_Id == processInstanceId && p.IsInEndState == false
                        select p;

            foreach (var item in query)
            {
                return false;
            }
            return true;
        }


        public void markProcessInstanceAsEnded(string processinstanceid, int EndedBySubject_Id, string EndedByUser)
        {
            var inst = db.P_ProcessInstance.Find(processinstanceid);
            inst.EndedByUser = EndedByUser;
            inst.EndedBySubject_Id = EndedBySubject_Id;
            inst.Ended = true;
            inst.DateEnded = DateTime.Now;

            db.SaveChanges();
        }


        public List<string> getWFInstanceIdsForProcessInstance(string processInstanceId)
        {
            List<string> result = new List<string>();

            var query = from p in db.P_WorkflowInstances
                        where p.ProcessInstance_Id == processInstanceId
                        select p.Id;

            foreach (var item in query)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
