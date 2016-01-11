using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.Identity
{
    public class UserLogItem
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public string Username { get; set; }

        public string Action { get; set; }

        public string InFlowClientType { get; set; }

        public string ClientIP { get; set; }

        public string ClientAgent { get; set; }

        public string Detail { get; set; }
    }

}
