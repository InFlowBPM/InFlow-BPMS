using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db
{
    public class IdHelper
    {
        public static int getMessageTypeId(PDesignerDb db ,int PD_ProcessId)
        {
            try
            {
                int max = db.PD_Processes.Find(PD_ProcessId).MessageTypes.Max(r => r.Id);
                return max +1;
            }
            catch(Exception e)
            {
                return 1;
            }
        }

        public static int getMessageId(PDesignerDb db, int PD_ProcessId)
        {
            try
            {
                int max = db.PD_Processes.Find(PD_ProcessId).Messages.Max(r => r.Id);
                return max + 1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        public static int getSubjectId(PDesignerDb db, int PD_ProcessId)
        {
            try
            {
                int max = db.PD_Processes.Find(PD_ProcessId).Subjects.Max(r => r.Id);
                return max + 1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        public static int getStateId(PDesignerDb db, int PD_ProcessId, int PD_SubjectId)
        {
            try
            {
                int max = db.PD_Subjects.Find(PD_ProcessId, PD_SubjectId).States.Max(r => r.Id);
                return max + 1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        public static int getTransitionId(PDesignerDb db, int PD_ProcessId, int PD_SubjectId)
        {
            try
            {
                int max = db.PD_Subjects.Find(PD_ProcessId, PD_SubjectId).Transitions.Max(r => r.Id);
                return max +1;
            }
            catch (Exception e)
            {
                return 1;
            }
        }
    }
}
