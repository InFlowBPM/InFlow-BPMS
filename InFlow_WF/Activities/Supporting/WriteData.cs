using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Activities;

namespace strICT.InFlow.WF.Activities.Supporting
{
    /// <summary>
    /// Write the date of function-taskanswerss
    /// </summary>
    public sealed class WriteData : CodeActivity
    {
        [RequiredArgument]
        public InArgument<DynamicValue> Data { get; set; }
        [RequiredArgument]
        public InOutArgument<DynamicValue> GlobalVariables { get; set; }
        [RequiredArgument]
        public OutArgument<string> GlobalTransition { get; set; }
        
        protected override void Execute(CodeActivityContext context)
        {
            DynamicValue data = context.GetValue(this.Data);

            //set transition
            DynamicValue transition = new DynamicValue();
            data.TryGetValue("transition", out transition);
            context.SetValue(GlobalTransition, transition.ToString());
            data.Remove("transition");

            //write parameters
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
