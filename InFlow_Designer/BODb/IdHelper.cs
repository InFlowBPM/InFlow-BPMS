using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.BODb
{
    public class IdHelper
    {
        public static int getBODItemId(BODdb db, int BOD_BO_Id)
        {
            try
            {
                int max = db.BOD_BOs.Find(BOD_BO_Id).Items.Max(r => r.Id);
                return max + 1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }
    }
}
