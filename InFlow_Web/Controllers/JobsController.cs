using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Helpers;
using strICT.InFlow.Web.Models.JobsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        InFlowDb _inflowDb = new InFlowDb();
        IJobsHelper helper = new JobsHelper();
        public PartialViewResult TaskList()
        {
            return PartialView("_TaskList", getPTVM());
        }

        public List<ProcessTasksViewModel> getPTVM()
        {
            List<TaskListItemViewModel> tasks = helper.getOpenTaskListForUser(User.Identity.Name);

            List<strICT.InFlow.Web.Models.JobsViewModels.ProcessTasksViewModel> model = new List<ProcessTasksViewModel>();

            Dictionary<int, ProcessTasksViewModel> temp = new Dictionary<int, ProcessTasksViewModel>();

            foreach (var task in tasks)
            {
                if (!temp.ContainsKey(task.ProcessId))
                {
                    var p = _inflowDb.P_Processes.Find(task.ProcessId);
                    temp.Add(task.ProcessId, new ProcessTasksViewModel { ProcessId = task.ProcessId, ProcessName = p.WS_Project.Name, Tasks = new List<TaskListItemViewModel>(), Version = p.WS_Project_Version, Description = p.ProcessInfo });
                }
                temp[task.ProcessId].Tasks.Add(task);
            }

            foreach (var i in temp)
            {
                i.Value.Tasks = i.Value.Tasks.OrderBy(x => x.OrderId).ThenBy(x => x.Id).ToList();
                model.Add(i.Value);
            }
            return model;
        }

        // GET: /Jobs/
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;

           

            return View(getPTVM());
        }

         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult SetStateAsSeen(int id, string mode)
        {
            helper.setTaskAsSeen(id, User.Identity.Name);
            if (mode.Equals("mobile"))
            {
                return RedirectToAction("Mobile", new { id = id });
            }
            else
            {
                return RedirectToAction("Index", new { id = -1 });
            }
        }

         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _FunctionState(int id, string mode)
        {
            ViewBag.TaskId = id;
            FunctionTaskViewModel model = helper.getFunctionTask(id, User.Identity.Name);
            model.ViewMode = mode;
            return PartialView(model);
        }

        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _FunctionState(FunctionTaskViewModel model)
        {
            helper.setFunctionTask(model, User.Identity.Name);

            if (model.ViewMode.Equals("mobile"))
            {
                return RedirectToAction("Mobile", new { id = model.Id });
            }
            else
            {
                return RedirectToAction("Index", new { id = -1 });
            }
        }

         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _SendState(int id, string mode)
        {
   
            ViewBag.TaskId = id;
            SendTaskViewModel model = helper.getSendTask(id, User.Identity.Name);
            model.ViewMode = mode;
            return PartialView(model);
        }
        public ActionResult Mobile(int id) {

           //strICT.InFlow.Db.Contracts.InFlow.T_Task t = _inflowDb.T_Tasks.Find(id);
            
            // SendTaskViewModel model = helper.getSendTask(id, User.Identity.Name);
            ViewBag.Id = id;
            return View();
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _State(int id, string mode)
        {
            string type = _inflowDb.T_Tasks.Find(id).Type;

            if (type.Equals("F"))
                return RedirectToAction("_FunctionState", new { id = id, mode = mode });

            else if (type.Equals("S"))
                return RedirectToAction("_SendState", new { id = id, mode = mode });

            else if (type.Equals("R"))
                return RedirectToAction("_ReceiveState", new { id = id, mode = mode });

            else
                return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _SendState(SendTaskViewModel model)
        {
            helper.setSendTask(model, User.Identity.Name);
            if (model.ViewMode.Equals("mobile"))
            {
                return RedirectToAction("Mobile", new { id = model.Id });
            }
            else
            {
                return RedirectToAction("Index", new { id = -1 });
            }
        }

         [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult _ReceiveState(int id, string mode)
        {      
            ViewBag.TaskId = id;
            ReceiveTaskViewModel model = helper.getReceiveTask(id, User.Identity.Name);
            model.ViewMode = mode;
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _ReceiveState(ReceiveTaskViewModel model)
        {
            helper.setReceiveTask(model, User.Identity.Name);
            if (model.ViewMode.Equals("mobile"))
            {
                return RedirectToAction("Mobile", new { id = model.Id });
            }
            else
            {
                return RedirectToAction("Index", new { id = -1 });
            }
        }



        public ActionResult NewProcess(int id)
        {
            if (id == -1)
            {
                return View(helper.getStartProcesses(User.Identity.Name));
            }
            else
            {
                helper.startProcess(id, User.Identity.Name);
                return RedirectToAction("Index", new { id = -1 });
            }
        }



        public ActionResult AnsweredTasks(int id)
        {
            ViewBag.Id = id;

            List<TaskListItemViewModel> tasks = helper.getAnsweredTaskListForUser(User.Identity.Name);

            List<strICT.InFlow.Web.Models.JobsViewModels.ProcessTasksViewModel> model = new List<ProcessTasksViewModel>();

            Dictionary<int, ProcessTasksViewModel> temp = new Dictionary<int, ProcessTasksViewModel>();

            foreach(var task in tasks)
            {
                if(!temp.ContainsKey(task.ProcessId))
                {
                    var p = _inflowDb.P_Processes.Find(task.ProcessId);
                    temp.Add(task.ProcessId, new ProcessTasksViewModel { ProcessId = task.ProcessId, ProcessName = p.WS_Project.Name, Tasks = new List<TaskListItemViewModel>(), Version = p.WS_Project_Version, Description = p.ProcessInfo  });
                }
                temp[task.ProcessId].Tasks.Add(task);
            }

            foreach(var i in temp)
            {
                i.Value.Tasks = i.Value.Tasks.OrderByDescending(x => x.DateTimeSubmitted).ToList();
                model.Add(i.Value);
            }


            return View(model);
        }
    }

}