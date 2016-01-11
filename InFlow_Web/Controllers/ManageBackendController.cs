using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Web.Models.ManageBackendViewModels;
using strICT.InFlow.WFM.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "CompanyAdmin")]
    public class ManageBackendController : Controller
    {
        InFlowDb _db = new InFlowDb();

      
        public ActionResult Index(int projectId)
        {


            ViewBag.ProjectFilter = projectId;
            List<ManageBackendProcessItemViewModel> model = new List<ManageBackendProcessItemViewModel>();

            List<P_Process> processes = new List<P_Process>();

            if (projectId == -1)
            {
                processes = _db.P_Processes.ToList();
            }
            else
            {
                processes = _db.P_Processes.Where(result => result.WS_ProjectId == projectId).ToList();
            }

            foreach (var p in processes)
            {
                ManageBackendProcessItemViewModel item = new ManageBackendProcessItemViewModel() { ProcessInfo = p.ProcessInfo, ProcessId = p.Id, GlobalProcessName = p.GlobalProcessName, ProcessScopeName = p.WFM_ProcessScope , Version = p.WS_Project_Version, ProjectId = p.WS_ProjectId, ProjectName = p.WS_Project.Name, PublishDate = p.PublishDate.ToString(), Active = p.Active };
                model.Add(item);
            }

            return View(model);
        }

        public ActionResult Deactivate(int ProcessId, int ProjectFilter)
        {
            _db.P_Processes.Find(ProcessId).Active = false;
            _db.SaveChanges();
            return RedirectToAction("Index", new { projectId = ProjectFilter });
        }

        public ActionResult Activate(int ProcessId, int ProjectFilter)
        {
            _db.P_Processes.Find(ProcessId).Active = true;
            _db.SaveChanges();
            return RedirectToAction("Index", new { projectId = ProjectFilter });
        }

        public ActionResult DeleteFull(int ProcessId, int ProjectFilter)
        {
            try
            {
                string wfmBaseAddress = ConfigurationSettings.AppSettings["wfmBaseAddress"].ToString();
                string wfmUsername = ConfigurationSettings.AppSettings["wfmUsername"].ToString();
                string wfmPassword = ConfigurationSettings.AppSettings["wfmPassword"].ToString();
                string sqlConnectionString = ConfigurationSettings.AppSettings["repositoryConnectionString"].ToString();


                InFlowWFM wfm = new InFlowWFM(wfmBaseAddress, wfmUsername, wfmPassword, sqlConnectionString);

                wfm.deleteProcess(ProcessId, true);

                return RedirectToAction("Index", new { projectId = ProjectFilter });
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                    ViewBag.Error = ViewBag.Error + e.Message;
                }
                return View("Error");
            }
        }

        public ActionResult ViewDetails(int processId)
        {
            var p = _db.P_Processes.Find(processId);

            string connectionString = ConfigurationSettings.AppSettings["repositoryConnectionString"].ToString();
            IUserStore ustore = StoreHandler.getUserStore(connectionString);


            ManageBackendProcessDetailViewModel model = new ManageBackendProcessDetailViewModel() { ProcessInfo = p.ProcessInfo, ProcessId = p.Id, GlobalProcessName = p.GlobalProcessName, ProcessScopeName = p.WFM_ProcessScope, Version = p.WS_Project_Version, ProjectId = p.WS_ProjectId, ProjectName = p.WS_Project.Name, PublishDate = p.PublishDate.ToString(), Active = p.Active };

            foreach(var sub in p.ProcessSubjects)
            {
                ManageBackendProcessDetailSubjectViewModel subjectvm = new ManageBackendProcessDetailSubjectViewModel() { Name = sub.Name, AssignedRole = sub.U_Role.Name, RelatedUsers =  ustore.getUsernamesForRole(sub.U_Role_Id)};
                model.Subjects.Add(subjectvm);
            }



            return View(model);
        }

    }
}