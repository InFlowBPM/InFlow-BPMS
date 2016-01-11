using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strICT.InFlow.Web.Models.ManageBackendViewModels
{

    public class ManageBackendProcessItemViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int Version { get; set; }
        public int ProcessId { get; set; }
        public string ProcessScopeName { get; set; }
        public string GlobalProcessName { get; set; }
        public string ProcessInfo { get; set; }
        public string PublishDate { get; set; }
        public bool Active { get; set; }
    }

    public class ManageBackendProcessDetailViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int Version { get; set; }
        public int ProcessId { get; set; }
        public string ProcessScopeName { get; set; }
        public string GlobalProcessName { get; set; }
        public string ProcessInfo { get; set; }
        public string PublishDate { get; set; }
        public bool Active { get; set; }

        public List<ManageBackendProcessDetailSubjectViewModel> Subjects { get; set; }

        public ManageBackendProcessDetailViewModel()
        {
            Subjects = new List<ManageBackendProcessDetailSubjectViewModel>();
        }
    }

    public class ManageBackendProcessDetailSubjectViewModel
    {
        public string Name { get; set; }

        public string AssignedRole { get; set; }

        public List<string> RelatedUsers  { get; set; }

        public ManageBackendProcessDetailSubjectViewModel()
        {
            RelatedUsers = new List<string>();
        }
    }
}