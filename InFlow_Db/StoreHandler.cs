using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db
{
    /// <summary>
    /// central class that returns the actual store implementations
    /// </summary>
    public static class StoreHandler
    {
        /// <summary>
        /// get the message-store
        /// </summary>
        /// <param name="dbConnectionString">database connectionstring</param>
        /// <returns></returns>
        public static IMessageStore getMessageStore(string dbConnectionString)
        {
            return new SqlMessageStore(dbConnectionString);
        }

        /// <summary>
        /// get the process-store
        /// </summary>
        /// <param name="dbConnectionString">database connectionstring</param>
        /// <returns></returns>
        public static IProcessStore getProcessStore(string dbConnectionString)
        {
            return new SqlProcessStore(dbConnectionString);
        }

        public static IUserStore getUserStore(string dbConnectionString)
        {
            return new SqlUserStore(dbConnectionString);
        }

        /// <summary>
        /// get the task-store
        /// </summary>
        /// <param name="dbConnectionString">database connectionstring</param>
        /// <returns></returns>
        public static ITaskStore getTaskStore(string dbConnectionString)
        {
            return new SqlTaskStore(dbConnectionString);
        }

        public static IConfigStore getConfigStore(string dbConnectionString)
        {
            return new SqlConfigStore(dbConnectionString);
        }
    }
}
