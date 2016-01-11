using strict.InFlow.Designer.Db;
using strict.InFlow.Designer.Db.Contracts;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xaml;
using System.Activities.XamlIntegration;
using System.Activities;
using System.Activities.Statements;
using System.Activities.XamlIntegration;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using Microsoft.CSharp.Activities;
using Microsoft.Activities;
using strICT.InFlow.WF.Activities.SBPM;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.Activities;
using strICT.InFlow.WF.Activities.Supporting;


namespace strICT.InFlow.Web.Helpers
{
    public class ValidationError
    {
        public string Item { get; set; }
        public string Description { get; set; }
    }
    public class SbpmModelHelper
    {
        InFlowDb _inflowDB = new InFlowDb();
        PDesignerDb _pdesignerDB = new PDesignerDb();

        public int copyModel(int PD_ProcessId)
        {
            var process = _pdesignerDB.PD_Processes.Find(PD_ProcessId);

            PD_Process newProcess = new PD_Process() { Name = process.Name };

            _pdesignerDB.PD_Processes.Add(newProcess);
            _pdesignerDB.SaveChanges();

            foreach(var p in process.Parameters)
            {
                PD_Parameter par = new PD_Parameter() { PD_Process_Id = newProcess.Id, Name = p.Name, Config = p.Config };
                _pdesignerDB.PD_Parameters.Add(par);
                _pdesignerDB.SaveChanges();
            }

            foreach(var mt in process.MessageTypes)
            {
                PD_MessageType newMessageType = new PD_MessageType() { Id = mt.Id, Name = mt.Name, Parameters = mt.Parameters, PD_Process_Id = newProcess.Id };
                _pdesignerDB.PD_MessageTypes.Add(newMessageType);
                _pdesignerDB.SaveChanges();
            }

            foreach(var m in process.Messages)
            {
                PD_Message newMessage = new PD_Message() { Id = m.Id, From = m.From, To = m.To, PD_MessageType_Id = m.PD_MessageType_Id, PD_MessageType_Process_Id = newProcess.Id, PD_Process_Id = newProcess.Id };
                _pdesignerDB.PD_Messages.Add(newMessage);
                _pdesignerDB.SaveChanges();
            }

            foreach (var s in process.Subjects)
            {
                PD_Subject newSubject = new PD_Subject() { Id = s.Id, CanBeStarted = s.CanBeStarted, ExternalSubject = s.ExternalSubject, GlobalParameters = s.GlobalParameters, MultiSubject = s.MultiSubject, Name = s.Name, PD_Process_Id = newProcess.Id, PositionLeft = s.PositionLeft, PositionTop = s.PositionTop };
                _pdesignerDB.PD_Subjects.Add(newSubject);
                _pdesignerDB.SaveChanges();

                foreach (var st in s.States)
                {
                    if (st.Type == PD_StateTypes.FunctionState)
                    {
                        var oS = (PD_FunctionState)st;
                        PD_FunctionState newS = new PD_FunctionState() { EditableParameters = oS.EditableParameters, EndState = oS.EndState, Id = oS.Id, Name = oS.Name, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, PositionLeft = oS.PositionLeft, PositionTop = oS.PositionTop, ReadableParameters = oS.ReadableParameters, StartState = oS.StartState, Type = oS.Type };
                        _pdesignerDB.PD_FunctionStates.Add(newS);
                        _pdesignerDB.SaveChanges();
                    }
                    if (st.Type == PD_StateTypes.SendState)
                    {
                        var oS = (PD_SendState)st;
                        PD_SendState newS = new PD_SendState() { EditableParameters = oS.EditableParameters, EndState = oS.EndState, Id = oS.Id, Name = oS.Name, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, PositionLeft = oS.PositionLeft, PositionTop = oS.PositionTop, ReadableParameters = oS.ReadableParameters, StartState = oS.StartState, Type = oS.Type, Message = oS.Message };
                        _pdesignerDB.PD_SendStates.Add(newS);
                        _pdesignerDB.SaveChanges();
                    }
                    if (st.Type == PD_StateTypes.ReceiveState)
                    {
                        var oS = (PD_ReceiveState)st;
                        PD_ReceiveState newS = new PD_ReceiveState() { EndState = oS.EndState, Id = oS.Id, Name = oS.Name, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, PositionLeft = oS.PositionLeft, PositionTop = oS.PositionTop, StartState = oS.StartState, Type = oS.Type };
                        _pdesignerDB.PD_ReceiveStates.Add(newS);
                        _pdesignerDB.SaveChanges();
                    }
                }

                foreach (var t in s.Transitions)
                {
                    if (t.Type == PD_TransitionTypes.RegularTransition)
                    {
                        var oT = (PD_RegularTransition)t;
                        PD_RegularTransition newT = new PD_RegularTransition() { Id = oT.Id, Name = oT.Name, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, Source = oT.Source, Target = oT.Target, Type = oT.Type };
                        _pdesignerDB.PD_RegularTransitions.Add(newT);
                        _pdesignerDB.SaveChanges();
                    }
                    if (t.Type == PD_TransitionTypes.ReceiveTransition)
                    {
                        var oT = (PD_ReceiveTransition)t;
                        PD_ReceiveTransition newT = new PD_ReceiveTransition() { Id = oT.Id, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, Source = oT.Source, Target = oT.Target, Type = oT.Type, Message = oT.Message };
                        _pdesignerDB.PD_ReceiveTransitions.Add(newT);
                        _pdesignerDB.SaveChanges();
                    }
                    if (t.Type == PD_TransitionTypes.TimeoutTransition)
                    {
                        var oT = (PD_TimeoutTransition)t;
                        PD_TimeoutTransition newT = new PD_TimeoutTransition() { Id = oT.Id, PD_Process_Id = newProcess.Id, PD_Subject_Id = newSubject.Id, Source = oT.Source, Target = oT.Target, Type = oT.Type, TimeSpan = oT.TimeSpan };
                        _pdesignerDB.PD_TimeoutTransitions.Add(newT);

                    }
                }
            }

            _pdesignerDB.SaveChanges();

            return newProcess.Id;
        }

