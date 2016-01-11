using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using strICT.InFlow.Db.Store;
using strICT.InFlow.Db;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.WFM.Utilities;

namespace strICT.InFlow.WFM.Activities
{

    public sealed class CreateEmailNotificationForMessage : CodeActivity
    {
        [RequiredArgument]
        public InArgument<int> MessageId { get; set; }
        [RequiredArgument]
        public InArgument<string> cfgSQLConnectionString { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            NotificationHelper helper = new NotificationHelper();
            helper.createNotificationForMessage(context.GetValue(MessageId), context.GetValue(cfgSQLConnectionString));     
        }
    }
}
