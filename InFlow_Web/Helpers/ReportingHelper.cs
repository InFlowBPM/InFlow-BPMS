using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Helpers
{
    public class ReportingHelper
    {
        InFlowDb _inflowDb = new InFlowDb();

        public List<ProcessOverviewViewModel> createProcessOverview()
        {
            List<ProcessOverviewViewModel> processOverview = new List<ProcessOverviewViewModel>();
            var processes = _inflowDb.P_Processes.ToList();
            foreach(var i in processes)
            {
                ProcessOverviewViewModel m = new ProcessOverviewViewModel() { Id = i.Id, Name = i.WS_Project.Name, Version = i.WS_Project_Version, Info = i.ProcessInfo, InstancesTotal = 0, InstancesRunning = 0, InstancesCompleted = 0 };

                var c =
                    from pi in _inflowDb.P_ProcessInstance
                    where pi.Ended == true && pi.P_Process_Id == m.Id
                    select new { Id = pi.P_Process_Id, CycleTime = DbFunctions.DiffSeconds( pi.DateStarted.Value , pi.DateEnded.Value)};

                var r =
                    from pi in _inflowDb.P_ProcessInstance
                    where pi.Ended == false && pi.P_Process_Id == m.Id
                    select pi.Id;

                var completed = c.ToList();
                var running = r.ToList();

                m.InstancesCompleted = completed.Count;
                m.InstancesRunning = running.Count;
                m.InstancesTotal = m.InstancesRunning + m.InstancesCompleted;
                if (m.InstancesCompleted > 0)
                {
                    m.MaxCycleTime = new TimeSpan(0,0, 0, (int)completed.Max(x => x.CycleTime));
                    m.MinCycleTime = new TimeSpan(0,0, 0, (int)completed.Min(x => x.CycleTime));
                    m.AverageCycleTime = new TimeSpan(0,0, 0, (int)completed.Average(x => x.CycleTime));
                }
               
                processOverview.Add(m);
            }
            return processOverview;
        }

        public ProcessDetailsViewModel createProcessDetails(int processId)
        {
            var process = _inflowDb.P_Processes.Find(processId);

            ProcessDetailsViewModel model = new ProcessDetailsViewModel() { Id = process.Id, Name = process.WS_Project.Name , Version = process.WS_Project_Version, Info = process.ProcessInfo};

            var completed =
                from pi in _inflowDb.P_ProcessInstance
                where pi.P_Process_Id == processId && pi.Ended == true  
                select new ProcessDetailsItemViewModel { Ended = true, Id = pi.Id, StartedByUser = pi.StartedByUser, EndedByUser = pi.EndedByUser, DateStarted = pi.DateStarted.Value, DateEnded = pi.DateEnded.Value, CycleTimet = DbFunctions.DiffSeconds(pi.DateStarted.Value, pi.DateEnded.Value).Value };

            var running =
                from pi in _inflowDb.P_ProcessInstance
                where pi.P_Process_Id == processId && pi.Ended == false
                select new ProcessDetailsItemViewModel { Ended = false, Id = pi.Id, StartedByUser = pi.StartedByUser, EndedByUser = "", DateStarted = pi.DateStarted.Value };


            model.Details = completed.ToList();
            model.Details.ForEach(d => d.CycleTime = new TimeSpan(0, 0, 0, (int) d.CycleTimet));

            model.Details.AddRange(running.ToList());

            model.Details = model.Details.OrderByDescending(x => x.DateStarted).ToList();

            return model;
        }
    }
}