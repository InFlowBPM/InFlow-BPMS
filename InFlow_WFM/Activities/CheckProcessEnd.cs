using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.WFM.Core;

namespace strICT.InFlow.WFM.Activities
{
    /// <summary>
    /// store task to the task-store
    /// </summary>
    public sealed class CheckProcessEnd : CodeActivity
    {
        public InArgument<string> WFId { get; set; }

        [RequiredArgument]
        public InArgument<bool> IsEndState { get; set; }
       
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }

        [RequiredArgument]
        public InArgument<string> cfgWFMBaseAddress { get; set; }

        [RequiredArgument]
        public InArgument<string> cfgWFMUsername { get; set; }

        [RequiredArgument]
        public InArgument<string> cfgWFMPassword { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            IProcessStore processStore = StoreHandler.getProcessStore(context.GetValue(cfgSQLConnectionString));
            ITaskStore taskStore = StoreHandler.getTaskStore(context.GetValue(cfgSQLConnectionString));
            P_WorkflowInstance creatorinstance = processStore.getWorkflowInstance(context.GetValue(WFId));

            processStore.updateWorkflowInstanceEndState(creatorinstance.Id, context.GetValue(IsEndState));

            if (processStore.hasProcessEnded(creatorinstance.ProcessInstance_Id))
            {
                
                processStore.markProcessInstanceAsEnded(creatorinstance.ProcessInstance_Id, creatorinstance.ProcessSubject_Id, creatorinstance.Owner);
                taskStore.setAllTasksForProcessInstanceAsDone(creatorinstance.ProcessInstance_Id);

                var instances = processStore.getWFInstanceIdsForProcessInstance(creatorinstance.ProcessInstance_Id);
                CoreFunctions c = new CoreFunctions(context.GetValue(cfgWFMBaseAddress), context.GetValue(cfgWFMUsername), context.GetValue(cfgWFMPassword),context.GetValue(cfgSQLConnectionString));
                foreach(var i in instances)
                {
                    try
                    {
                        c.terminateSubjectInstance(i);
                    }
                    catch (Exception e)
                    { }           
                }
            }


        }
    }
}
