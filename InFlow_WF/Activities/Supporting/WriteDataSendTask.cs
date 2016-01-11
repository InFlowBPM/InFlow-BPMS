using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Activities;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// Write data of send-taskanswers
    /// </summary>
    public sealed class WriteDataSendTask : CodeActivity
    {
        [RequiredArgument]
        public InArgument<DynamicValue> Data { get; set; }
        [RequiredArgument]
        public InOutArgument<DynamicValue> GlobalVariables { get; set; }
        [RequiredArgument]
        public OutArgument<string> Recipient { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
                DynamicValue data = context.GetValue(this.Data);
                DynamicValue transition = new DynamicValue();
                data.TryGetValue("recipient", out transition);
                context.SetValue(Recipient, transition.ToString());
                data.Remove("recipient");

                DynamicValue variables = context.GetValue(GlobalVariables);
                foreach (string i in data.Keys)
                {
                    DynamicValue value = new DynamicValue();
                    data.TryGetValue(i, out value);
                    if (variables.ContainsKey(i))
                    {
                        variables.Remove(i);
                    }
                    variables.Add(i, value);
                }

                context.SetValue(GlobalVariables, variables);
        }
    }
}
