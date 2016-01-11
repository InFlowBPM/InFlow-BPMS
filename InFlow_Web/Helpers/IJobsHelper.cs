using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Web.Models.JobsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Helpers
{
    public interface IJobsHelper
    {
         List<StartProcessItemViewModel> getStartProcesses(string username);

         bool startProcess(int processSubjectId, string username);

         List<TaskListItemViewModel> getOpenTaskListForUser(string username);
       
         FunctionTaskViewModel getFunctionTask(int id, string username);

         bool setFunctionTask(FunctionTaskViewModel ftviewmodel, string username);
     
         SendTaskViewModel getSendTask( int id, string username);

         bool setSendTask(SendTaskViewModel stviewmodel, string username);

         ReceiveTaskViewModel getReceiveTask(int id, string username);

         bool setReceiveTask(ReceiveTaskViewModel rtviewmodel, string username);

         void setTaskAsSeen(int id, string username);
         T_Task getTask(int id);


         List<TaskListItemViewModel> getAnsweredTaskListForUser(string username);
    }
}