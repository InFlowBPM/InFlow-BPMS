using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// Get the workflow intance id of the currently executed workflow
    /// </summary>
    public sealed class GetWorkflowInstanceId : CodeActivity
    {
        public OutArgument<string> GlobalWFId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            context.SetValue(GlobalWFId, context.WorkflowInstanceId.ToString() );      
        }
    }
}
