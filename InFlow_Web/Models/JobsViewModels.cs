using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Models.JobsViewModels
{
    public class ProcessTasksViewModel
    {
        public int ProcessId { get; set; }

        public string ProcessName { get; set; }

        public int Version { get; set; }

        public string Description { get; set; }

        public List<strICT.InFlow.Web.Models.JobsViewModels.TaskListItemViewModel> Tasks { get; set; }
    }

    public class TaskListItemViewModel
    {
        [Required]
        public int Id { get; set; }

        public int ProcessId { get; set; }

        public int OrderId { get; set; }

        public string DateTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public bool Done { get; set; }

        public DateTime DateTimeSubmitted { get; set; }
    }

    public class TaskParameter
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public dynamic Value { get; set; }

        public TaskParameter(string name, dynamic jdata)
        {
            this.Name = name;
            this.Type = (string)jdata.Type;
            this.Value = jdata.Value;
           
        }
        public TaskParameter() { }

    
    }

    public class TaskViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ProcessName { get; set; }

        public int Version { get; set; }

        public bool Done { get; set; }

        public bool Seen { get; set; }

        public DateTime DoneDate { get; set; }

        public bool Timedout { get; set; }

        public string StartedByUser { get; set; }
        public DateTime ProcessStartDate { get; set; }

        public DateTime TaskCreatedDate { get; set; }

        public string ViewMode { get; set; }

    }

    public class FunctionTaskViewModel : TaskViewModel
    {


        public List<TaskParameter> ReadableParameters { get; set; }

        public List<TaskParameter> EditableParameters { get; set; }

        public string selectedTransiton { get; set; } 

        public List<SelectListItem> Transitions { get; set; }

        public FunctionTaskViewModel()
        {
            Transitions = new List<SelectListItem>();

            ReadableParameters = new List<TaskParameter>();
            EditableParameters = new List<TaskParameter>();
        }
    }

    public class ReceiveTaskViewModel : TaskViewModel
    {


        [Required]
        public bool FromMultisubject { get; set; }

        [Required]
        public List<MessagesViewModel> Messages { get; set; }

        public string[] selectedMessages { get; set; }

        public ReceiveTaskViewModel()
        {
            Messages = new List<MessagesViewModel>();
        }

    }

    public class SendTaskViewModel : TaskViewModel
    {
        

        public List<TaskParameter> ReadableParameters { get; set; }

        public List<TaskParameter> EditableParameters { get; set; }

        [Required]
        public bool ToMultiSubject { get; set; }

        public string[] SelectedUsers { get; set; }

        [Required]
        public List<SelectListItem> Recipients { get; set; }

        public string selectedRecipient { get; set; }

        public SendTaskViewModel()
        {
            Recipients = new List<SelectListItem>();

            ReadableParameters = new List<TaskParameter>();
            EditableParameters = new List<TaskParameter>();
        }
    }

    public class MessagesViewModel
    {
        [Required]
        public int Message_Id { get; set; }

        [Required]
        public string Sender_Username { get; set; }

        [Required]
        public string Message_Type { get; set; }


        public List<TaskParameter> Parameters { get; set; }

        public MessagesViewModel()
        {
            Parameters = new List<TaskParameter>();
        }
    }

    public class StartProcessItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }

        public string Description { get; set; }
    }
}