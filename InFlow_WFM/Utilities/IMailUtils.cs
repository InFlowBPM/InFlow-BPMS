using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Utilities
{
    public interface IMailUtils
    {
        void sendMail(string to, string subject, string data);
    }
}
