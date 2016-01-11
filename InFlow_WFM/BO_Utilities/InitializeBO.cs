using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.BO_Utilities
{
    public static class InitializeBO
    {
        public static int initializeBO(int BusinessObjectId, string connectionString)
        {

            BODb _db = new BODb(connectionString);

            BO_BusinessObjectInstance boi = new BO_BusinessObjectInstance();

            var bo = _db.BusinessObjects.Find(BusinessObjectId);

            boi.BusinessObjectId = bo.Id;
            boi.Data = bo.DefaultData;

            _db.BusinessObjectInstances.Add(boi);
            _db.SaveChanges();

            return boi.Id;
        }
    }
}
