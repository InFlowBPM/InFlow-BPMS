using Microsoft.Activities.Messaging;
using Microsoft.Workflow.Client;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Utilities
{
    /// <summary>
    /// Management tools for dBPMS
    /// </summary>
    public class InFlowWFM
    {
        string cfgWFMBaseAddress;
        string cfgWFMUsername;
        string cfgWFMPassword;
        string cfgSQLConnectionString;

        const string managementScopeName = "ManagementScope";

        const string workflow_TaskTier_Name = "TaskTier";
        const string workflow_MessageTier_Name = "MessageTier";
        const string workflow_SBMessageTier_Name = "SBMessageTier";

        System.Net.NetworkCredential credentials;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="wfmBaseAddress"></param>
        /// <param name="wfmUsername"></param>
        /// <param name="wfmPassword"></param>
        /// <param name="sqlConnectionString"></param>
        public InFlowWFM(string wfmBaseAddress, string wfmUsername, string wfmPassword, string sqlConnectionString)
        {
            this.cfgWFMBaseAddress = wfmBaseAddress;
            this.cfgWFMUsername = wfmUsername;
            this.cfgWFMPassword = wfmPassword;
            this.cfgSQLConnectionString = sqlConnectionString;

            this.credentials = new System.Net.NetworkCredential(wfmUsername, wfmPassword);
        }

        /// <summary>
        /// List all company-scopes
        /// </summary>
        /// <returns>list of company-scopes</returns>
        public List<string> listCompanyScopes()
        {
            return listScopes("");
        }

        /// <summary>
        /// List all process-scopes within a company-scope
        /// </summary>
        /// <param name="companyScopeName">Name of the company-scope</param>
        /// <returns>list of process-scopes</returns>
        public List<string> listProcessScopes(string companyScopeName)
        {
            return listScopes(companyScopeName);
        }

        /// <summary>
        /// List child-scopes of a given scope
        /// </summary>
        /// <param name="scope">scope</param>
        /// <returns>list of child-scopes</returns>
        private List<string> listScopes(string scope)
        {
            List<string> scopes = new List<string>();

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + scope), credentials);
            foreach (var i in client.CurrentScope.GetChildScopes())
            {
                scopes.Add(i.Path.TrimStart('/'));
            }
            return scopes;
        }

        /// <summary>
        /// Create a new company-scope (supporting external input-pools)
        /// </summary>
        /// <param name="companyScopeName">name of the new company-scope</param>
        /// <param name="workflow_TaskTier_Path">filepath of the task-handler workflow</param>
        /// <param name="workflow_SBMessageTier_Path">filepath of the SBMessage-handler workflow</param>
        /// <returns></returns>
        public string addCompanyScope(string companyScopeName, string workflow_TaskTier_Path, string workflow_SBMessageTier_Path)
        {
            string output = addCompanyScope(companyScopeName, workflow_TaskTier_Path);

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/" + managementScopeName + "/"), credentials);
            client.PublishWorkflow(workflow_SBMessageTier_Name, workflow_SBMessageTier_Path);

            string guid = client.Workflows.Start(workflow_SBMessageTier_Name);

            return guid;

        }

        /// <summary>
        /// Create a new company-scope (no support for external input-pools)
        /// </summary>
        /// <param name="companyScopeName">name of the new company-scope</param>
        /// <param name="workflow_TaskTier_Path">filepath of the task-handler workflow</param>
        /// <returns></returns>
        public string addCompanyScope(string companyScopeName, string workflow_TaskTier_Path)
        {

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress), credentials);
            client = client.CurrentScope.PublishChildScope(companyScopeName,
            new ScopeDescription()
            {
                UserComments = companyScopeName
            });

            //create management Scope
            createProcessScope(companyScopeName, managementScopeName);

            //init Task Tier
            client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/" + managementScopeName + "/"), credentials);

            //Console.Write("Publishing TaskTier...");
            client.PublishWorkflow(workflow_TaskTier_Name, workflow_TaskTier_Path,
                new MatchAllSubscriptionFilter()    //Filter
                {
                    Matches = 
                    { 
                        { "NotificationType" , "NewTask" }
                    }
                });

            return client.ScopeUri.ToString();
        }

        /// <summary>
        /// Delete entire company-scope
        /// </summary>
        /// <param name="companyScopeName">company-scope name</param>
        /// <param name="deleteDBEntries">delete database entries?</param>
        /// <returns></returns>
        public string deleteCompanyScope(string companyScopeName)
        {
            /*if (deleteDBEntries)
            {
                IProcessStore processStore = StoreHandler.getProcessStore(cfgSQLConnectionString);

                processStore.deleteCompany(companyScopeName);
            }*/

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/"), credentials);
            client.CleanUp();
            return companyScopeName;
        }


        /// <summary>
        /// create process-scope with configuration
        /// </summary>
        /// <param name="companyScopeName"></param>
        /// <param name="processScopeName"></param>
        /// <returns></returns>
        private string createProcessScope(string companyScopeName, string processScopeName)
        {
            IDictionary<string, string> configValues = new Dictionary<string, string>
                    {
                        { "cfgManagementScopeAddress", cfgWFMBaseAddress + companyScopeName + "/"+managementScopeName+"/" },
                        { "cfgProcessScopeAddress", cfgWFMBaseAddress + companyScopeName + "/" + processScopeName + "/" },
                        { "cfgWFMBaseAddress" , cfgWFMBaseAddress},
                        { "cfgWFMUsername", cfgWFMUsername },
                        { "cfgWFMPassword", cfgWFMPassword},
                        { "cfgSQLConnectionString", cfgSQLConnectionString }
                    };
            WorkflowConfiguration Configuration = new WorkflowConfiguration();
            configValues.ToList().ForEach(c => Configuration.AppSettings.Add(c));
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/"), credentials);
            client = client.CurrentScope.PublishChildScope(processScopeName,
            new ScopeDescription()
            {
                UserComments = processScopeName,
                DefaultWorkflowConfiguration = Configuration
            });

            string scope = client.ScopeUri.ToString();
            return scope;
        }

        /// <summary>
        /// delete an existing process/process-scope
        /// </summary>
        /// <param name="companyScopeName">name of the company-scope</param>
        /// <param name="processScopeName">name of the process-scope</param>
        /// <param name="deleteDBEntries">delete database entries?</param>
        /// <returns></returns>
        public string deleteProcess(string companyScopeName, string processScopeName)
        {
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/" + processScopeName + "/"), credentials);
            client.CleanUp();

            return companyScopeName + "/" + processScopeName;
        }

        public string deleteProcess(int P_ProcessId, bool deleteDBEntries)
        {
            InFlowDb _db = new InFlowDb(cfgSQLConnectionString);
            var p_Process = _db.P_Processes.Find(P_ProcessId);


            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + p_Process.WFM_RootScope + p_Process.WFM_ProcessScope + "/"), credentials);
            client.CleanUp();

            if (deleteDBEntries)
            {
                var p_ProcessInstances = _db.P_ProcessInstance.Where(result => result.P_Process_Id == p_Process.Id).ToList();
                foreach(var i in p_ProcessInstances)
                {
                    _db.T_Tasks.RemoveRange(_db.T_Tasks.Where(result => result.P_ProcessInstance_Id == i.Id));
                    _db.M_Messages.RemoveRange(_db.M_Messages.Where(result => result.ProcessInstance_Id == i.Id));
                }

                _db.P_ProcessInstance.RemoveRange(p_ProcessInstances);

                var p_ProcessSubjects = _db.P_ProcessSubjects.Where(result => result.Process_Id == p_Process.Id).ToList();
                foreach(var ps in p_ProcessSubjects)
                {
                    _db.P_WorkflowInstances.RemoveRange(_db.P_WorkflowInstances.Where(result => result.ProcessSubject_Id == ps.Id));
                }
                _db.P_ProcessSubjects.RemoveRange(p_ProcessSubjects);
                _db.P_Processes.Remove(p_Process);

                _db.SaveChanges();

            }

            return p_Process.WFM_RootScope + p_Process.WFM_ProcessScope;
        }

        public string addProcess(string companyScopeName, string processScopeName, string workflow_MessageTier_Path, List<SubjectConfig> processSubjects, bool createDBEntries, string startSubjectname, int WS_Project_Id, int WS_Project_Version, string processInfo)
        {
            string scope = createProcessScope(companyScopeName, processScopeName);


            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(cfgWFMBaseAddress + companyScopeName + "/" + processScopeName + "/"), credentials);
            client.PublishWorkflow(workflow_MessageTier_Name, workflow_MessageTier_Path,
               new MatchAllSubscriptionFilter()    //Filter
               {
                   Matches = 
                    { 
                        { "NotificationType" , "NewMessage" }
                    }
               });

            foreach (SubjectConfig process in processSubjects)
            {
                if (process.Xaml != null)
                {
                    client.PublishWorkflowString(process.Name, process.Xaml);

                }
            }

            if (createDBEntries)
            {
                IProcessStore processStore = StoreHandler.getProcessStore(cfgSQLConnectionString);

                P_Process newProcess = new P_Process(processScopeName);
                newProcess.WS_ProjectId = WS_Project_Id;
                newProcess.WS_Project_Version = WS_Project_Version;
                newProcess.WFM_ProcessScope = processScopeName;
                newProcess.ProcessInfo = processInfo;
                newProcess.WFM_RootScope = companyScopeName + "/";
                newProcess.ProcessSubjects = new List<P_ProcessSubject>();

                foreach (SubjectConfig process in processSubjects)
                {
                    if (process.Xaml != null)
                        newProcess.ProcessSubjects.Add(new P_ProcessSubject(process.Name, process.Name.Equals(startSubjectname), process.Name, process.Role_Id, process.MultiSubject));
                    else
                        newProcess.ProcessSubjects.Add(new P_ProcessSubject(process.Name, process.Name.Equals(startSubjectname), null, process.Role_Id, process.MultiSubject));
                }

                processStore.addNewProcess(newProcess);
            }

            return scope;
        }

    }
    public class SubjectConfig
    {
        public string Name { get; set; }
        public string Xaml { get; set; }
        public int Role_Id { get; set; }

        public bool MultiSubject { get; set; }
    }
}
