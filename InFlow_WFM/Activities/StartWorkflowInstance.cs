using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using strICT.InFlow.WFM.Core;

namespace strICT.InFlow.WFM.Activities
{
    /// <summary>
    /// Start a new instance of a processsubject
    /// </summary>
    public sealed class StartWorkflowInstance : CodeActivity
    {
        [RequiredArgument]
        public InArgument<int> ProcessSubjectId { get; set; }
        [RequiredArgument]
        public InArgument<string> Owner { get; set; }
        [RequiredArgument]
        public InArgument<string> ProcessInstanceId { get; set; }
        [RequiredArgument]
        public OutArgument<string> NewProcessId { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMBaseAddress { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMUsername { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgWFMPassword { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            CoreFunctions core = new CoreFunctions(context.GetValue(cfgWFMBaseAddress), context.GetValue(cfgWFMUsername), context.GetValue(cfgWFMPassword), context.GetValue(cfgSQLConnectionString));
            
            string id = core.startNewSubjectProcess(context.GetValue(ProcessInstanceId),   context.GetValue(ProcessSubjectId), context.GetValue(Owner));
            context.SetValue(NewProcessId, id);
        }
    }
}
