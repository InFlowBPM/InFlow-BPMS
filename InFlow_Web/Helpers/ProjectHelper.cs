using strict.InFlow.Designer.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Models.ProjectViewModels;
using strICT.InFlow.WFM.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Helpers
{
    public class ProjectHelper
    {
        InFlowDb _inflowDb = new InFlowDb();
        PDesignerDb _designerDb = new PDesignerDb();

        public void publishProject(PublishProjectP3ViewModel model)
        {
            WS_Project project = _inflowDb.WS_Projects.Find(model.Id);

            string startsubjectname = "";

            string wfmBaseAddress = ConfigurationSettings.AppSettings["wfmBaseAddress"].ToString();
            string wfmUsername = ConfigurationSettings.AppSettings["wfmUsername"].ToString();
            string wfmPassword = ConfigurationSettings.AppSettings["wfmPassword"].ToString();
            string sqlConnectionString = ConfigurationSettings.AppSettings["repositoryConnectionString"].ToString();

            string companyScopeName = ConfigurationSettings.AppSettings["companyScopeName"].ToString();

             string wfMessageTierPath = ConfigurationSettings.AppSettings["wfMessageTierPath"].ToString();
             string wfTaskTierPath = ConfigurationSettings.AppSettings["wfTaskTierPath"].ToString();

             InFlowWFM wfm = new InFlowWFM(wfmBaseAddress, wfmUsername, wfmPassword, sqlConnectionString);

             List<strICT.InFlow.WFM.Utilities.SubjectConfig> subjects = new List<strICT.InFlow.WFM.Utilities.SubjectConfig>();

            
            foreach(WS_Subject subject in project.Subjects)
            {
                if(subject.U_Role_Id == 0)
                {
                    throw new Exception("Role for Subject " + subject.Name + " not Set!");
                }
                if(subject.CanBeStarted)
                {
                    startsubjectname = subject.Name;
                }
                subjects.Add(new strICT.InFlow.WFM.Utilities.SubjectConfig { Name = subject.Name, Xaml = subject.Xaml_Data, Role_Id = subject.U_Role_Id , MultiSubject = subject.MultiSubject});
            }

            string processscopename = System.IO.Path.GetRandomFileName();

            while(_inflowDb.P_Processes.Count(result => result.WFM_ProcessScope == companyScopeName & result.WFM_ProcessScope == processscopename) > 0)
            {
                processscopename = System.IO.Path.GetRandomFileName();
            }

            wfm.addProcess(companyScopeName, processscopename, wfMessageTierPath, subjects, true, startsubjectname, model.Id, model.Version, model.ProcessInfo);
       
           //Lock Model Version

            int modelId = _inflowDb.WS_ModelVersions.First(r => r.WS_ProjectId == model.Id & r.Version == model.Version).PD_ProcessId;
            var m = _designerDb.PD_Processes.Find(modelId);
            m.LockedBy = "InFlow_BackEnd";
            _designerDb.SaveChanges();

        }



     
    }
}