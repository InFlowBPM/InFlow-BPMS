using Microsoft.Workflow.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.Db.Contracts.InFlow
{
    /// <summary>
    /// Entity Task
    /// </summary>
    public class T_Task
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        public string WFId { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public bool Seen { get; set; }
        public bool IsEndState { get; set; }
        public string ReadableParameters { get; set; }
        public string EditableParameters { get; set; } //Bei Receive State sind hier die Nachrichten zu sehen. <mIID, "Beschreibung">
        public virtual List<T_TaskProperty> TaskProperties { get; set; }  //Receive-Task .. MessageTypes; Send-Task ... Recipients; Function-Task ... Transitions
        //Send-Task Recipients "Subject"

        public int InternalOrderId { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public string SubmittedByUser { get; set; }

        public string SubmittedEditableParameters { get; set; }

        public string SubmittedTaskProperties { get; set; }

        public bool ToMultiSubject { get; set; }

        
        public int P_ProcessSubject_Id { get; set; }

        public string P_ProcessInstance_Id { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public T_Task()
        {
            TaskProperties = new List<T_TaskProperty>();
            ToMultiSubject = false;
            DateCreated = DateTime.Now;
            Done = false;
            Seen = false;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="wFId"></param>
        /// <param name="name"></param>
        /// <param name="done"></param>
        /// <param name="isEndState"></param>
        /// <param name="readableParameters"></param>
        /// <param name="editableParameters"></param>
        /// <param name="taskProperties"></param>
        public T_Task(string type, string wFId, string name, bool done, bool seen, bool isEndState, string readableParameters, string editableParameters, string taskProperties, int orderId)//, int p_ProcessSubject_Id, string p_ProcessInstance_Id)
        {
            this.Type = type;
            this.WFId = wFId;
            this.Name = name;
            this.Done = done;
            this.Seen = seen;
            this.IsEndState = isEndState;
            this.ReadableParameters = readableParameters;
            this.EditableParameters = editableParameters;
            this.TaskProperties = stringToList(taskProperties);
            this.InternalOrderId = orderId;
            this.ToMultiSubject = false;
            this.DateCreated = DateTime.Now;
            /*this.P_ProcessSubject_Id = p_ProcessSubject_Id;
            this.P_ProcessInstance_Id = p_ProcessInstance_Id;*/
        }

        /// <summary>
        /// convert task to WorkflowNotification
        /// </summary>
        /// <returns></returns>
        public WorkflowNotification toWorkflowNotification()
        {
            return new WorkflowNotification()
            {
                Properties =
                {
                    { "NotificationType" , "NewTask" }
                },
                Content = new Dictionary<string, object>()
                {
                    { "Type", Type },
                    { "WFId", WFId },
                    { "Name", Name },
                    { "Done", Done },
                    { "IsEndState", IsEndState },
                    { "ReadableParameters", ReadableParameters },
                    { "EditableParameters", EditableParameters },
                    { "TaskProperties", listToString(TaskProperties) },
                    { "InternalOrderId", InternalOrderId}
                }
            };
        }

        /// <summary>
        /// convert TaskProperties to list of string
        /// </summary>
        /// <returns></returns>
        public List<string> getTaskPropertiesAsListOfString()
        {
            List<string> listOfString = new List<string>();
            foreach (T_TaskProperty i in TaskProperties)
            {
                listOfString.Add(i.Value);
            }

            return listOfString;
        }

        /// <summary>
        /// convert csv to list of TaskProperties
        /// </summary>
        /// <param name="csv"></param>
        /// <returns></returns>
        private List<T_TaskProperty> stringToList(string csv)
        {
            List<string> tmp = new List<string>();
            if (csv == null)
                csv = "";
            if (csv.Length > 0)
                tmp = new List<string>(csv.Split(','));

            List<T_TaskProperty> tp = new List<T_TaskProperty>();
            foreach (string item in tmp)
            {
                tp.Add(new T_TaskProperty(item));
            }

            return tp;
        }

        /// <summary>
        /// convert list of TaskProperty to csv-string
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string listToString(List<T_TaskProperty> list)
        {
            string tmp = "";
            foreach (T_TaskProperty i in list)
            {
                tmp = tmp + i.Value + ",";
            }

            tmp = tmp.TrimEnd(',');

            return tmp;
        }
    }
}
