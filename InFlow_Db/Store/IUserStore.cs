using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strICT.InFlow.Db.Store
{
    public interface IUserStore
    {
        /// <summary>
        /// get users who represent a role
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        List<string> getUsernamesForRole(int roleId);



        /// <summary>
        /// get roles for a user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<int> getRolesForUser(string username);

    }
}
