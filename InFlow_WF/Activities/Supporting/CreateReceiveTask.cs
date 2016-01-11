using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Activities;
using strICT.InFlow.Db.Contracts.InFlow;
using Microsoft.Workflow.Client;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// Create a receive-task
    /// </summary>
    public sealed class CreateReceiveTask : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Name { get; set; }
        [RequiredArgument]
        public InArgument<string> messages { get; set; }
        [RequiredArgument]
        public InArgument<bool> isEndState { get; set; }

        [RequiredArgument]
        public InArgument<string> globalWFId { get; set; }

        [RequiredArgument]
        public InArgument<string> cfgManagementScopeAddress { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMPassword { get; set; }
        [RequiredArgument]
        public InArgument<Int32> OrderId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(context.GetValue(cfgWFMUsername), context.GetValue(cfgWFMPassword));

            T_Task newTask = new T_Task("R", context.GetValue(globalWFId), context.GetValue(Name), false, false, context.GetValue(isEndState), "", "", context.GetValue(messages), context.GetValue(OrderId));//,0,"");
            
            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(context.GetValue(cfgManagementScopeAddress)), credentials);
            client.PublishNotification(newTask.toWorkflowNotification());
        }
    }
}
