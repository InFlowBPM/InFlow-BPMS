using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.ServiceBus.Messaging;
using Microsoft.Activities;
using strICT.InFlow.WF.Helper;
using strICT.InFlow.Db.Contracts.InFlow;
using Microsoft.Workflow.Client;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// create a send-task
    /// </summary>
    public sealed class CreateSendTask : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> Name { get; set; }
        public InArgument<string> readableParameters { get; set; }
        public InArgument<string> editableParameters { get; set; }
        [RequiredArgument]
        public InArgument<bool> isEndState { get; set; }
        [RequiredArgument]
        public InArgument<string> toSubject { get; set; }

        [RequiredArgument]
        public InArgument<DynamicValue> globalVariables { get; set; }
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

            DynamicValue variables = context.GetValue(globalVariables);
            DynamicValue dvReadableParameters = new DynamicValue();
            foreach (string i in SbpmActivityHelper.convertCSVtoListofString(context.GetValue(readableParameters)))
            {
                if (variables.ContainsKey(i))
                {
                    DynamicValue value = new DynamicValue();
                    variables.TryGetValue(i, out value);
                    dvReadableParameters.Add(i, value);
                }
            }
          
            DynamicValue dvEditableParameters = new DynamicValue();
            foreach (string i in SbpmActivityHelper.convertCSVtoListofString(context.GetValue(editableParameters)))
            {
                if (variables.ContainsKey(i))
                {
                    DynamicValue value = new DynamicValue();
                    variables.TryGetValue(i, out value);
                    dvEditableParameters.Add(i, value);
                }
                else
                {
                    DynamicValue val = new DynamicValue();
                    val.Add("Type", "string");
                    val.Add("Value", "");
                    dvEditableParameters.Add(i, val);
                }
            }

            T_Task newTask = new T_Task("S", context.GetValue(globalWFId), context.GetValue(Name),false, false, context.GetValue(isEndState), dvReadableParameters.ToString(), dvEditableParameters.ToString(), context.GetValue(toSubject), context.GetValue(OrderId));//, 0, "");

            WorkflowManagementClient client = new WorkflowManagementClient(new Uri(context.GetValue(cfgManagementScopeAddress)), credentials);

            client.PublishNotification(newTask.toWorkflowNotification());

        }
    }
}
