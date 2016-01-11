using strict.InFlow.Designer.Db.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strict.InFlow.Designer.Db
{
    public class PDesignerDb : DbContext
    {
        public PDesignerDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<PD_Process> PD_Processes { get; set; }
        public DbSet<PD_Subject> PD_Subjects { get; set; }

        public DbSet<PD_State> PD_States { get; set; }
        public DbSet<PD_FunctionState> PD_FunctionStates { get; set; }
        public DbSet<PD_SendState> PD_SendStates { get; set; }
        public DbSet<PD_ReceiveState> PD_ReceiveStates { get; set; }
        public DbSet<PD_RefinementState> PD_RefinementStates { get; set; }

        public DbSet<PD_Transition> PD_Transitions { get; set; }
        public DbSet<PD_RegularTransition> PD_RegularTransitions { get; set; }
        public DbSet<PD_ReceiveTransition> PD_ReceiveTransitions { get; set; }
        public DbSet<PD_TimeoutTransition> PD_TimeoutTransitions { get; set; }

        public DbSet<PD_Message> PD_Messages { get; set; }
        public DbSet<PD_MessageType> PD_MessageTypes { get; set; }

        public DbSet<PD_Parameter> PD_Parameters { get; set; }


        
       /* static Process _p = null;
        public List<Process> Processes = new List<Process>();

        public DesignerDb()
        {

            if (_p == null)
            {
                _p = new Process() {Id = 1, Locked = true, LockedBy = "user1", Name = "CRPattern" };

                Subject customer = new Subject() { Name = "Customer", CanBeStarted = true, PositionLeft = 100, PositionTop = 100 };

                customer.GlobalParameters.Add("Product");
                customer.GlobalParameters.Add("Amount");
                customer.GlobalParameters.Add("Price");

                Subject supplier = new Subject() { Name = "Supplier", MultiSubject = true, PositionLeft = 400, PositionTop = 100 };

                supplier.GlobalParameters.Add("Product");
                supplier.GlobalParameters.Add("Amount");
                supplier.GlobalParameters.Add("Price");

                _p.Subjects.Add(customer);
                _p.Subjects.Add(supplier);

                MessageType request = new MessageType() { Name = "Request" };
                request.Parameters.Add("Product");
                request.Parameters.Add("Amount");

                MessageType offer = new MessageType() { Name = "Offer" };

                _p.MessageTypes.Add(request);
                _p.MessageTypes.Add(offer);

                Message requesttosupplier = new Message() { From = customer.Id, To = supplier.Id, Type = request.Id };
                Message offertocustomer = new Message() { From = supplier.Id, To = customer.Id };

                _p.Messages.Add(requesttosupplier);
                _p.Messages.Add(offertocustomer);

                var c_ss1 = new SendState() { Name = "Send Request to Supplier", Message = requesttosupplier.Id, EndState = false, PositionLeft = 200, PositionTop = 100 };
                c_ss1.EditableParameters.Add("Product");
                c_ss1.EditableParameters.Add("Amount");
                var c_rs2 = new ReceiveState() { Name = "Receive Offer from Supplier", EndState = false, PositionLeft = 200, PositionTop = 250 };
                var c_fs3 = new FunctionState() { Name = "Offer Received from Supplier", EndState = true, PositionLeft = 300, PositionTop = 400 };
                c_fs3.ReadableParameters.Add("Product");
                c_fs3.ReadableParameters.Add("Amount");
                c_fs3.ReadableParameters.Add("Price");
                var c_fs4 = new FunctionState() { Name = "No Offer Received", EndState = false, PositionLeft = 50, PositionTop = 400 };

                customer.States.Add(c_ss1);
                customer.States.Add(c_rs2);
                customer.States.Add(c_fs3);
                customer.States.Add(c_fs4);

                var c_requestsent = new RegularTransition() { Name = "Request Sent", Source = c_ss1.Id, Target = c_rs2.Id };
                var c_offerreceived = new ReceiveTransition() { Message = offertocustomer.Id, Source = c_rs2.Id, Target = c_fs3.Id };
                var c_timeout = new TimeoutTransition() { TimeSpan = "00:01:00", Source = c_rs2.Id, Target = c_fs4.Id };

                customer.Transitions.Add(c_requestsent);
                customer.Transitions.Add(c_offerreceived);
                customer.Transitions.Add(c_timeout);

                var s_rs1 = new ReceiveState() { Name = "Receive Request from Customer", EndState = false, PositionLeft = 200, PositionTop = 100 };
                var s_ss2 = new SendState() { Name = "Send Offer to Customer", Message = offertocustomer.Id, EndState = false, PositionLeft = 200, PositionTop = 240 };

                supplier.States.Add(s_rs1);
                supplier.States.Add(s_ss2);

                Transition s_or = new ReceiveTransition() { Message = requesttosupplier.Id, Source = s_rs1.Id, Target = s_ss2.Id };
                supplier.Transitions.Add(s_or);
            }

            Processes.Add(_p);
        }*/
    }
}
