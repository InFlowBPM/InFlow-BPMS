using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
    public interface IConfigStore
    {
        void setBool(string key, bool value);

        bool getBool(string key);

        void setString(string key, string value);

        string getString(string key);

        void setInt(string key, int value);

        int getInt(string key);
    }
}
