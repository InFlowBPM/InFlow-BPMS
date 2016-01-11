using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db
{
    public class DbHelper
    {
        public static void fullyDeletePD_Process(PDesignerDb db ,int PD_ProcessId)
        {
            var messages = db.PD_Messages.Where(r => r.PD_Process_Id == PD_ProcessId);
            db.PD_Messages.RemoveRange(messages);

            var messageTypes = db.PD_MessageTypes.Where(r => r.PD_Process_Id == PD_ProcessId);
            db.PD_MessageTypes.RemoveRange(messageTypes);

            var transitions = db.PD_Transitions.Where(r => r.PD_Process_Id == PD_ProcessId);
            db.PD_Transitions.RemoveRange(transitions);

            var states = db.PD_States.Where(r => r.PD_Process_Id == PD_ProcessId);
            db.PD_States.RemoveRange(states);

            var subjects = db.PD_Subjects.Where(r => r.PD_Process_Id == PD_ProcessId);
            db.PD_Subjects.RemoveRange(subjects);

            var process = db.PD_Processes.Find(PD_ProcessId);
            db.PD_Processes.Remove(process);

            db.SaveChanges();
            
        }  
    }
}
