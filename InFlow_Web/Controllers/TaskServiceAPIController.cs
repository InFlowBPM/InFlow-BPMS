using strICT.InFlow.Db;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Web.Helpers;
using strICT.InFlow.Web.Models.JobsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize]
    public class TaskServiceAPIController : ApiController
    {
        IJobsHelper helper = new JobsHelper();

        [Route("TaskServiceAPI/StartProcesses")]
        public IEnumerable<StartProcessItemViewModel> GetStartProcesses()
        {
            return helper.getStartProcesses(User.Identity.Name);
        }

        [Route("TaskServiceAPI/StartProcess/{id}")]
        public bool GetStartProcess(int id)
        {
            return helper.startProcess(id, User.Identity.Name);
        }

        [Route("TaskServiceAPI/TaskType/{id}")]
        public string GetTaskType(int id)
        {
            var type =  helper.getTask(id).Type;
            return type;
        }


        [Route("TaskServiceAPI/Tasks")]
        public IEnumerable<TaskListItemViewModel> GetTasks()
        {
            return helper.getOpenTaskListForUser(User.Identity.Name);
        }

        [Route("TaskServiceAPI/FunctionTask/{id}")]
        public FunctionTaskViewModel GetFunctionTask(int id)
        {
            return helper.getFunctionTask(id, User.Identity.Name);
        }

        [Route("TaskServiceAPI/FunctionTask/{id}")]
        public HttpResponseMessage PostFunctionTask(FunctionTaskViewModel model, int id)
        {
            model.Id = id;
            if (helper.setFunctionTask(model, User.Identity.Name))
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            else
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        [Route("TaskServiceAPI/SendTask/{id}")]
        public SendTaskViewModel GetSendTask(int id)
        {
            return helper.getSendTask(id, User.Identity.Name);
        }

        [Route("TaskServiceAPI/SendTask/{id}")]
        public HttpResponseMessage PostSendTask(SendTaskViewModel model,int id)
        {
            model.Id = id;
            if (helper.setSendTask(model, User.Identity.Name))
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            else
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

        [Route("TaskServiceAPI/ReceiveTask/{id}")]
        public ReceiveTaskViewModel GetReceiveTask(int id)
        {
            return helper.getReceiveTask(id, User.Identity.Name);
        }

        [Route("TaskServiceAPI/ReceiveTask/{id}")]
        public HttpResponseMessage PostReceiveTask(ReceiveTaskViewModel model,int id)
        {
            model.Id = id;
            if (helper.setReceiveTask(model, User.Identity.Name))
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            else
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
}
