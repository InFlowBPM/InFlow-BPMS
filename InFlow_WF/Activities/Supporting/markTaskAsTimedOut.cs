using strICT.InFlow.Db;
using strICT.InFlow.Db.Store;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WF.Activities.Supporting
{
    public sealed class markTaskAsTimedOut : CodeActivity
    {

        [RequiredArgument]
        public InArgument<string> globalWFId { get; set; }

        [RequiredArgument]
        public InOutArgument<string> cfgSQLConnectionString { get; set; }

        [RequiredArgument]

        public InArgument<Int32> OrderId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            ITaskStore taskStore = StoreHandler.getTaskStore(context.GetValue(cfgSQLConnectionString));

            taskStore.setTaskTimeOut(context.GetValue(globalWFId), context.GetValue(OrderId));
        }
    }
}
