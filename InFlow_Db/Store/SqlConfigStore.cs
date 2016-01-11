using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Store
{
    public class SqlConfigStore : IConfigStore
    {
        InFlowDb db;
        string connectionString = "";
        public SqlConfigStore(string databaseConnectionString)
        {
            db = new InFlowDb(databaseConnectionString);
            connectionString = databaseConnectionString;
        }

        public SqlConfigStore(InFlowDb db)
        {
            this.db = db;
        }
        public void setBool(string key, bool value)
        {
            C_Property property = db.C_Properties.Find(key);

            if(property == null)
            {
                property = new C_Property { Key = key, Type = PropertyTypes.BOOL, Value = value.ToString() };
                db.C_Properties.Add(property);
            }
            else
            {
                if (isBool(property))
                {
                    property.Value = value.ToString();
                }
            }
            db.SaveChanges();
        }

       

        public bool getBool(string key)
        {
             C_Property property = db.C_Properties.Find(key);

             if (property != null)
             {
                 if (isBool(property))
                     return Boolean.Parse(property.Value);
             }

             throw new Exception("Property " + key + "not found");
        }

        public void setString(string key, string value)
        {
            C_Property property = db.C_Properties.Find(key);

            if (property == null)
            {
                property = new C_Property { Key = key, Type = PropertyTypes.STRING, Value = value };
                db.C_Properties.Add(property);
            }
            else
            {
                if (isString(property))
                {
                    property.Value = value;
                }
            }
            db.SaveChanges();
        }

        public string getString(string key)
        {
            C_Property property = db.C_Properties.Find(key);

            if (property != null)
            {
                if (isString(property))
                    return property.Value;
            }

            throw new Exception("Property " + key + "not found");
        }

        public void setInt(string key, int value)
        {
            C_Property property = db.C_Properties.Find(key);

            if (property == null)
            {
                property = new C_Property { Key = key, Type = PropertyTypes.INT, Value = value.ToString() };
                db.C_Properties.Add(property);
            }
            else
            {
                if (isInt(property))
                {
                    property.Value = value.ToString(); ;
                }
            }
            db.SaveChanges();
        }

        public int getInt(string key)
        {
            C_Property property = db.C_Properties.Find(key);

            if (property != null)
            {
                if (isInt(property))
                    return Int32.Parse(property.Value);
            }

            throw new Exception("Property " + key + "not found");
        }

        private bool isBool(C_Property property)
        {
            if (property.Type == PropertyTypes.BOOL)
            {
                return true;
            }
            else
            {
                throw new Exception("Property " + property.Key + " is not a boolean");
            }
        }

        private bool isString(C_Property property)
        {
            if (property.Type == PropertyTypes.STRING)
            {
                return true;
            }
            else
            {
                throw new Exception("Property " + property.Key + " is not a string");
            }
        }

        private bool isInt(C_Property property)
        {
            if (property.Type == PropertyTypes.INT)
            {
                return true;
            }
            else
            {
                throw new Exception("Property " + property.Key + " is not a integer");
            }
        }
    }
}