        public List<ValidationError> validateModel(int PD_Process_Id)
        {
            List<ValidationError> validationerrors = new List<ValidationError>();

            var process = _pdesignerDB.PD_Processes.Find(PD_Process_Id);

            //check process
            if (process.Subjects.Count == 0)
            {
                validationerrors.Add(new ValidationError { Item = "Process", Description = "Process Model contains no Subjects" });
            }
            int startsubjectcount = process.Subjects.Where(result => result.CanBeStarted == true).Count();
            if (startsubjectcount == 0)
            {
                validationerrors.Add(new ValidationError { Item = "Process", Description = "No starting Subject defined" });
            }
            if (startsubjectcount > 1)
            {
                validationerrors.Add(new ValidationError { Item = "Process", Description = "More than one starting subject defined" });
            }

            //check subjects
            foreach (PD_Subject subject in process.Subjects)
            {
                if (subject.States.Count == 0)
                {
                    validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "No states defined" });
                }

                int startstatecount = subject.States.Where(result => result.StartState == true).Count();
                if (startstatecount == 0)
                {
                    validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "No StartState defined" });
                }
                else
                {
                    if (subject.CanBeStarted)
                    {
                        if (subject.States.First(result => result.StartState == true).Type == PD_StateTypes.ReceiveState)
                        {
                            validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "Start State can't be a Receive State" });
                        }
                    }
                    else
                    {
                        if (subject.States.First(result => result.StartState == true).Type != PD_StateTypes.ReceiveState)
                        {
                            validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "Start State must be a Receive State" });
                        }
                    }
                }

                if (startstatecount > 1)
                {
                    validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "More than one StartState defined" });
                }

                int endstatecount = subject.States.Where(result => result.EndState == true).Count();
                if (endstatecount == 0)
                {
                    validationerrors.Add(new ValidationError { Item = "Subject: " + subject.Name, Description = "No EndState defined" });
                }

                if (process.Subjects.Count > 1)
                {
                    if (subject.CanBeStarted)
                    {
                        if (process.Messages.Count(result => result.From == subject.Id) == 0)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name, Description = "No Send-Message defined for this Subject" });
                        }
                    }
                    else
                    {
                        if (process.Messages.Count(result => result.To == subject.Id) == 0)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name, Description = "No Receive-Messages defined for this Subject" });
                        }
                    }
                }

                foreach(PD_State state in subject.States)
                {
                    if(state.StartState == false)
                    {
                        if(subject.Transitions.Count(r => r.Target == state.Id) == 0)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "No Target Transition set" });
                        }
                    }
                    if (state.EndState == false)
                    {
                        if (subject.Transitions.Count(r => r.Source == state.Id) == 0)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "No Source Transition set" });
                        }
                    }
                    
                    if(state.Type == PD_StateTypes.SendState)
                    {
                        if(((PD_SendState)state).Message == null)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "No Message set" });
                        }

                        int transitioncount = subject.Transitions.Count(r => r.Type == PD_TransitionTypes.RegularTransition && r.Source == state.Id);
                        if (transitioncount > 1)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "Only one Transition can be set for Send-States." });
                        }
                    }

                    if (state.Type == PD_StateTypes.ReceiveState)
                    {
                        int transitioncount = subject.Transitions.Count(r => r.Type == PD_TransitionTypes.ReceiveTransition && r.Source == state.Id);
                        if (transitioncount == 0)
                        {
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "No Receive Transition set!" });
                        }
                    }

                    //check timeout transitions.
                    int timeouttransitioncount = subject.Transitions.Count(r => r.Type == PD_TransitionTypes.TimeoutTransition && r.Source == state.Id);
                    if(timeouttransitioncount > 1)
                    {
                        validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + " State: " + state.Name, Description = "Only one Timeout-Transition can be set per state." });
                    }

                    
                }

                foreach(PD_Transition transition in subject.Transitions)
                {
                    if(transition.Type == PD_TransitionTypes.ReceiveTransition)
                    {
                        if(((PD_ReceiveTransition)transition).Message == null)
                        {
                            var source = subject.States.First(r => r.Id == transition.Source);
                            var target = subject.States.First(r => r.Id == transition.Target);
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + ", Receive Transition from " + source.Name + " to " + target.Name, Description = "No Message set" });
                        }
                    }

                    if (transition.Type == PD_TransitionTypes.TimeoutTransition)
                    {
                        try
                        {
                            var time = TimeSpan.Parse(((PD_TimeoutTransition)transition).TimeSpan);
                        }
                        catch(Exception e)
                        {
                            var source = subject.States.First(r => r.Id == transition.Source);
                            var target = subject.States.First(r => r.Id == transition.Target);
                            validationerrors.Add(new ValidationError() { Item = "Subject: " + subject.Name + ", TimeOut Transition from " + source.Name + " to " + target.Name, Description = "Timespan not correct" });
                        }
                    }
                }
            }

          

            foreach(PD_Message message in process.Messages)
            {
                var from = process.Subjects.First(r => r.Id == message.From);
                var to = process.Subjects.First(r => r.Id == message.To);

                if(message.PD_MessageType_Id == null)
                {
                    validationerrors.Add(new ValidationError() { Item = "Message from " + from.Name + " to " + to.Name, Description = "No Message Type defined" });
                    message.PD_MessageType = new PD_MessageType() { Name = "NOT SET!" };
                }

                bool hassendstate = false;
                foreach (var s in from.States.Where(r => r.Type == PD_StateTypes.SendState))
                {
                    if(((PD_SendState)s).Message == message.Id)
                    {
                        hassendstate = true;
                    }
                }
                if(!hassendstate)
                {
                    validationerrors.Add(new ValidationError() { Item = "Message from " + from.Name + " to " + to.Name + " of Type " + message.PD_MessageType.Name, Description = "No SendState in Subject " + from.Name + " defined" });
                }

                bool hasreceive = false;
                foreach (var t in to.Transitions.Where(r => r.Type == PD_TransitionTypes.ReceiveTransition) )
                {
                    if (((PD_ReceiveTransition)t).Message == message.Id)
                    {
                        hasreceive = true;
                    }
                }
                if (!hasreceive)
                {
                    validationerrors.Add(new ValidationError() { Item = "Message from " + from.Name + " to " + to.Name + " of Type " + message.PD_MessageType.Name, Description = "No Receive Transition in Subject " + to.Name + " defined" });
                }
            };

            return validationerrors;
        }

        public int translateToXaml(int projectid, int modelid)
        {
            var process = _pdesignerDB.PD_Processes.Find(modelid);
            var project = _inflowDB.WS_Projects.Find(projectid);

            _inflowDB.WS_Subjects.RemoveRange(project.Subjects);

            int subjects = 0;
            foreach (var subject in process.Subjects)
            {
                WS_Subject s = new WS_Subject() { Name = subject.Name, CanBeStarted = subject.CanBeStarted, MultiSubject = subject.MultiSubject };
                s.Xaml_Data = buildXaml(process, subject);
                project.Subjects.Add(s);
                subjects++;
            }

            _inflowDB.SaveChanges();

            return subjects;
        }

        private string buildXaml(PD_Process process, PD_Subject subject)
        {
            Flowchart flow = new Flowchart();
            Variable flowGlobalTransition = new Variable<String> { Name = "GlobalTransition" };
            Variable flowGlobalVariables = new Variable<DynamicValue> { Name = "GlobalVariables"};
          


            string globVariablesInit = "";
            if (subject.GlobalParameters.Count > 0)
            {
                globVariablesInit = "{";
                foreach (string p in subject.GlobalParameters)
                {
                    var par = _pdesignerDB.PD_Parameters.Find(subject.PD_Process_Id, p);
                    globVariablesInit = globVariablesInit + "\""+ p +"\":"+ par.Config +",";
                }
                globVariablesInit = globVariablesInit.Remove(globVariablesInit.Length - 1, 1);
                globVariablesInit = globVariablesInit + "}";
            }

            Variable flowGlobalVariablesSchema = new Variable<string> { Name = "GlobalVariablesSchema", Default = globVariablesInit };

            Dictionary<int, FlowStep> nodeList = new Dictionary<int, System.Activities.Statements.FlowStep>();

            flow.Variables.Add(flowGlobalTransition);
            flow.Variables.Add(flowGlobalVariables);
            flow.Variables.Add(flowGlobalVariablesSchema);

            

            foreach (var state in subject.States)
            {
                FlowStep f;
                if (state.Type == PD_StateTypes.FunctionState)
                {
                    var s = (PD_FunctionState)state;
                    string timeout = "";
                    try
                    {
                        var timeouttransition = subject.Transitions.First(result => result.Source == s.Id && result.Type == PD_TransitionTypes.TimeoutTransition);

                        timeout = ((PD_TimeoutTransition)timeouttransition).TimeSpan;
                    }
                    catch (Exception e)
                    {

                    }
                    var transitions = subject.Transitions.Where(result => result.Source == s.Id && result.Type == PD_TransitionTypes.RegularTransition);
                    List<string> titems = new List<string>();
                    transitions.ToList().ForEach(i => titems.Add(((PD_RegularTransition)i).Name));
                    f = new FlowStep() { Action = new FunctionStateT() { DisplayName = s.Name, OrderId = s.Id, name = s.Name, GlobalTransition = new OutArgument<string>(flowGlobalTransition), GlobalVariables = new InOutArgument<DynamicValue>(flowGlobalVariables), isEndState = s.EndState, readableParameters = collectionToString(s.ReadableParameters), editableParameters = collectionToString(s.EditableParameters), TimeOut = timeout, transitions = collectionToString(titems) } };
                }
                else if (state.Type == PD_StateTypes.SendState)
                {
                    var s = (PD_SendState)state;
                    string timeout = "";
                    try
                    {
                        var timeouttransition = subject.Transitions.First(result => result.Source == s.Id && result.Type == PD_TransitionTypes.TimeoutTransition);

                        timeout = ((PD_TimeoutTransition)timeouttransition).TimeSpan;
                    }
                    catch (Exception e)
                    {

                    }
                    var message = process.Messages.First(result => result.Id == s.Message);
                    string to = process.Subjects.First(result => result.Id == message.To).Name;
                    f = new FlowStep() { Action = new SendStateT() { DisplayName = s.Name, OrderId = s.Id, name = s.Name, GlobalTransition = new OutArgument<string>(flowGlobalTransition), GlobalVariables = new InOutArgument<DynamicValue>(flowGlobalVariables), isEndState = s.EndState, readableParameters = collectionToString(s.ReadableParameters), editableParameters = collectionToString(s.EditableParameters), messageType = message.PD_MessageType.Name, parameters = collectionToString(message.PD_MessageType.Parameters), toSubject = to, TimeOut = timeout } };

                }
                else //(state.Type == PD_StateTypes.ReceiveState)
                {
                    var s = (PD_ReceiveState)state;
                    string messages = "";
                    List<string> messagelist = new List<string>();
                    var receivetransitions = subject.Transitions.Where(result => result.Source == s.Id && result.Type == PD_TransitionTypes.ReceiveTransition);

                    foreach (var i in receivetransitions)
                    {
                        messagelist.Add(receiveTranstionToString(process, (PD_ReceiveTransition)i));
                    }
                    messages = collectionToString(messagelist);

                    string timeout = "";
                    try
                    {
                        var timeouttransition = subject.Transitions.First(result => result.Source == s.Id && result.Type == PD_TransitionTypes.TimeoutTransition);
                        timeout = ((PD_TimeoutTransition)timeouttransition).TimeSpan;
                    }
                    catch (Exception e)
                    {

                    }

                    f = new FlowStep() { Action = new ReceiveStateT() { DisplayName = s.Name, OrderId = s.Id, name = s.Name, GlobalTransition = new OutArgument<string>(flowGlobalTransition), GlobalVariables = new InOutArgument<DynamicValue>(flowGlobalVariables), isEndState = s.EndState, TimeOut = timeout, messages = messages } };
                }
                flow.Nodes.Add(f);
                nodeList.Add(state.Id, f);
            }


            var initGP = new FlowStep() { Action = new InitializeGlobalParameters() { DisplayName = "init GP", DynamicVal = new InOutArgument<DynamicValue>(flowGlobalVariables), GlobalParameterSchema = new InArgument<string>(flowGlobalVariablesSchema) } };

            initGP.Next = nodeList[subject.States.First(result => result.StartState == true).Id];
            flow.StartNode = initGP;

            // flow.StartNode = nodeList[subject.States.First(result => result.StartState == true).Id];


            foreach (var state in subject.States)
            {
                List<PD_Transition> transitions = new List<PD_Transition>();
                try
                {
                    subject.Transitions.Where(result => result.Source == state.Id).ToList().ForEach(item => transitions.Add(item));
                }
                catch (Exception e) { }

                if (transitions.Count > 0)
                {
                    if (transitions.Count == 1)
                    {
                        var t = transitions[0];
                        nodeList[t.Source].Next = nodeList[t.Target];
                    }
                    else
                    {
                        FlowSwitch<String> newSwitch = new FlowSwitch<String> { Expression = flowGlobalTransition };
                        flow.Nodes.Add(newSwitch);
                        nodeList[state.Id].Next = newSwitch;

                        try
                        {
                            var timeouttransition = transitions.First(result => result.Type == PD_TransitionTypes.TimeoutTransition);

                            newSwitch.Cases.Add("TimeOut!", nodeList[timeouttransition.Target]);
                            transitions.Remove(timeouttransition);
                        }
                        catch (Exception e) { }

                        if (state.Type == PD_StateTypes.SendState)
                        {
                            newSwitch.Default = nodeList[transitions[0].Target];
                        }
                        else if (state.Type == PD_StateTypes.ReceiveState)
                        {
                            foreach (var t in transitions)
                            {
                                newSwitch.Cases.Add(receiveTranstionToString(process, (PD_ReceiveTransition)t), nodeList[t.Target]);
                            }
                        }
                        else
                        {
                            foreach (var t in transitions)
                            {
                                newSwitch.Cases.Add(((PD_RegularTransition)t).Name, nodeList[t.Target]);
                            }
                        }
                    }
                }
            }

            ActivityBuilder builder = new ActivityBuilder();
            builder.Name = "strICT.InFlowTest.WFProcesses." + process.Name + "." + subject.Name;


            builder.Implementation = flow;

            VisualBasic.SetSettings(builder, new VisualBasicSettings());

            //StringBuilder sb = new StringBuilder();
            StringWriterUtf8 stream = new StringWriterUtf8();
            XamlWriter writer = ActivityXamlServices.CreateBuilderWriter(new XamlXmlWriter(stream, new XamlSchemaContext()));
            XamlServices.Save(writer, builder);


            string res = stream.GetStringBuilder().ToString();
            res = res.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
            return res;
        }

        private string collectionToString(ICollection<string> collection)
        {
            string tmp = "";
            foreach (string item in collection)
            {
                tmp = tmp + "," + item;
            }

            if (tmp.Length > 0)
                tmp = tmp.Remove(0, 1);
            return tmp;
        }

        private string receiveTranstionToString(PD_Process process, PD_ReceiveTransition transition)
        {
            string tmp = "";

            var message = process.Messages.First(result => result.Id == transition.Message);
            var from = process.Subjects.First(result => result.Id == message.From);

            tmp = from.Name + "|" + message.PD_MessageType.Name;

            return tmp;
        }
    }

    public class StringWriterUtf8 : System.IO.StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }




}