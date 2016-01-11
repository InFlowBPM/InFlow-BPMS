using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models
{
    public class ProcessOverviewViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Version { get; set; }

        public string Info { get; set; }

        public int InstancesTotal { get; set; }

        public int InstancesCompleted { get; set; }

        public int InstancesRunning { get; set; }

        public TimeSpan AverageCycleTime { get; set; }

        public TimeSpan MinCycleTime { get; set; }

        public TimeSpan MaxCycleTime { get; set; }
    }

    public class ProcessDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Version { get; set; }

        public string Info { get; set; }

        public List<ProcessDetailsItemViewModel> Details { get; set; }

        public ProcessDetailsViewModel()
        {
            Details = new List<ProcessDetailsItemViewModel>();
        }
    }

    public class ProcessDetailsItemViewModel
    {
        public string Id { get; set; }

        public DateTime DateStarted { get; set; }

        public string StartedByUser { get; set; }

        public DateTime DateEnded { get; set; }

        public string EndedByUser { get; set; }

        public TimeSpan CycleTime { get; set; }

        public Int64 CycleTimet { get; set; }

        public bool Ended { get; set; }
    }
}