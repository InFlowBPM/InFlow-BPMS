using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
    class SqlUserStore : IUserStore
    {
        InFlowDb db;
         string connectionString = "";
         public SqlUserStore(string databaseConnectionString)
        {
            db = new InFlowDb(databaseConnectionString);
            connectionString = databaseConnectionString;
        }

        public List<string> getUsernamesForRole(int roleId)
        {
            List<string> users = new List<string>();
            db.U_Roles.Find(roleId).FunctionGroups.ToList().ForEach(fg => fg.Users.ToList().ForEach(u => users.Add(u.Username)));
            return users;
        }

        public List<int> getRolesForUser(string username)
        {
            List<int> roles = new List<int>();

            var query = from u in db.U_User_FunctionGroups
                        where u.Username == username
                        select u.FunctionGroup;

            List<U_FunctionGroup> fgroups = new List<U_FunctionGroup>();

            foreach (U_FunctionGroup item in query)
            {
                fgroups.Add(item);
            }

            foreach (U_FunctionGroup group in fgroups)
            {
                foreach (var role in group.Roles)
                {
                    if (!roles.Contains(role.Id))
                    {
                        roles.Add(role.Id);
                    }
                }
            }

            return roles;
        }
    }
}
